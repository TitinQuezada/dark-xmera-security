FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ["./dark-xmera-security/dark-xmera-security.csproj", "dark-xmera-security/"]
COPY ["./Helpers.Database/Helpers.Database.csproj", "dark-xmera-security/"]
COPY ["./Helpers.Encrypt/Helpers.Encrypt.csproj", "dark-xmera-security/"]

RUN dotnet restore dark-xmera-security/dark-xmera-security.csproj

# copy and publish app and libraries
COPY . dark-xmera-security/
WORKDIR "/source/dark-xmera-security"
RUN dotnet build "dark-xmera-security.csproj" -c Release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "dotnetapp.dll"]