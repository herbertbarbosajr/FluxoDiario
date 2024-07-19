FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FluxoDiario.Presentation.API/FluxoDiario.Presentation.API.csproj", "FluxoDiario.Presentation.API/"]
COPY ["FluxoDiario.Application/FluxoDiario.Application.csproj", "FluxoDiario.Application/"]
COPY ["FluxoDiario.Domain/FluxoDiario.Domain.csproj", "FluxoDiario.Domain/"]
COPY ["FluxoDiario.Shared/FluxoDiario.Shared.csproj", "FluxoDiario.Shared/"]
COPY ["FluxoDiario.Infrastructure.Configurations/FluxoDiario.Infrastructure.Configurations.csproj", "FluxoDiario.Infrastructure.Configurations/"]
COPY ["FluxoDiario.DataAccess/FluxoDiario.DataAccess.csproj", "FluxoDiario.DataAccess/"]
COPY ["FluxoDiario.Infrastructure.Generic/FluxoDiario.Infrastructure.Generic.csproj", "FluxoDiario.Infrastructure.Generic/"]
RUN dotnet restore "./FluxoDiario.Presentation.API/./FluxoDiario.Presentation.API.csproj"
COPY . .
WORKDIR "/src/FluxoDiario.Presentation.API"
RUN dotnet build "./FluxoDiario.Presentation.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FluxoDiario.Presentation.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoDiario.Presentation.API.dll"]