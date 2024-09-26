FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/HealthApp.Api/HealthApp.Web.Api.csproj", "src/HealthApp.Api/"]
COPY ["src/HealthApp.Infrastructure/HealthApp.Infrastructure.csproj", "src/HealthApp.Infrastructure/"]
COPY ["src/HealthApp.Application/HealthApp.Application.csproj", "src/HealthApp.Application/"]
COPY ["src/HealthApp.Domain/HealthApp.Domain.csproj", "src/HealthApp.Domain/"]
RUN dotnet restore "src/HealthApp.Api/HealthApp.Web.Api.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "src/HealthApp.Api/HealthApp.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/HealthApp.Api/HealthApp.Web.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
RUN apt-get update && apt-get install -y curl
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthApp.Web.Api.dll"]