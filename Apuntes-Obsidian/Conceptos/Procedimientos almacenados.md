---
tags: [DSE, concepto, sql, tema3]
---
# Procedimientos almacenados

Un **procedimiento almacenado** (stored procedure) es una **orden con nombre que vive dentro de
SQL Server**. En vez de escribir el SQL desde C#, el [[Capa de Datos (DAO)|DAO]] le dice a SQL:
*"ejecuta tu receta `usp_Categoria_Insertar` con estos datos"*. (Tema 3)

## Ejemplos
```sql
-- Insertar (devuelve el Id nuevo)
CREATE PROCEDURE dbo.usp_Categoria_Insertar
    @Nombre NVARCHAR(60), @Descripcion NVARCHAR(150), @Estado BIT
AS
BEGIN
    INSERT INTO dbo.Categoria (Nombre, Descripcion, Estado)
    VALUES (@Nombre, @Descripcion, @Estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT);   -- el Id que SQL generó
END

-- Listar
CREATE PROCEDURE dbo.usp_Categoria_Listar
AS
BEGIN
    SELECT IdCategoria, Nombre, Descripcion, Estado FROM dbo.Categoria ORDER BY Nombre;
END
```

## SPs de edición de pedido (UPDATE / DELETE / SELECT por id)
Para poder **editar** un pedido ya guardado (cargar un pedido existente y guardarlo de nuevo),
se agregaron 3 SPs nuevos en `database/01_RestaurantDB.sql`. Sirven como ejemplo de los otros
tres "sabores" de SP además del Insertar/Listar de arriba:

```sql
-- 1) SELECT por id: trae la CABECERA con los Id crudos (IdMesa, IdEmpleado, IdCliente)
--    para poder reseleccionar los combos en el formulario al cargar.
CREATE PROCEDURE dbo.usp_Pedido_ObtenerPorId
    @IdPedido INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdPedido, Fecha, IdMesa, IdEmpleado, IdCliente, Situacion, Total
    FROM dbo.Pedido
    WHERE IdPedido = @IdPedido;
END
GO
-- 2) UPDATE: actualiza la cabecera. OJO: NO toca la Situacion (se preserva la que ya tenía).
CREATE PROCEDURE dbo.usp_Pedido_Actualizar
    @IdPedido INT, @IdMesa INT, @IdEmpleado INT, @IdCliente INT, @Total DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Pedido
       SET IdMesa = @IdMesa, IdEmpleado = @IdEmpleado, IdCliente = @IdCliente, Total = @Total
     WHERE IdPedido = @IdPedido;
END
GO
-- 3) DELETE real (no es baja lógica): borra TODO el detalle del pedido.
--    La estrategia al editar es "borrar y reinsertar" las líneas (ver nota abajo).
CREATE PROCEDURE dbo.usp_DetallePedido_EliminarPorPedido
    @IdPedido INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.DetallePedido WHERE IdPedido = @IdPedido;
END
```

> [!tip] Patrón "borrar y reinsertar el detalle"
> Al **actualizar** un pedido, el [[Capa de Datos (DAO)|DAO]] abre una
> [[Transacción (Commit y Rollback)|transacción]] y ejecuta en orden:
> `usp_Pedido_Actualizar` (cabecera) → `usp_DetallePedido_EliminarPorPedido` (borra el detalle viejo)
> → `usp_DetallePedido_Insertar` por cada línea nueva. Si algo falla, la transacción hace `ROLLBACK`
> y no queda un pedido a medias.

## ¿Por qué usarlos? (Tema 3)
1. 🔒 **Seguridad**: usan [[Parámetros e inyección SQL|parámetros]] → evitan inyección SQL.
2. ⚡ **Rendimiento**: están precompilados.
3. 🧹 **Orden**: la lógica de datos vive centralizada en la base.

## Baja lógica
El "Eliminar" **no borra**: hace `UPDATE ... SET Estado = 0`. Así no se rompen los registros
relacionados (FK). El dato solo se marca como inactivo.

## 🔗 Relaciones
- Viven en: [[Base de datos]]
- Los llama: [[Capa de Datos (DAO)]]
- Seguridad: [[Parámetros e inyección SQL]]
- Tema del curso: [[Temas del curso (T1-T6)]] (Tema 3)
- Volver al [[Índice]]
