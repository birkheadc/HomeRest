# Birkheadc's Homepage Backend

Rest api for my personal homepage, used to update dynamic information.



In Development, `ConnectionString` and `ApiKey` must be declared via dotnet user-secrets.

This should be done by first initializing user-secrets via
`dotnet user-secrets init`
then
`dotnet user-secrets set ConnectionString server=example;port=1234;database=example;user=username;password=password`
as well as
`dotnet user-secrets set ApiKey secretApiKey`

Dotnet user-secrets are not made for production. In production, the Connection String and Api Key must be declared via environmental variables. I do this via Docker. The variables are declared in the docker-compose, passing them to this application's Dockerfile, which sets up the variables.