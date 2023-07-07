# Proyecto de Fin de Unidad
|Proyecto|Gestión de Calificaciones|
|---|---|
| **Materia** | Modelos de Procesos de Desarrollo De Ingeníera de Software|
|**Universidad**|Universidad de las Fuerzas Armadas - ESPE|
|**Pais**|Ecuador|
|**Año**|2023|

_**Última fecha de modificación:** 7 de julio 2023_

# Problemática

Se desea desarrollar una aplicación de gestión de calificaciones de los alumnos para satisfacer las numerosas quejas de los profesores, por el uso del lápiz y papel. La aplicación deberá cubrir únicamente aquellos aspectos relacionados con dicho tema, y que se describen a continuación:

El profesor recibe las actas en blanco de las siguientes asignaturas que es responsable, en formato electrónico. El acta contiene los siguientes datos de la asignatura (titulación, campus, cursos académicos, denominación de la asignatura, convocatoria y grupo) y la lista de los alumnos matriculados (NIF, nombre y apellidos).

Las acciones que puede hacer el profesor son:

* Completar un acta con las notas de los alumnos.
* Añadir o borrar un alumno de un acta.
* Integrar las actas de varios grupos de una misma asignatura en una sola acta
* Permitir la consulta de la siguiente información de cualquier alumno seleccionado:
    * DNI, # de expediente, lista de asignaturas en las que esta matriculado el alumno (Código asignatura – nombre asignatura)
* Obtener una estadística de las calificaciones obtenidas por los alumnos en un determinado grupo de una asignatura. En esta estadística se tendrá para cada posible calificación:
    * Número de personas con esa calificación, porcentaje sobre los presentados, porcentaje sobre el total del grupo.
* Consultar el porcentaje de personas sobre el total del grupo que se ha presentado y el de los que no se han presentado.
* Poder visualizar un grafico indicativo del numero de personas que ha obtenido una calificación 0 - 0.99, 1 - 1.99, 2 - 2.99, 3 - 3.99, 4 - 4.99, 5 - 5.99, 6 - 6.99, 7 - 7.99, 8 - 8.99, 9 - 10; indicando la nota media obtenida por la clase.
* Disponer de una calculadora que permita realizar las operaciones de suma, resta, multiplicación, división. Esta calculadora se activará cuando se vayan a introducción las notas a algún alumno de forma que, una vez realizada la operación aritmética, pulsando un botón se vuelque el resultado en la casilla donde se están introduciendo las calificaciones redondeándose a dos cifras decimales.
* Permitir la importación y exportación de la lista de alumnos con sus calificaciones a un formato compatible con MS Excel.
* Imprimir las actas y lista provisional de calificaciones.

Ampliación extra, a la cual solo se podrá acceder quien se identifique inicialmente como administrador de la aplicación:

* Gestión ABMC (altas/bajas/modificaciones/consultas) de los datos de los alumnos y su matriculación en una asignatura y a un grupo.
* Gestión de asignaturas, teniendo en cuenta que una asignatura solo re puede dar en un único curso esta formado por los datos sobre el número máximo de alumno, número mínimo de créditos troncales y número mínimo de créditos optativos. Algunos de los datos que se van a poder consultar de una asignatura son el nombre, numero de créditos y cuatrimestre en el que se imparte.
* Gestión de titulaciones, teniendo en cuenta que una titulación solo se da en un campus determinado y los datos que se pueden consultar son el nombre, el numero de créditos o carga lectiva global, si es el 1ro o 2do ciclo.
* Gestión de grupos, en los que se puede consultar el número máximo de alumnos permitidos, si es un grupo de mañana, tarde o noche, y cuál es el código empleado para identificar el grupo.
* Consultar aquellos alumnos que no se pueden matricular y el motivo de ello.
* Consultar el historial académico de un alumno.


# Requisitos:

_(En proceso)_

---

### Documentación:
* Lenguajes: HTML, CSS, C#
* Base de datos: SQL Server
* Framework: ASP.NET, Entity Framework
* Diagramas: _(En proceso)_
  * Casos de uso
  * Secuencia
  * Clases
  * Entidades / Relación
