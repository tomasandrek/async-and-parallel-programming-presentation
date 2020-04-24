# Take a base image from the public Docker Hub repositories
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
COPY --from=build /app .
ENTRYPOINT ["dotnet", "FakeWebApi.dll"]