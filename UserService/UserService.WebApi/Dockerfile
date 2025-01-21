#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceUsuarios/Usuarios/Usuarios.csproj", "ServiceUsuarios/Usuarios/"]
COPY ["ServiceUsuarios/Usuarios.AcessoDados/Usuarios.AcessoDados.csproj", "ServiceUsuarios/Usuarios.AcessoDados/"]
COPY ["ServiceUsuarios/Usuarios.Dominio/Usuarios.Dominio.csproj", "ServiceUsuarios/Usuarios.Dominio/"]
COPY ["ServiceUsuarios/Usuarios.Negocio/Usuarios.Negocio.csproj", "ServiceUsuarios/Usuarios.Negocio/"]
RUN dotnet restore "./ServiceUsuarios/Usuarios/Usuarios.csproj"
COPY . .
WORKDIR "/src/ServiceUsuarios/Usuarios"
RUN dotnet build "./Usuarios.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Usuarios.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Usuarios.dll"]