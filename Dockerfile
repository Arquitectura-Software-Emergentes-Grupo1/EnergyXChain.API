# Usar la imagen oficial de .NET 8.0 como imagen base para tiempo de ejecuci�n
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Usar la imagen oficial de .NET 8.0 SDK para la fase de construcci�n
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EnergyXChain.API/EnergyXChain.API.csproj", "EnergyXChain.API/"]
RUN dotnet restore "EnergyXChain.API/EnergyXChain.API.csproj"
COPY . .
WORKDIR "/src/EnergyXChain.API"
RUN dotnet build "EnergyXChain.API.csproj" -c Release -o /app/build

# Publicar la aplicaci�n
FROM build AS publish
RUN dotnet publish "EnergyXChain.API.csproj" -c Release -o /app/publish

# Configurar la imagen final para el tiempo de ejecuci�n
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnergyXChain.API.dll"]