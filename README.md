# Wayni-Evaluación

Instrucciones para ejecutar la aplicación:

1. Descargar el código fuente de la aplicación o clonar el repositorio en una unidad local
   git clone https://github.com/gazoo80/Wayni-Evaluacion.git

2. Abra la solución en Visual Studio 2022. La solucion contiene 4 proyectos
   DemoWayni.Web
   DemoWayni.Application
   DemoWayni.Infrastructure
   DemoWayni.Domain: 

3. Configurar la cadena de conexión. Abrir el archivo \DemoWayni\DemoWayni.Web\appsettings.json
   Ingresar el nombre de su servidor local de base de datos y las credenciales correspondientes

   "DefaultConnection": "Data Source={Servidor local}; Initial Catalog=DemoWayniDB; User={usuario}; Password={password}; TrustServerCertificate=True"

4. En Visual Studio abrir el Administrador de Paquetes para ejecutar las migraciones.
   Herramientas => Adminstrador de Paquetes NuGet => Consola de Administrador de paquetes 
   
   A. Seleccionar el proyecto DemoWayni.Infrastructure
   B. Ejecutar el siguiente comando:
      Update-database

   Se habrá creado la base de datos DemoWayniDB con las tablas correspondientes.

5. Ejecutar la aplicación.
   La aplicación registrará algunos usuarios por defecto al iniciar.
