#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceCadastroProduto/CadastroProduto/CadastroProduto.csproj", "ServiceCadastroProduto/CadastroProduto/"]
COPY ["ServiceCadastroProduto/CadastroProduto.AcessoDados/CadastroProduto.AcessoDados.csproj", "ServiceCadastroProduto/CadastroProduto.AcessoDados/"]
COPY ["ServiceCadastroProduto/CadastroProduto.Dominio/CadastroProduto.Dominio.csproj", "ServiceCadastroProduto/CadastroProduto.Dominio/"]
COPY ["ServiceCadastroProduto/CadastroProduto.Negocio/CadastroProduto.Negocio.csproj", "ServiceCadastroProduto/CadastroProduto.Negocio/"]
RUN dotnet restore "./ServiceCadastroProduto/CadastroProduto/./CadastroProduto.csproj"
COPY . .
WORKDIR "/src/ServiceCadastroProduto/CadastroProduto"
RUN dotnet build "./CadastroProduto.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CadastroProduto.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CadastroProduto.dll"]