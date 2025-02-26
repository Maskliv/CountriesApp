
Este proyecto es un ejemplo de una aplicación web que utiliza ASP.NET como backend y Angular como frontend. La aplicación consume la API pública [REST Countries](https://restcountries.com/v3.1) para mostrar información sobre países del mundo.

### Características

- Consulta de datos de países incluyendo:
    - Nombres
    - Idiomas
    - Población
    - Bandera
    - Continente

### Tecnologías Utilizadas

- Backend:
    - ASP.NET Core
    - C#
    - HTTP Client para consumo de API externa

- Frontend:
    - Angular
    - TypeScript
    - Angular Material (UI Components)

### Estructura del Proyecto

El proyecto está dividido en dos partes principales:
1. API Server (ASP.NET)
2. Cliente Web (Angular)

### Configuración

Para ejecutar el proyecto:

1. Clonar el repositorio
2. Restaurar las dependencias del servidor
3. Restaurar las dependencias del cliente:
   ```
   npm install
   ```
4. Ejecutar el servidor en modo debug:
   ```
   dotnet run --project CountriesApp.Server
   ```
5. Ejecutar los tests del servidor:
   ```
   dotnet test
   ```
6. Ejecutar el cliente (desde el directorio /countriesApp.Client):
   ```
   ng serve --proxy-config src/proxy.conf.js
   ```

