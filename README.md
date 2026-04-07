# DGII App

Aplicación full-stack para gestionar información de contribuyentes y comprobantes fiscales, compuesta por una API en .NET y una interfaz web en React.

## Tech Stack

- Backend: ASP.NET Core Web API (.NET 8)
- Arquitectura: capas Core / Infrastructure / API
- Base de datos: SQLite con Entity Framework Core
- Frontend: React (Create React App) + Axios
- Contenedores: Docker + Docker Compose
- Logging y observabilidad: Serilog
- Documentación API: Swagger (Swashbuckle)

## Cómo correr el proyecto

Desde la raíz del proyecto, ejecuta:

```bash
docker compose up --build
```

Servicios disponibles:

- Frontend: http://localhost:3000
- API: http://localhost:5000
- Swagger: http://localhost:5000/swagger

Para detenerlo:

```bash
docker compose down
```
