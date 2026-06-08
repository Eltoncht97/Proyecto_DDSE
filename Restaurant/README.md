# Sistema de Gestión de Restaurante

Aplicación de escritorio **Windows Forms** en **C#** con **arquitectura multicapa** y base de
datos **SQL Server**, desarrollada para el curso **Desarrollo de Sistemas Empresariales (5402)** — Cibertec.

## Arquitectura (4 capas)
- **Restaurant.Entidades** — clases del dominio (POO).
- **Restaurant.Datos** — acceso a datos con ADO.NET y procedimientos almacenados.
- **Restaurant.Negocio** — reglas de negocio y validaciones (LINQ).
- **Restaurant.Presentacion** — formularios Windows Forms (proyecto de inicio).

## Requisitos
- Visual Studio 2019/2022 o superior (.NET Framework).
- Microsoft SQL Server.

## Puesta en marcha
1. Ejecutar el script de base de datos en SQL Server (crea `RestaurantDB`).
2. Ajustar la cadena de conexión en `Restaurant.Datos/Conexion.cs` (`Data Source`).
3. Abrir `Restaurant.sln`, establecer `Restaurant.Presentacion` como proyecto de inicio y ejecutar (F5).
4. Credenciales de prueba: `admin` / `admin123`.

## Módulos
Categorías, Platos, Mesas, Empleados, Clientes, Pedidos (comanda), Facturación y Reporte de ventas.
