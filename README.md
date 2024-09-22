# Wayni-Evaluación

![Interfaz principal](https://res.cloudinary.com/dryukipp5/image/upload/v1726986241/Wayni/adjvj8pnxzfghvprtzup.png)

## Descripción de la aplicación

La aplicación desarrollada es una aplicación web cuya funcionalidad principal es la de gestionar un CRUD (Crear, Leer, Actualizar, Eliminar) de usuarios. Esta aplicación está construida en ASP.NET Core 8 MVC.

Para el backend de la aplicación se ha utilizado “Clean Architecture”. La estructura de la aplicación consta de las siguientes capas (proyectos):

* ***DemoWayni.Web:*** Esta es la capa de presentación donde se encuentra el frontend de la aplicación.
* ***DemoWayni.Application:*** Aquí están localizados los servicios a ser accesados por el frontend. Además de interfaces, view models, utilidades, etc.
* ***DemoWayni.Infrastructure:*** En esta capa se encuentran los repositorios, contexto y todo lo que necesitamos para la persistencia de los datos.
* ***DemoWayni.Domain:*** Esta es la capa más interna de la aplicación. Aquí se ubican las entidades de negocio.

En cuanto al frontend se ha optado por una aplicación MVC (Modelo, Vista, Controlador). Para la construcción y funcionalidad de las interfaces me he apoyado en librerías como jQuery, Bootstrap, Toastr, SweetAlert. La interfaz es completamente “responsive”.

Finalmente, para la persistencia de datos se ha usado MS SQL Server 2021 y el ORM Entity Framework Core del lado de la aplicación en un enfoque “Code First”.

## Instrucciones para ejecutar la aplicación:

1. Descargue el código fuente de la aplicación o clone el repositorio en una unidad local

   Puede ejecutar la siguiente línea en una ventana de comandos
  
   ```git clone https://github.com/gazoo80/Wayni-Evaluacion.git```

2. Abra la solución en Visual Studio 2022. La solución contiene 4 proyectos:
   
   * DemoWayni.Web
   * DemoWayni.Application
   * DemoWayni.Infrastructure
   * DemoWayni.Domain

   ![Proyectosl](https://res.cloudinary.com/dryukipp5/image/upload/v1726986033/Wayni/wvlscyqwrknfiegf3ltt.png)

3. Configure la cadena de conexión. Abra el archivo:

    ```\DemoWayni\DemoWayni.Web\appsettings.json```

   Ingrese el nombre de su servidor local de base de datos SQL Server y las credenciales correspondientes en la cadena de 
   conexión

    ```"DefaultConnection": "Data Source={Servidor local}; Initial Catalog=DemoWayniDB; User={usuario}; Password={password}; TrustServerCertificate=True" ```

   ![Conexiónl](https://res.cloudinary.com/dryukipp5/image/upload/v1726986033/Wayni/uuos9jxgmqqwddnr9qty.png)

4. En Visual Studio abra el Administrador de Paquetes para ejecutar las migraciones.

   ```Menú Herramientas => Administrador de Paquetes NuGet => Consola de Administrador de paquetes```
   
   A. Seleccione el proyecto DemoWayni.Infrastructure

   B. Ejecute el siguiente comando:

      ```Update-database```

   Se habrá creado la base de datos DemoWayniDB con las tablas correspondientes en su servidor local de base de datos SQL 
   Server. Puede usar Microsoft SQL Server Management Studio para visualizar la base de datos creada.

   ![Update Databasel](https://res.cloudinary.com/dryukipp5/image/upload/v1726986034/Wayni/asktml3kjtcfrrw9cmm3.png)

5. Asegúrese de establecer como proyecto de inicio el proyecto DemoWayni.Web

   Haga clic derecho sobre el proyecto DemoWayni.Web y seleccione la opción "Establecer como proyecto de inicio"

   ![Proyecto Inicio](https://res.cloudinary.com/dryukipp5/image/upload/v1726986034/Wayni/nkjdd072uh7yj4qbmm89.png)

6. Ejecute la aplicación haciendo clic en F5 o Ctrl + F5

   Al iniciar la aplicación está registrará algunos usuarios por defecto.

   ![Ejecutar](https://res.cloudinary.com/dryukipp5/image/upload/v1726986034/Wayni/mpwhpvrkp7flkmhxj3o5.png)


## Enlaces de interés

1. Video del uso de la aplicación

   [Ver video](https://youtu.be/OQUo7ehtV4o)

