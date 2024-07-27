FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Api/Xurmo.Api/Xurmo.Api.csproj", "src/Api/Xurmo.Api/"]
COPY ["src/Common/Xurmo.Common.Infrastructure/Xurmo.Common.Infrastructure.csproj", "src/Common/Xurmo.Common.Infrastructure/"]
COPY ["src/Common/Xurmo.Common.Application/Xurmo.Common.Application.csproj", "src/Common/Xurmo.Common.Application/"]
COPY ["src/Common/Xurmo.Common.Domain/Xurmo.Common.Domain.csproj", "src/Common/Xurmo.Common.Domain/"]
COPY ["src/Common/Xurmo.Common.Presentation/Xurmo.Common.Presentation.csproj", "src/Common/Xurmo.Common.Presentation/"]
COPY ["src/Modules/Catalogs/Xurmo.Modules.Catalogs.Application/Xurmo.Modules.Catalogs.Application.csproj", "src/Modules/Catalogs/Xurmo.Modules.Catalogs.Application/"]
COPY ["src/Modules/Catalogs/Xurmo.Modules.Catalogs.Domain/Xurmo.Modules.Catalogs.Domain.csproj", "src/Modules/Catalogs/Xurmo.Modules.Catalogs.Domain/"]
COPY ["src/Modules/Catalogs/Xurmo.Modules.Catalogs.Infrastructure/Xurmo.Modules.Catalogs.Infrastructure.csproj", "src/Modules/Catalogs/Xurmo.Modules.Catalogs.Infrastructure/"]
COPY ["src/Modules/Catalogs/Xurmo.Modules.Catalogs.IntegrationEvents/Xurmo.Modules.Catalogs.IntegrationEvents.csproj", "src/Modules/Catalogs/Xurmo.Modules.Catalogs.IntegrationEvents/"]
COPY ["src/Modules/Catalogs/Xurmo.Modules.Catalogs.Presentation/Xurmo.Modules.Catalogs.Presentation.csproj", "src/Modules/Catalogs/Xurmo.Modules.Catalogs.Presentation/"]
COPY ["src/Modules/Users/Xurmo.Modules.Users.Application/Xurmo.Modules.Users.Application.csproj", "src/Modules/Users/Xurmo.Modules.Users.Application/"]
COPY ["src/Modules/Users/Xurmo.Modules.Users.Domain/Xurmo.Modules.Users.Domain.csproj", "src/Modules/Users/Xurmo.Modules.Users.Domain/"]
COPY ["src/Modules/Users/Xurmo.Modules.Users.Infrastructure/Xurmo.Modules.Users.Infrastructure.csproj", "src/Modules/Users/Xurmo.Modules.Users.Infrastructure/"]
COPY ["src/Modules/Users/Xurmo.Modules.Users.IntegrationEvents/Xurmo.Modules.Users.IntegrationEvents.csproj", "src/Modules/Users/Xurmo.Modules.Users.IntegrationEvents/"]
COPY ["src/Modules/Users/Xurmo.Modules.Users.Presentation/Xurmo.Modules.Users.Presentation.csproj", "src/Modules/Users/Xurmo.Modules.Users.Presentation/"]
RUN dotnet restore "./src/Api/Xurmo.Api/Xurmo.Api.csproj"
COPY . .
WORKDIR "/src/src/Api/Xurmo.Api"
RUN dotnet build "./Xurmo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Xurmo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xurmo.Api.dll"]