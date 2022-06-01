# Birkheadc's Homepage Backend

Rest api for my personal homepage, used to update dynamic information.

## Usage Instructions

In Development, `ConnectionString` and `ApiKey` must be declared via dotnet user-secrets.

This should be done by first initializing user-secrets via\
`dotnet user-secrets init`\
then\
`dotnet user-secrets set ConnectionString server=example;port=1234;database=example;user=username;password=password`\
as well as\
`dotnet user-secrets set ApiKey secretApiKey`\

Dotnet user-secrets are not made for production. In production, `ConnectionString` and `ApiKey` must again be declared, but via environmental variables. I do this via Docker. The variables are declared in the docker-compose, passing them to this application's Dockerfile, which sets up the variables.

## What does this rest api provide?

Mostly just a standard CRUD repository to post to and retrieve a number of things from a database, making it easier to:

- Update the website
- Have dynamic elements

What is stored / planned to be stored:

- Sections: sections of the main home page that have a title, subtitle and body
- Projects: for each of my projects, a link to that project's website, it's source code, a short description, and a list of what technologies it showcases
- Blog posts: a dynamically updated list of my latest few posts, including title, date, and a short description
- Activity feed: a dynamic list of my recent activity, including linkedin/facebook posts, pushes to github, etc. Still a WIP