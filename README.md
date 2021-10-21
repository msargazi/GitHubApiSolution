# GitHubApiSolution 

# What is it?
"GitHubApi" is an api for call github rest api

# Use case
The sample application has one services namely,api
- api has two controller namly,User and Repo
- User controller has one method "api/User",you can call this method to get your profile in github 
- Repo controller has on method "api/Repo",you can call this method for getting your github public repository

# Design Patterns
[Mediator](https://refactoring.guru/design-patterns/mediator) - is a behavioral design pattern that helps to reduce chaotic dependencies between objects.
The main goal is to disallow direct communication between the objects and instead force them to communicate only via the mediator

[CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) -stands for Command Query Responsibility Segregation and is used to use different models for read and for write operations

[Repository](https://medium.com/@pererikbergman/repository-design-pattern-e28c0f3e4a30) -have two purposes; first it is an abstraction of the data layer and second it is a way of centralising the handling of the domain objects

[Generic Repository](https://dotnettutorials.net/lesson/generic-repository-pattern-csharp-mvc/) -This is actually boring and repeating work, especially if all the repositories are going to do the same kind of work (i.e. typically database CRUD operations) and this is against the DRY (Don’t Repeat Yourself) principle as you are repeating the same code again and again in each repository

# NuGet packages
- [FakeItEasy](https://fakeiteasy.github.io/) -The easy mocking library for .NET


# Technology
- [Swagger](https://swagger.io/) - API documentation


# Tools
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/) -Programming
- [Git](https://git-scm.com/) -Version control
- [Docker](https://www.docker.com/) -Deployment

# Development
 Below are the steps to bring up the development environment and get started.
 
1. run "Update-Database" command in package manager console for create database
2. set api as sturt up project, and run
 
 


