FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RoBHo-UserService.csproj", ""]
RUN dotnet restore "./RoBHo-UserService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RoBHo-UserService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoBHo-UserService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoBHo-UserService.dll"]