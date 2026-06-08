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

## 🔗 Relaciones
- Llama a: [[Procedimientos almacenados]] en la [[Base de datos]]
- Usa: [[ADO.NET conectado y desconectado]] · [[Parámetros e inyección SQL]] · [[Transacción (Commit y Rollback)]] · [[Cadena de conexión]]
- Llena/devuelve: [[Capa de Entidades]]
- La usa: [[Capa de Negocio (BLL)]]
- Volver al [[Índice]]
