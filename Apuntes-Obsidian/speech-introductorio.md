# Discurso Introductorio — Sistema de Gestión de Restaurante

> Proyecto del curso **Desarrollo de Sistemas Empresariales (5402)** — Cibertec

---

## Apertura

> Buenos días/tardes. Muchas gracias por su atención. A continuación, tengo el agrado de presentarles nuestro proyecto: el **Sistema de Gestión de Restaurante**, desarrollado en el marco del curso de Desarrollo de Sistemas Empresariales.

## El problema que resolvemos

> Hoy en día, muchos restaurantes siguen administrando sus operaciones de forma manual: anotan los pedidos en papel, calculan las cuentas a mano y llevan el control de mesas, platos e inventario en cuadernos o en hojas sueltas. Esto genera problemas muy comunes: pedidos que se pierden o se confunden, demoras en la atención, errores en las cuentas, falta de control sobre las ventas y, sobre todo, la imposibilidad de saber con claridad cómo va el negocio.

## El objetivo del proyecto

> Nuestro objetivo fue diseñar e implementar una solución de software que **centralice y automatice toda la operación de un restaurante**, desde que el cliente hace su pedido hasta la emisión de la factura y el reporte de ventas. Buscamos reducir los errores, agilizar la atención y, al mismo tiempo, darle al administrador información confiable para tomar mejores decisiones.

## Qué ofrece el sistema

> Para lograrlo, desarrollamos una aplicación de escritorio que integra los módulos clave de un restaurante:
> - Gestión de **categorías y platos** del menú,
> - Administración de **mesas, empleados y clientes**,
> - Registro de **pedidos o comandas**,
> - **Facturación** automática, y
> - **Reportes de ventas** para el control del negocio.
>
> Todo esto protegido con un acceso mediante usuario y contraseña.

## La parte técnica

> A nivel técnico, el sistema fue construido en **C# con Windows Forms** y una base de datos en **SQL Server**. Lo más importante es que aplicamos una **arquitectura multicapa**, separando el sistema en cuatro capas —entidades, acceso a datos, lógica de negocio y presentación—. Esto hace que la aplicación sea más ordenada, fácil de mantener y escalable, que son justamente las buenas prácticas que se esperan en el desarrollo de sistemas empresariales.

## Metodología de trabajo y organización del equipo

> Para desarrollar este sistema trabajamos de forma **colaborativa y organizada**, aplicando una metodología de trabajo dividida en etapas y aprovechando que nuestra arquitectura está separada en capas. Esto nos permitió que cada integrante se especializara en una parte del sistema y, a la vez, que todo el equipo trabajara en paralelo de manera ordenada.
>
> Comenzamos con una etapa de **análisis y diseño en conjunto**, donde definimos los requerimientos, el modelo de la base de datos y los módulos del sistema. Luego repartimos las responsabilidades entre los **4 integrantes del equipo**, de la siguiente manera:
>
> - **Integrante 1 — Capa de Entidades y Base de Datos:** se encargó del diseño del modelo de datos en SQL Server, la creación de tablas y procedimientos almacenados, y de las clases del dominio que representan a los objetos del negocio (platos, mesas, clientes, pedidos, etc.).
>
> - **Integrante 2 — Capa de Acceso a Datos:** desarrolló la conexión con la base de datos mediante ADO.NET y todos los métodos que permiten consultar, registrar, actualizar y eliminar la información.
>
> - **Integrante 3 — Capa de Negocio:** implementó las reglas y validaciones del sistema, asegurando que la información sea consistente y correcta antes de guardarse, utilizando LINQ para el procesamiento de datos.
>
> - **Integrante 4 — Capa de Presentación:** diseñó y programó los formularios de Windows Forms, es decir, la interfaz con la que interactúa el usuario, cuidando que sea clara, intuitiva y fácil de usar.
>
> Finalmente, realizamos una etapa de **integración y pruebas en equipo**, donde unimos todas las capas, verificamos el funcionamiento completo de cada módulo y corregimos los detalles encontrados. Gracias a esta organización y comunicación constante, logramos un sistema funcional, ordenado y mantenible.

## Cierre

> En resumen, este proyecto no solo automatiza las tareas diarias de un restaurante, sino que demuestra cómo aplicar correctamente los conceptos de programación orientada a objetos, bases de datos y arquitectura de software en una solución real. A continuación, les mostraremos en detalle cómo funciona. Muchas gracias.
