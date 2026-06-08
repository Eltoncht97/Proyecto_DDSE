---
tags: [DSE, capa, entidades]
---
# Capa de Entidades

Proyecto `Restaurant.Entidades`. Son las **"cajas" 📦 que transportan los datos** por todas las capas.
No ejecutan lógica: solo guardan información. Aplica [[POO - Clase y Objeto|POO]].

## Idea clave
Cada entidad es el **espejo de una tabla** de la [[Base de datos]]: cada **propiedad** = una **columna**.

| Clase `Categoria` (C#) | Tabla `Categoria` (SQL) |
|---|---|
| `IdCategoria` (int) | `IdCategoria` (INT) |
| `Nombre` (string) | `Nombre` (NVARCHAR) |
| `Estado` (bool) | `Estado` (BIT) |

## Ejemplo
```csharp
public class Categoria
{
    public int IdCategoria { get; set; }   // propiedad (get=leer, set=escribir)
    public string Nombre { get; set; }
    public bool Estado { get; set; }

    public Categoria() { Estado = true; }  // constructor: valores por defecto
}
```

## Entidades del proyecto
Categoria, Plato, Mesa, Empleado, Cliente, Pedido, DetallePedido, Comprobante, Usuario.

> [!note] Propiedades calculadas
> Algunas entidades tienen datos que **no** están en la tabla, sino que se **calculan**.
> Ej.: `Empleado.NombreCompleto` = `Nombres + " " + Apellidos`.

## 🔗 Relaciones
- Base teórica: [[POO - Clase y Objeto]]
- Se llenan/leen en: [[Capa de Datos (DAO)]]
- Viajan dentro de: [[Arquitectura multicapa]] y [[Flujo de datos]]
- Reflejan tablas de: [[Base de datos]]
- Volver al [[Índice]]
