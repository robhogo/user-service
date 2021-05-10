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

### Used work
https://medium.com/@nick_92077/user-authentication-basics-hashing-and-jwt-3f9adf12272
https://medium.com/dealeron-dev/storing-passwords-in-net-core-3de29a3da4d2