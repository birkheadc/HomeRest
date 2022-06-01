FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000

ARG API_KEY

ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production

ARG DATABASE_USERNAME
ARG DATABASE_PASSWORD

ENV ASPNETCORE_APIKEY=${API_KEY}
ENV ASPNETCORE_CONNECTIONSTRING="server=home-db;port=3306;database=home;user=${DATABASE_USERNAME};password=${DATABASE_PASSWORD}"

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["HomeRest.csproj", "./"]
RUN dotnet restore "HomeRest.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "HomeRest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeRest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeRest.dll"]
