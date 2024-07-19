FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FluxoDiario.Workers.MessageConsumer/FluxoDiario.Workers.MessageConsumer.csproj", "FluxoDiario.Workers.MessageConsumer/"]
COPY ["FluxoDiario.Application/FluxoDiario.Application.csproj", "FluxoDiario.Application/"]
COPY ["FluxoDiario.Domain/FluxoDiario.Domain.csproj", "FluxoDiario.Domain/"]
COPY ["FluxoDiario.Shared/FluxoDiario.Shared.csproj", "FluxoDiario.Shared/"]
COPY ["FluxoDiario.Infrastructure.Configurations/FluxoDiario.Infrastructure.Configurations.csproj", "FluxoDiario.Infrastructure.Configurations/"]
COPY ["FluxoDiario.DataAccess/FluxoDiario.DataAccess.csproj", "FluxoDiario.DataAccess/"]
COPY ["FluxoDiario.Infrastructure.Generic/FluxoDiario.Infrastructure.Generic.csproj", "FluxoDiario.Infrastructure.Generic/"]
RUN dotnet restore "./FluxoDiario.Workers.MessageConsumer/./FluxoDiario.Workers.MessageConsumer.csproj"
COPY . .
WORKDIR "/src/FluxoDiario.Workers.MessageConsumer"
RUN dotnet build "./FluxoDiario.Workers.MessageConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FluxoDiario.Workers.MessageConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN mkdir /app/relatorios
RUN chmod 775 -R /app/relatorios
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoDiario.Workers.MessageConsumer.dll"]