# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar y restaurar dependencias
COPY ["MyApp.csproj", "./"]
RUN dotnet restore "MyApp.csproj"

# Copiar el código fuente y compilar
COPY . .
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Imagen final con solo la aplicación publicada
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar la aplicación desde la fase de construcción
COPY --from=build /app/publish . 

# Copiar la carpeta wwwroot para servir archivos estáticos (imagen del gato)
COPY ./wwwroot /app/wwwroot

# Configurar Kestrel para escuchar en todas las interfaces en el puerto 8080
ENV ASPNETCORE_URLS=http://+:8080

# Definir el punto de entrada
ENTRYPOINT ["dotnet", "MyApp.dll"]
