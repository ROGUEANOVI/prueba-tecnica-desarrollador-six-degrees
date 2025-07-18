# Prueba Técnica - Desarrollador .NET + Angular - SIX DEGREES IT SOLUTION

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

*   **Modularidad**: La aplicación está estructurada en módulos y componentes, incluyendo un directorio `src/app/shared/components` para elementos reutilizables como el `HeaderComponent` y `FooterComponent`.
*   **Gestión de Usuarios**: El `UserListComponent` se encarga de mostrar la lista de usuarios, combinando `firstName` y `lastName` en una única columna "Nombre". La carga de usuarios se realiza al hacer clic en un botón "Buscar", no al inicio del componente.
*   **Diseño Responsivo**: La interfaz de usuario está optimizada para diferentes tamaños de pantalla, con una presentación de "tarjetas" para la lista de usuarios en dispositivos móviles.

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
git clone https://github.com/ROGUEANOVI/prueba-tecnica-desarrollador-six-degrees.git
cd prueba-tecnica-desarrollador-six-degrees
```

### **2. Configuración de la Base de Datos**

1.  Abre tu gestor de SQL Server (como SSMS o Azure Data Studio).
2.  Asegúrate de que tu cadena de conexión en `backend/Backend/Backend.Services/appsettings.Development.json` apunte a una instancia de SQL Server válida.
3.  Navega a la carpeta del proyecto `Backend.DataAccess`:
    ```bash
    cd backend/Backend/Backend.DataAccess
    ```
4.  Aplica las migraciones para crear la base de datos y la tabla `Usuario`, incluyendo los datos de prueba iniciales (datos semilla) que se insertan automáticamente a través de `OnModelCreating` en el contexto de la base de datos.
    ```bash
    dotnet ef database update
    ```
    *Nota: Si es la primera vez que ejecutas migraciones o si has realizado cambios en el modelo de datos, es posible que necesites generar una nueva migración antes de actualizar la base de datos. Consulta la documentación de Entity Framework Core para más detalles sobre `dotnet ef migrations add`.*

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

4.  **Configuración de CORS**: Abre `Program.cs` y asegúrate de que la configuración de CORS esté presente para permitir la comunicación con el frontend.

    ```csharp
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAngularOrigin",
            builder => builder.WithOrigins("http://localhost:4200") // Origen de tu aplicación Angular
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
    });

    // ...

    var app = builder.Build();

    // ...

    app.UseCors("AllowAngularOrigin"); // Habilitar CORS
    ```

5.  Restaura las dependencias de .NET:
    ```bash
    dotnet restore ../../Backend.sln
    ```

### **4. Configuración del Frontend**

1.  Navega al proyecto de Angular:
    ```bash
    cd ../../../frontend/presentation
    ```
2.  **Configuración de la URL de la API**: Abre `src/environments/environment.development.ts` y asegúrate de que `apiUrl` apunte a la URL de tu backend.

    ```typescript
    export const environment = {
      production: false,
      apiUrl: 'https://localhost:7001/api' // Asegúrate de que esta sea la URL base de tu API
    };
    ```
    *Nota: El `UserService` añade `/users` a esta URL base.*

3.  Instala las dependencias de Node.js:
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

Este proyecto fue desarrollado como parte de la prueba t��cnica para **Six Degrees IT Solution**.

*   **Desarrollador**: Ovidio Romero
*   **[LinkedIn](https://www.linkedin.com/in/ovidio-romero/)**
*   **[GitHub](https://github.com/ROGUEANOVI)**