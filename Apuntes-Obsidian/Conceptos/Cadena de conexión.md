---
tags: [DSE, concepto, conexion]
---
# Cadena de conexión

Es el "texto" que le dice a la app **a qué SQL Server conectarse**. La usa `Conexion.cs` en la
[[Capa de Datos (DAO)]].

```
Data Source=.;Initial Catalog=RestaurantDB;Integrated Security=True
```

| Parte | Significado |
|---|---|
| `Data Source` | el servidor SQL (`.` = instancia local por defecto) |
| `Initial Catalog` | la base de datos (`RestaurantDB`) |
| `Integrated Security=True` | entra con el usuario de **Windows** (sin user/clave de SQL) |

## ¿Dónde se escribe? Dos estilos
| Estilo | Dónde | Nota |
|---|---|---|
| **Del curso (PDF)** ✅ usado | directo en `Conexion.cs` | así lo muestran los PDF (Tema 5) |
| Profesional | en `App.config` (`ConfigurationManager`) | centralizado; no es requisito del curso |

> [!info] En este proyecto
> La cadena está **escrita directamente en `Conexion.cs`**, para coincidir con los PDF del curso.

## 🔗 Relaciones
- La lee: [[Capa de Datos (DAO)]] (`Conexion.cs`)
- Llega a: [[Base de datos]]
- Volver al [[Índice]]
