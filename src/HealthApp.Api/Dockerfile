FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/HealthApp.Api/HealthApp.Web.Api.csproj", "src/HealthApp.Api/"]
COPY ["src/HealthApp.Infrastructure/HealthApp.Infrastructure.csproj", "src/HealthApp.Infrastructure/"]
COPY ["src/HealthApp.Application/HealthApp.Application.csproj", "src/HealthApp.Application/"]
RUN dotnet restore "./src/HealthApp.Api/HealthApp.Web.Api.csproj"
COPY . .
WORKDIR "/src/HealthApp.Api"
RUN dotnet build "./HealthApp.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HealthApp.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthApp.Web.Api.dll"]