FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["book-library-api/src/BookLibrary.API/BookLibrary.API.csproj", "src/BookLibrary.API/"]
COPY ["book-library-api/src/BookLibrary.Domain/BookLibrary.Domain.csproj", "src/BookLibrary.Domain/"]
COPY ["book-library-api/src/BookLibrary.Shared/BookLibrary.Shared.csproj", "src/BookLibrary.Shared/"]
COPY ["book-library-api/src/BookLibrary.Infra/BookLibrary.Infra.csproj", "src/BookLibrary.Infra/"]

RUN dotnet restore "./src/BookLibrary.API/BookLibrary.API.csproj"

COPY book-library-api .

WORKDIR "/src/src/BookLibrary.API"
RUN dotnet build "./BookLibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookLibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BookLibrary.API.dll"]