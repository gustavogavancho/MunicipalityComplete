# Usar la imagen base de ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5003

# Usar la imagen base de .NET SDK para compilar y publicar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo de proyecto y restaurar las dependencias
COPY ["MunicipalityDemo.Api.csproj", "./"]
RUN dotnet restore

# Copiar el resto de los archivos del proyecto y compilar
COPY . .
RUN dotnet build -c Release -o /app/build

# Publicar la aplicación
RUN dotnet publish -c Release -o /app/publish

# Crear el contenedor final desde la imagen base
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Copiar el certificado HTTPS
COPY localhost.pfx /https/localhost.pfx

# Configurar el certificado HTTPS
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/localhost.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=gusgl0113

# Configurar la URL para escuchar en los puertos 5000 y 5001
ENV ASPNETCORE_URLS="https://+:5003"

ENTRYPOINT ["dotnet", "MunicipalityDemo.Api.dll"]