---
tags: [DSE, capa, datos, adonet, tema3, tema4]
---
# Capa de Datos (DAO)

Proyecto `Restaurant.Datos`. Es **la única capa que habla con SQL Server** (el almacenero 📥).
Usa **ADO.NET** y llama a los [[Procedimientos almacenados]].

> **DAO** = *Data Access Object*. Su único trabajo: leer y escribir en la [[Base de datos]].

## La llave: `Conexion.cs`
Centraliza la [[Cadena de conexión]] para no repetirla en cada DAO.
```csharp
public static class Conexion
{
    public static string Cadena = "Data Source=.;Initial Catalog=RestaurantDB;Integrated Security=True";
    public static SqlConnection Obtener() => new SqlConnection(Cadena);
}
```

## LEER (modo conectado, Tema 3)
```csharp
using (SqlConnection cn = Conexion.Obtener())
{
    SqlCommand cmd = new SqlCommand("usp_Categoria_Listar", cn);
    cmd.CommandType = CommandType.StoredProcedure;
    cn.Open();
    using (SqlDataReader dr = cmd.ExecuteReader())
        while (dr.Read())
            lista.Add(new Categoria { Nombre = dr["Nombre"].ToString(), ... }); // fila → caja 📦
}
```

## ESCRIBIR (con parámetros)
```csharp
cmd.Parameters.AddWithValue("@Nombre", c.Nombre);   // ver [[Parámetros e inyección SQL]]
return Convert.ToInt32(cmd.ExecuteScalar());         // recibe el Id nuevo
```

## ¿Reader, Scalar o NonQuery?
| Método | Cuándo | Devuelve |
|---|---|---|
| `ExecuteReader()` | varias filas (Listar) | filas |
| `ExecuteScalar()` | un solo valor (el Id nuevo) | un valor |
| `ExecuteNonQuery()` | UPDATE/DELETE | nº de filas afectadas |

## Caso real: editar un pedido (`PedidoDAO`)
Registrar ya no es lo único: el pedido también se **carga** y se **edita**. Dos métodos nuevos lo resuelven.

### 1) Traer un pedido por su Id → `ObtenerPorId`
Lectura simple (modo conectado) que llena **solo la cabecera** en una caja [[Capa de Entidades|Pedido]]. Devuelve `null` si no existe (por eso `if (dr.Read())`, no `while`). Trae los **Id crudos** (`IdMesa`, `IdEmpleado`, `IdCliente`) para poder reseleccionarlos en los combos al editar.
```csharp
SqlCommand cmd = new SqlCommand("usp_Pedido_ObtenerPorId", cn);
cmd.Parameters.AddWithValue("@IdPedido", idPedido);
if (dr.Read())
    pedido = new Pedido { IdPedido = ..., IdMesa = ..., Situacion = ..., Total = ... };
```
> [!tip] `IdCliente` puede ser NULL en la BD. Se traduce con guarda:
> `dr["IdCliente"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["IdCliente"])`

### 2) Guardar los cambios → `Actualizar` (transacción)
El detalle no se "diferencia" línea por línea: se **borra entero y se reinserta**. Es más simple y queda consistente. Como son **3 operaciones que deben ir juntas**, van dentro de UNA [[Transacción (Commit y Rollback)]]: si una falla, `Rollback` deshace todo.

| Paso | SP | Método |
|---|---|---|
| 1. Actualizar cabecera | `usp_Pedido_Actualizar` | `ExecuteNonQuery()` |
| 2. Borrar TODO el detalle viejo | `usp_DetallePedido_EliminarPorPedido` | `ExecuteNonQuery()` |
| 3. Reinsertar cada línea | `usp_DetallePedido_Insertar` (en bucle) | `ExecuteNonQuery()` |

```csharp
cn.Open();
SqlTransaction tran = cn.BeginTransaction();   // los 3 comandos comparten cn + tran
try
{
    // 1) cabecera (NO toca Situacion: la preserva tal cual estaba)
    new SqlCommand("usp_Pedido_Actualizar", cn, tran) { ... }.ExecuteNonQuery();
    // 2) limpiar el detalle anterior
    new SqlCommand("usp_DetallePedido_EliminarPorPedido", cn, tran) { ... }.ExecuteNonQuery();
    // 3) volver a insertar el detalle nuevo
    foreach (DetallePedido det in pedido.Detalles)
        new SqlCommand("usp_DetallePedido_Insertar", cn, tran) { ... }.ExecuteNonQuery();
    tran.Commit();      // todo OK → confirmar
}
catch { tran.Rollback(); throw; }   // algo falló → deshacer todo
```
> [!info] Mismo patrón "borra-y-reinserta detalle dentro de transacción" que ya usa `Registrar`. La diferencia: `Registrar` hace `ExecuteScalar()` para recibir el `IdPedido` nuevo; `Actualizar` ya conoce el Id y por eso usa solo `ExecuteNonQuery()`.

> [!note] SPs nuevos en la BD para esto: `usp_Pedido_ObtenerPorId`, `usp_Pedido_Actualizar` y `usp_DetallePedido_EliminarPorPedido`. Ver [[Procedimientos almacenados]].

## 🔗 Relaciones
- Llama a: [[Procedimientos almacenados]] en la [[Base de datos]]
- Usa: [[ADO.NET conectado y desconectado]] · [[Parámetros e inyección SQL]] · [[Transacción (Commit y Rollback)]] · [[Cadena de conexión]]
- Llena/devuelve: [[Capa de Entidades]]
- La usa: [[Capa de Negocio (BLL)]]
- Volver al [[Índice]]
