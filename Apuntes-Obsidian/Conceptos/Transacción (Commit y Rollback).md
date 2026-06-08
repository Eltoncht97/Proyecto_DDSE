---
tags: [DSE, concepto, adonet, tema3]
---
# Transacción (Commit y Rollback)

Una **transacción** agrupa varias operaciones para que se cumplan **todas o ninguna**
(atomicidad). Se usa al registrar un **Pedido** (cabecera + detalle) en `PedidoDAO`. (Tema 3)

## El problema que resuelve
Un pedido inserta 1 fila en `Pedido` y N filas en `DetallePedido`. Si falla a la mitad, no
queremos un pedido **sin** sus platos. La transacción evita ese estado roto.

```csharp
SqlTransaction tran = cn.BeginTransaction();
try
{
    // 1) insertar cabecera (Pedido)  → obtiene idPedido
    // 2) insertar cada línea (DetallePedido)
    tran.Commit();      // ✅ todo OK → confirma
}
catch
{
    tran.Rollback();    // ❌ algo falló → deshace TODO
    throw;
}
```

## Palabras clave
- **Commit** = confirmar (guardar los cambios).
- **Rollback** = deshacer (volver al estado anterior).

## 🔗 Relaciones
- Se usa en: [[Capa de Datos (DAO)]] (`PedidoDAO.Registrar`)
- Lo dispara: [[Capa de Negocio (BLL)]] (`PedidoBLL`)
- Tema del curso: [[Temas del curso (T1-T6)]] (Tema 3)
- Volver al [[Índice]]
