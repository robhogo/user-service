# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 


## Getting Started
Choose one of these three options:
- Run with dotnet CLI.
- Run in container.
- Run in container with MSSQL-dabase.

### Dotnet CLI
```zsh
dotnet restore
dotnet build
dotnet run
```

### Run with Docker
```zsh
 docker build -t robho-userservice .
 docker run -d -p 5000:5000 --name robho-userserv robho-userservice
```