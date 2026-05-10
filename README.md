# 📦 App web Gestión de Inventarios

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC%205-blue)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6.0-green)
![Chart.js](https://img.shields.io/badge/Charts-Chart.js-orange)
![PDF](https://img.shields.io/badge/Reports-Rotativa-red)

Una solución integral para la gestión de inventarios tecnológicos, diseñada con un enfoque en **arquitectura robusta**, **análisis de datos visual** y **usabilidad profesional**.

## 🚀 Características Principales

* **Panel de Control Moderno**: Interfaz de usuario moderna.
* **Gestión CRUD Completa**: Registro, edición, visualización y eliminación de artículos con persistencia de datos.
* **Reportería Estadística**: Gráficos interactivos de barras y dona que permiten analizar el stock y la distribución de productos en tiempo real.
* **Integridad de Datos**: Lógica de persistencia avanzada para mantener la cronología de registros (`Fecha de Registro`) durante procesos de edición.
* * **Exportación a PDF**: Generación de reportes profesionales listos para impresión mediante la integración de **Rotativa**.

## 🛠️ Tecnologías Utilizadas

* **Backend**: C# con ASP.NET MVC y LINQ.
* **Persistencia**: Entity Framework para la gestión de base de datos SQL.
* **Frontend**: HTML5, CSS3, JavaScript y Bootstrap.
* **Visualización**: Chart.js para el dashboard estadístico.
* **Generación de Documentos**: Rotativa para la conversión de vistas a PDF.

## 📦 Instalación y Configuración

1.  **Clonar el repositorio**:
    ```bash
    git clone [https://github.com/tu-usuario/Gestion_Inventarios_APP.git](https://github.com/tu-usuario/Gestion_Inventarios_APP.git)
    ```
2.  **Restaurar paquetes NuGet**:
    Abre la solución en Visual Studio y compila el proyecto para descargar automáticamente las dependencias (Entity Framework, Chart.js, Rotativa).
3.  **Configurar Base de Datos**:
    El proyecto utiliza **Code First**, por lo que la base de datos se creará automáticamente al ejecutar la aplicación por primera vez.
4.  **Motor de PDF**:
    Asegúrate de que la carpeta `Rotativa` esté presente en la raíz del proyecto para que la exportación de reportes funcione correctamente.

## ✍️ Autor
* **Yesenia Alas** - *Desarrollo y Diseño* - [TuGitHubUser](https://github.com/yeseniaalas719/)

---
