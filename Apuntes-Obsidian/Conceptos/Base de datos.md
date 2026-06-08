---
tags: [DSE, concepto, sql, basedatos]
---
# Base de datos (SQL Server)

La **despensa** 🏬 donde se guardan los datos. Script: `database/01_RestaurantDB.sql`.
Crea **2 cosas**: las **tablas** y los [[Procedimientos almacenados]].

## Tablas
Una tabla = filas (registros) y columnas (campos).

```sql
CREATE TABLE dbo.Categoria
(
    IdCategoria  INT IDENTITY(1,1) NOT NULL,   -- se autonumera 1,2,3...
    Nombre       NVARCHAR(60)      NOT NULL,    -- obligatorio
    Estado       BIT               NOT NULL DEFAULT(1),
    CONSTRAINT PK_Categoria PRIMARY KEY (IdCategoria)
);
```

## Conceptos clave
| Término | Qué es |
|---|---|
| **PRIMARY KEY (PK)** | identifica sin repetir cada fila (como el DNI) |
| **IDENTITY** | SQL pone el número solo (1,2,3...) |
| **FOREIGN KEY (FK)** | une una tabla con otra (ej. `Plato.IdCategoria` → `Categoria`) |
| **NOT NULL** | campo obligatorio |

🔗 Las **FK** arman el modelo relacional: un `Plato` pertenece a una `Categoria`; un `Pedido`
tiene muchos `DetallePedido`. Cada tabla se refleja en una [[Capa de Entidades|entidad]].

## 🔗 Relaciones
- Se accede mediante: [[Capa de Datos (DAO)]]
- Sus órdenes: [[Procedimientos almacenados]]
- Cada tabla = una [[Capa de Entidades|entidad]]
- Volver al [[Índice]]
