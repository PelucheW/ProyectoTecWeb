# 🏋️ My TrainerHub API

## 📝 Descripción del Proyecto

**My TrainerHub** es una API RESTful desarrollada con **.NET Core (C#)** y **Entity Framework Core (EF Core)** sobre una base de datos **PostgreSQL**. Esta API está diseñada para gestionar la información de usuarios, sus perfiles (datos biométricos) y la creación/gestión de rutinas y ejercicios para un gimnasio o centro de entrenamiento.

### Componentes de la API
| Módulo | Entidades Principales | Propósito |
| :--- | :--- | :--- |
| **Auth & Users** | `User`, `UserProfile` | Manejo de identidad, autenticación (JWT) y perfiles personales. |
| **Rutinas** | `Rutina`, `Ejercicio` | Creación y gestión de planes de entrenamiento con relación N:M (Muchos a Muchos). |

---

## 🛠️ Configuración y Despliegue Local

### 1. Requisitos Previos

* .NET SDK (Versión 7.0 o superior)
* Docker (para levantar la base de datos PostgreSQL local)
* TablePlus / pgAdmin (para inspección de la DB)

### 2. Inicialización de la Base de Datos con Docker

Se recomienda usar Docker para una base de datos PostgreSQL limpia.

1.  **Levantar el Contenedor:**
    ```bash
    docker run --name mi-gym-postgres -e POSTGRES_USER=securityuser -e POSTGRES_PASSWORD=supersecret -e POSTGRES_DB=securitydb -p 5432:5432 -d postgres:latest
    ```

2.  **Configurar la Conexión:**
    Asegúrate de que tu archivo de configuración (`appsettings.Development.json` o `.env`) apunte al `localhost:5432` con las credenciales anteriores.

    ```bash
    # Ejemplo de cadena de conexión local
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=securitydb;Username=securityuser;Password=supersecret"
    }
    ```

### 3. Aplicar Migraciones de Entity Framework Core

Después de configurar la conexión, debes crear las tablas:

1.  **Limpiar Migraciones Antiguas** (Si clonaste el proyecto y tienes conflictos):
    * Borra la carpeta `Migrations`.
    * Borra el archivo `AppDbContextModelSnapshot.cs`.

2.  **Añadir la Migración Inicial:**
    ```bash
    dotnet ef migrations add InitialMigrationGym
    ```

3.  **Aplicar la Migración a la DB:**
    ```bash
    dotnet ef database update
    ```

### 4. Ejecutar la API

```bash
dotnet run
