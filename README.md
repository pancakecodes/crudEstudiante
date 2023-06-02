# crudEstudiante
Sistema de Gestión de Estudiantes y Calificaciones

La aplicación web a desarrollar debe cumplir con los siguientes requisitos:

    Gestión de Estudiantes:
        Permitir crear, leer, actualizar y eliminar estudiantes.
        Incluir un filtro para buscar estudiantes por nombre, ID u otra información relevante.

    Gestión de Calificaciones:
        Permitir asignar calificaciones a los estudiantes en las 4 materias básicas: Lengua Española, Matemáticas, Ciencias Sociales y Ciencias Naturales.
        Calcular automáticamente el literal correspondiente a la calificación asignada según la siguiente escala:
            A: 90-100
            B: 80-89
            C: 70-79
            F: 0-69

    Pase de Lista:
        Permitir realizar el pase de lista diario, registrando la asistencia de los estudiantes.
        Mostrar un historial del pase de lista por día.

Tecnologías Utilizadas

El proyecto se basará en las siguientes tecnologías:

    Backend: .NET Core
    Frontend: React
    Base de Datos: SQL Server

Estructura del Proyecto

El proyecto se organizará en las siguientes carpetas:

    backend/: Contendrá el código fuente del backend desarrollado en .NET Core.
    frontend/: Contendrá el código fuente del frontend desarrollado en React.
    database/: Contendrá los scripts y archivos relacionados con la base de datos SQL Server.

Instrucciones de Ejecución

Para ejecutar el proyecto, sigue los siguientes pasos:

    Clona el repositorio a tu máquina local.
    Configura la base de datos SQL Server y asegúrate de tener una instancia disponible.
    Ejecuta los scripts de la carpeta database/ para crear la base de datos y las tablas necesarias.
    Configura la conexión a la base de datos en el backend.
    Ejecuta el backend utilizando el entorno de desarrollo adecuado.
    Configura la conexión al backend en el frontend.
    Instala las dependencias del frontend y ejecuta el frontend en modo de desarrollo.
    Accede a la aplicación web a través del navegador y comienza a gestionar estudiantes y calificaciones.
