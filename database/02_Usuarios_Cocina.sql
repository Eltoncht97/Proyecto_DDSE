/* ============================================================================
   MIGRACIÓN: Mantenimiento de Usuarios + Estado de cocina por línea de pedido
   Aplica sobre una base RestaurantDB ya existente (idempotente).
   ============================================================================ */
USE RestaurantDB;
GO

/* ---------- 1. Nueva columna de estado de cocina en cada línea ---------- */
IF COL_LENGTH('dbo.DetallePedido', 'EstadoDetalle') IS NULL
    ALTER TABLE dbo.DetallePedido
        ADD EstadoDetalle NVARCHAR(20) NOT NULL
            CONSTRAINT DF_Detalle_Estado DEFAULT('Solicitado'); -- Solicitado / Servido
GO

/* ---------- 2. ObtenerDetalle ahora devuelve el estado de cocina ---------- */
CREATE OR ALTER PROCEDURE dbo.usp_Pedido_ObtenerDetalle
    @IdPedido INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT d.IdDetalle, d.IdPedido, d.IdPlato, p.Nombre AS Plato,
           d.Cantidad, d.PrecioUnitario, d.Subtotal, d.EstadoDetalle
    FROM dbo.DetallePedido d
    INNER JOIN dbo.Plato p ON p.IdPlato = d.IdPlato
    WHERE d.IdPedido = @IdPedido;
END
GO

/* ---------- 3. Cocina: cambiar estado de una línea ---------- */
CREATE OR ALTER PROCEDURE dbo.usp_DetallePedido_CambiarEstado
    @IdDetalle INT, @Estado NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.DetallePedido SET EstadoDetalle = @Estado WHERE IdDetalle = @IdDetalle;
END
GO

/* ---------- 4. Cocina: pedidos en preparación ---------- */
CREATE OR ALTER PROCEDURE dbo.usp_Pedido_ListarEnPreparacion
AS
BEGIN
    SET NOCOUNT ON;
    SELECT pe.IdPedido, pe.Fecha, m.Numero AS Mesa,
           (e.Nombres + ' ' + e.Apellidos) AS Mozo,
           ISNULL(c.Nombres, 'Varios') AS Cliente,
           pe.Situacion,
           SUM(CASE WHEN d.EstadoDetalle = 'Solicitado' THEN 1 ELSE 0 END) AS Pendientes,
           COUNT(d.IdDetalle) AS Items
    FROM dbo.Pedido pe
    INNER JOIN dbo.Mesa m         ON m.IdMesa = pe.IdMesa
    INNER JOIN dbo.Empleado e     ON e.IdEmpleado = pe.IdEmpleado
    LEFT  JOIN dbo.Cliente c      ON c.IdCliente = pe.IdCliente
    INNER JOIN dbo.DetallePedido d ON d.IdPedido = pe.IdPedido
    WHERE pe.Situacion NOT IN ('Pagado', 'Anulado')
    GROUP BY pe.IdPedido, pe.Fecha, m.Numero, e.Nombres, e.Apellidos, c.Nombres, pe.Situacion
    ORDER BY pe.Fecha;
END
GO

/* ---------- 5. Mantenimiento de Usuarios ---------- */
CREATE OR ALTER PROCEDURE dbo.usp_Usuario_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdUsuario, NombreUsuario, Clave, NombreCompleto, Rol, Estado
    FROM dbo.Usuario
    ORDER BY NombreUsuario;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_Usuario_Insertar
    @NombreUsuario NVARCHAR(40), @Clave NVARCHAR(40),
    @NombreCompleto NVARCHAR(80), @Rol NVARCHAR(20), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Usuario (NombreUsuario, Clave, NombreCompleto, Rol, Estado)
    VALUES (@NombreUsuario, @Clave, @NombreCompleto, @Rol, @Estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_Usuario_Actualizar
    @IdUsuario INT, @NombreUsuario NVARCHAR(40), @Clave NVARCHAR(40),
    @NombreCompleto NVARCHAR(80), @Rol NVARCHAR(20), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Usuario
       SET NombreUsuario = @NombreUsuario, Clave = @Clave,
           NombreCompleto = @NombreCompleto, Rol = @Rol, Estado = @Estado
     WHERE IdUsuario = @IdUsuario;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_Usuario_Eliminar
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Usuario SET Estado = 0 WHERE IdUsuario = @IdUsuario;
END
GO

/* ---------- 6. Usuarios de prueba para los nuevos roles ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE NombreUsuario = 'mozo')
    INSERT INTO dbo.Usuario (NombreUsuario, Clave, NombreCompleto, Rol, Estado)
    VALUES ('mozo', 'mozo123', 'Manuel Mozo Flores', 'Mozo', 1);
IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE NombreUsuario = 'cocinero')
    INSERT INTO dbo.Usuario (NombreUsuario, Clave, NombreCompleto, Rol, Estado)
    VALUES ('cocinero', 'cocina123', 'Luis Ramírez Díaz', 'Cocinero', 1);
GO

PRINT 'Migración de Usuarios + Cocina aplicada correctamente.';
GO
