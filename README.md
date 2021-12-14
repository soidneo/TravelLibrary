# TRAVEL Library

Esta es una aplicación que tiene como propósito obtener la información del inventario de la libreria Travel, mostrando un listado de los libros con un link para ver su respectiva información.

## Comenzando 🚀

_Instrucciones para obtener una copia del proyecto en funcionamiento en la máquina local para propósitos de prueba._


### Pre-requisitos 📋

Visual Studio 2019

SQL Server 



### Instalación 🔧


_Abra Visual Studio, en la ventana de inicio, seleccione Clonar un repositorio. Especifique o escriba la ubicación del repositorio, en la dirección URL debe ir el link: https://github.com/soidneo/TravelLibrary.git y luego seleccione el botón Clonar. En el Explorador de soluciones; seleccione la primera solución (Travel.sln)_

```
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-VJE7NO4;Database=TravelLibrayDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```
_Luego una vez cargada la solución, dentro de la carpeta del proyecto Travel.Web abrir el archivo y cambiar el valor del parametro Server dentro de DefaultConnection, y colocar el nombre del servidor de base de datos del equipo local


Luego click derecho sobre la solución en el explorador de soluciones, opcion Limpiar, luego compilar y despues ejecutar el proyecto, asegurarse de que el proyecto de inicio sea Travel.Web

## Ejecutando pruebas ⚙️

_Para ejecutar cada prueba nos podemos ubicar sobre el proyecto de pruebas deseado y darle click derecho y seleccionar la opción ejecutar pruebas, lo cual nos desplegará la ventana del explorador de pruebas donde podremos seleccionar y ejecutar cada una o todas las pruebas que tiene la solución_

## Construido con 

* [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
* [Domain Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design)
* [Specification Pattern ](https://en.wikipedia.org/wiki/Specification_pattern)
## Autor ✒️

Pablo Andrés Gómez
