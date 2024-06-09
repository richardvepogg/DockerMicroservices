#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceAutenticacao/Autenticacao/Autenticacao.csproj", "ServiceAutenticacao/Autenticacao/"]
COPY ["ServiceAutenticacao/Autenticacao.Negocio/Autenticacao.Negocio.csproj", "ServiceAutenticacao/Autenticacao.Negocio/"]
COPY ["ServiceAutenticacao/Autenticacao.AcessoDados/Autenticacao.AcessoDados.csproj", "ServiceAutenticacao/Autenticacao.AcessoDados/"]
COPY ["ServiceAutenticacao/Autenticacao.Dominio/Autenticacao.Dominio.csproj", "ServiceAutenticacao/Autenticacao.Dominio/"]
RUN dotnet restore "./ServiceAutenticacao/Autenticacao/./Autenticacao.csproj"
COPY . .
WORKDIR "/src/ServiceAutenticacao/Autenticacao"
RUN dotnet build "./Autenticacao.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Autenticacao.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Autenticacao.dll"]