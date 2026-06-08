---
tags: [DSE, concepto, adonet, tema3, tema4]
---
# ADO.NET conectado y desconectado

ADO.NET ofrece **dos formas** de traer datos. Ambas se usan en la [[Capa de Datos (DAO)]].

## Modo conectado (Tema 3) 🔌
Mantiene la conexión **abierta** mientras lee. Ideal para leer rápido fila por fila.
- `SqlConnection` → abre la puerta.
- `SqlCommand` → ejecuta el procedimiento.
- `SqlDataReader` → lee fila por fila (solo avance, solo lectura).

→ En el proyecto: `Listar()` devuelve una `List<Categoria>` (lista de cajas 📦).

## Modo desconectado (Tema 4) 📋
Trae **todo a memoria** y cierra la conexión. Ideal para llenar grillas.
- `SqlDataAdapter` → puente entre la BD y la memoria.
- `DataTable` / `DataSet` → tabla en memoria (una "mini BD" local).
- `DataView` → vista filtrada/ordenada sin alterar el original (`RowFilter`, `Sort`).

→ En el proyecto: `ListarTabla()` devuelve un `DataTable`; `FrmFacturacion` usa `DataView`
con `RowFilter` para mostrar solo pedidos pendientes.

```csharp
SqlDataAdapter da = new SqlDataAdapter(cmd);
da.Fill(dt);            // copia todas las filas al DataTable
```

## ¿Cuál usa el proyecto y para qué?
| Método del DAO | Modo | Devuelve | Uso |
|---|---|---|---|
| `Listar()` | conectado | `List<T>` 📦 | llenar ComboBox / objetos |
| `ListarTabla()` | desconectado | `DataTable` 📋 | llenar grillas (DataGridView) |

## 🔗 Relaciones
- Se implementa en: [[Capa de Datos (DAO)]]
- Tema del curso: [[Temas del curso (T1-T6)]] (Temas 3 y 4)
- Ver el recorrido: [[Flujo de datos]]
- Volver al [[Índice]]
