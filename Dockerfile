FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY [".", "dark-xmera-security/"]

RUN dotnet restore ./dark-xmera-security/dark-xmera-security/dark-xmera-security.csproj

# copy and publish app and libraries
RUN dotnet build "./dark-xmera-security/dark-xmera-security/dark-xmera-security.csproj" -c Release


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app
COPY --from=build ./source/dark-xmera-security/dark-xmera-security/bin/Release/net5.0 .
EXPOSE 80
ENTRYPOINT ["dotnet", "dark-xmera-security.dll"]