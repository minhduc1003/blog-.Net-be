#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN dotnet dev-certs https
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["blog-.Net-be/blog-.Net-be.csproj", "blog-.Net-be/"]
RUN dotnet restore "./blog-.Net-be/blog-.Net-be.csproj"
COPY . .
WORKDIR "/src/blog-.Net-be"
RUN dotnet build "./blog-.Net-be.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./blog-.Net-be.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN mkdir -p Images
COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=publish /app/publish .
COPY blog-.Net-be/appsettings.json /app/appsettings.json

# Set up a persistent storage location for data protection keys
VOLUME root/.aspnet/DataProtection-Keys 

ENTRYPOINT ["dotnet", "blog-.Net-be.dll"]