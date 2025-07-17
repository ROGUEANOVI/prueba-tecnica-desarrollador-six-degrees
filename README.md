# Prueba Técnica - Desarrollador .NET + Angular - SIX DEGREES IT

Este repositorio contiene la solución a la prueba técnica para el puesto de Desarrollador .NET + Angular. El proyecto consiste en una aplicación web full-stack que permite consultar y visualizar una lista de usuarios desde una base de datos.

## Arquitectura de la Solución

La solución sigue una arquitectura de N-Capas bien definida, con una separación clara de responsabilidades entre el backend y el frontend.

### **Backend (.NET)**
El backend está construido como una solución de .NET con los siguientes proyectos, cada uno representando una capa lógica:

*   `Backend.Entities`: Contiene las clases de entidad (POCOs) que modelan los datos del negocio.
*   `Backend.DataAccess`: Responsable de la interacción directa con la base de datos (conexión, consultas, etc.).
*   `Backend.BusinessLogic`: Contiene la lógica de negocio y actúa como puente entre la capa de servicios y la de acceso a datos.
*   `Backend.Services`: Una Web API que expone los datos y funcionalidades a través de endpoints RESTful.

### **Frontend (Angular)**
El frontend es una Single Page Application (SPA) desarrollada con Angular, responsable de la experiencia de usuario y la presentación de los datos.

---

## Tecnologías Utilizadas

*   **Backend**: .NET 6 (LTS)
*   **Frontend**: Angular 16
*   **Base de Datos**: Microsoft SQL Server
*   **Entorno de Desarrollo**: Visual Studio 2022 / VS Code

---

## Prerrequisitos

Asegúrate de tener instalado el siguiente software antes de continuar:

*   [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
*   [Node.js y npm](https://nodejs.org/) (LTS recomendado)
*   [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)
*   Una instancia de Microsoft SQL Server (Express, Developer, etc.)
*   Un editor de código como [Visual Studio 2022](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/).

---

## Guía de Instalación y Ejecución

Sigue estos pasos para configurar y ejecutar el proyecto en tu máquina local.

### **1. Clonar el Repositorio**

```bash
git clone <URL-DEL-REPOSITORIO>
cd prueba-tecnica-desarrollador-six-degrees
```

### **2. Configuración de la Base de Datos**

1.  Abre tu gestor de SQL Server (como SSMS o Azure Data Studio).
2.  Ejecuta el siguiente script para crear la base de datos `PruebaSD`, la tabla `Usuario` y poblarla con datos de prueba.

```sql
-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PruebaSD')
BEGIN
    CREATE DATABASE PruebaSD;
END
GO

-- Usar la base de datos recién creada
USE PruebaSD;
GO

-- Crear la tabla Usuario
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuario' and xtype='U')
BEGIN
    CREATE TABLE Usuario (
        usuID NUMERIC(18, 0) PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL,
        apellido VARCHAR(100) NOT NULL
    );
END
GO

-- Insertar 5 registros de prueba
INSERT INTO Usuario (nombre, apellido) VALUES
('Andres', 'Rodriguez Vera'),
('Jose', 'Giraldo Perez'),
('Ana', 'Martinez Garcia'),
('Carlos', 'Lopez Fernandez'),
('Maria', 'Sanchez Torres');
GO

-- Verificar que los datos se insertaron correctamente
SELECT * FROM Usuario;
GO
```

### **3. Configuración del Backend**

1.  Navega al proyecto de la API de Servicios:
    ```bash
    cd backend/Backend/Backend.Services
    ```
2.  Abre el archivo `appsettings.Development.json`.
3.  Modifica la sección `ConnectionStrings` para que apunte a tu instancia de SQL Server.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=TU_SERVIDOR;Database=PruebaSD;Trusted_Connection=True;TrustServerCertificate=True;"
      },
      "Logging": {
        // ...
      }
    }
    ```
    *Reemplaza `TU_SERVIDOR` por el nombre de tu servidor SQL (ej. `localhost`, `.\SQLEXPRESS`, etc.).*

4.  Restaura las dependencias de .NET:
    ```bash
    dotnet restore ../../Backend.sln
    ```

### **4. Configuración del Frontend**

1.  Navega al proyecto de Angular:
    ```bash
    cd ../../../frontend/presentation
    ```
2.  Instala las dependencias de Node.js:
    ```bash
    npm install
    ```

### **5. Ejecutar la Aplicación**

Debes tener dos terminales abiertas, una para el backend y otra para el frontend.

*   **Para ejecutar el Backend:**
    ```bash
    # Desde la carpeta /backend/Backend/Backend.Services
    dotnet run
    ```
    La API estará disponible en `https://localhost:7xxx` o `http://localhost:5xxx`.

*   **Para ejecutar el Frontend:**
    ```bash
    # Desde la carpeta /frontend/presentation
    ng serve
    ```
    La aplicación web estará disponible en `http://localhost:4200/`.

---

## Autor

*   **Ovidio Romero**
*   **[LinkedIn](https://www.linkedin.com/in/ovidio-romero/)**
*   **[GitHub](https://github.com/ROGUEANOVI)**
