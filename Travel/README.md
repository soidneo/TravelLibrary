# TRAVEL Library

Esta es una aplicaci贸n que tiene como prop贸sito obtener la informaci贸n del inventario de la libreria Travel, mostrando un listado de los libros con un link para ver su respectiva informaci贸n.

## Comenzando 馃殌

_Instrucciones para obtener una copia del proyecto en funcionamiento en la m谩quina local para prop贸sitos de prueba._


### Pre-requisitos 馃搵

Visual Studio 2019

SQL Server 



### Instalaci贸n 馃敡


_Abra Visual Studio, en la ventana de inicio, seleccione Clonar un repositorio. Especifique o escriba la ubicaci贸n del repositorio, en la direcci贸n URL debe ir el link: https://github.com/soidneo/TravelLibrary.git y luego seleccione el bot贸n Clonar. En el Explorador de soluciones; seleccione la primera soluci贸n (Travel.sln)_

```
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-VJE7NO4;Database=TravelLibrayDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```
_Luego una vez cargada la soluci贸n, dentro de la carpeta del proyecto Travel.Web abrir el archivo y cambiar el valor del parametro Server dentro de DefaultConnection, y colocar el nombre del servidor de base de datos del equipo local_


_Click derecho sobre la soluci贸n en el explorador de soluciones, opcion Limpiar, luego compilar y despues ejecutar el proyecto, asegurarse de que el proyecto de inicio sea Travel.Web_

## Ejecutando pruebas 鈿欙笍

_Para ejecutar cada prueba nos podemos ubicar sobre el proyecto de pruebas deseado y darle click derecho y seleccionar la opci贸n ejecutar pruebas, lo cual nos desplegar谩 la ventana del explorador de pruebas donde podremos seleccionar y ejecutar cada una o todas las pruebas que tiene la soluci贸n_

## Construido con 

* [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
* [Domain Driven Design](https://en.wikipedia.org/wiki/Domain-driven_design)
* [Specification Pattern ](https://en.wikipedia.org/wiki/Specification_pattern)
## Autor 鉁掞笍

Pablo Andr茅s G贸mez
soidneo@gmail.com
