#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceCadastroProdutoRefit/APIRefit/APIRefit.csproj", "ServiceCadastroProdutoRefit/APIRefit/"]
COPY ["ServiceCadastroProduto/CadastroProduto.Negocio/CadastroProduto.Negocio.csproj", "ServiceCadastroProduto/CadastroProduto.Negocio/"]
COPY ["ServiceCadastroProduto/CadastroProduto.AcessoDados/CadastroProduto.AcessoDados.csproj", "ServiceCadastroProduto/CadastroProduto.AcessoDados/"]
COPY ["ServiceCadastroProduto/CadastroProduto.Dominio/CadastroProduto.Dominio.csproj", "ServiceCadastroProduto/CadastroProduto.Dominio/"]
COPY ["ServiceCadastroProdutoRefit/APIRefit.AcessoDados/APIRefit.AcessoDados.csproj", "ServiceCadastroProdutoRefit/APIRefit.AcessoDados/"]
COPY ["ServiceCadastroProdutoRefit/APIRefit.Negocio/APIRefit.Negocio.csproj", "ServiceCadastroProdutoRefit/APIRefit.Negocio/"]
RUN dotnet restore "./ServiceCadastroProdutoRefit/APIRefit/APIRefit.csproj"
COPY . .
WORKDIR "/src/ServiceCadastroProdutoRefit/APIRefit"
RUN dotnet build "./APIRefit.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./APIRefit.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIRefit.dll"]