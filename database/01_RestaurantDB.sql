
IF DB_ID('RestaurantDB') IS NULL
    CREATE DATABASE RestaurantDB;
GO

USE RestaurantDB;
GO

/* ----------------------------------------------------------------------------
   1. ELIMINACIÓN ORDENADA (para poder re-ejecutar el script)
   ---------------------------------------------------------------------------- */
IF OBJECT_ID('dbo.DetallePedido', 'U') IS NOT NULL DROP TABLE dbo.DetallePedido;
IF OBJECT_ID('dbo.Comprobante',   'U') IS NOT NULL DROP TABLE dbo.Comprobante;
IF OBJECT_ID('dbo.Pedido',        'U') IS NOT NULL DROP TABLE dbo.Pedido;
IF OBJECT_ID('dbo.Plato',         'U') IS NOT NULL DROP TABLE dbo.Plato;
IF OBJECT_ID('dbo.Categoria',     'U') IS NOT NULL DROP TABLE dbo.Categoria;
IF OBJECT_ID('dbo.Mesa',          'U') IS NOT NULL DROP TABLE dbo.Mesa;
IF OBJECT_ID('dbo.Empleado',      'U') IS NOT NULL DROP TABLE dbo.Empleado;
IF OBJECT_ID('dbo.Cliente',       'U') IS NOT NULL DROP TABLE dbo.Cliente;
IF OBJECT_ID('dbo.Usuario',       'U') IS NOT NULL DROP TABLE dbo.Usuario;
GO

/* ----------------------------------------------------------------------------
   2. TABLAS
   ---------------------------------------------------------------------------- */
CREATE TABLE dbo.Categoria
(
    IdCategoria  INT IDENTITY(1,1) NOT NULL,
    Nombre       NVARCHAR(60)      NOT NULL,
    Descripcion  NVARCHAR(150)     NULL,
    Estado       BIT               NOT NULL CONSTRAINT DF_Categoria_Estado DEFAULT(1),
    CONSTRAINT PK_Categoria PRIMARY KEY (IdCategoria)
);
GO

CREATE TABLE dbo.Plato
(
    IdPlato      INT IDENTITY(1,1) NOT NULL,
    IdCategoria  INT               NOT NULL,
    Nombre       NVARCHAR(80)      NOT NULL,
    Descripcion  NVARCHAR(200)     NULL,
    Precio       DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Plato_Precio DEFAULT(0),
    Disponible   BIT               NOT NULL CONSTRAINT DF_Plato_Disponible DEFAULT(1),
    Estado       BIT               NOT NULL CONSTRAINT DF_Plato_Estado DEFAULT(1),
    CONSTRAINT PK_Plato PRIMARY KEY (IdPlato),
    CONSTRAINT FK_Plato_Categoria FOREIGN KEY (IdCategoria) REFERENCES dbo.Categoria(IdCategoria)
);
GO

CREATE TABLE dbo.Mesa
(
    IdMesa       INT IDENTITY(1,1) NOT NULL,
    Numero       INT               NOT NULL,
    Capacidad    INT               NOT NULL CONSTRAINT DF_Mesa_Capacidad DEFAULT(4),
    Ubicacion    NVARCHAR(60)      NULL,
    Situacion    NVARCHAR(20)      NOT NULL CONSTRAINT DF_Mesa_Situacion DEFAULT('Libre'), -- Libre / Ocupada / Reservada
    Estado       BIT               NOT NULL CONSTRAINT DF_Mesa_Estado DEFAULT(1),
    CONSTRAINT PK_Mesa PRIMARY KEY (IdMesa),
    CONSTRAINT UQ_Mesa_Numero UNIQUE (Numero)
);
GO

CREATE TABLE dbo.Empleado
(
    IdEmpleado   INT IDENTITY(1,1) NOT NULL,
    Nombres      NVARCHAR(60)      NOT NULL,
    Apellidos    NVARCHAR(60)      NOT NULL,
    Dni          NVARCHAR(8)       NOT NULL,
    Cargo        NVARCHAR(40)      NOT NULL CONSTRAINT DF_Empleado_Cargo DEFAULT('Mozo'), -- Mozo / Cajero / Cocinero / Administrador
    Telefono     NVARCHAR(15)      NULL,
    Estado       BIT               NOT NULL CONSTRAINT DF_Empleado_Estado DEFAULT(1),
    CONSTRAINT PK_Empleado PRIMARY KEY (IdEmpleado),
    CONSTRAINT UQ_Empleado_Dni UNIQUE (Dni)
);
GO

CREATE TABLE dbo.Cliente
(
    IdCliente    INT IDENTITY(1,1) NOT NULL,
    Nombres      NVARCHAR(60)      NOT NULL,
    Apellidos    NVARCHAR(60)      NULL,
    Documento    NVARCHAR(11)      NULL,  -- DNI (8) o RUC (11)
    Telefono     NVARCHAR(15)      NULL,
    Correo       NVARCHAR(80)      NULL,
    Direccion    NVARCHAR(150)     NULL,
    Estado       BIT               NOT NULL CONSTRAINT DF_Cliente_Estado DEFAULT(1),
    CONSTRAINT PK_Cliente PRIMARY KEY (IdCliente)
);
GO

CREATE TABLE dbo.Pedido
(
    IdPedido     INT IDENTITY(1,1) NOT NULL,
    Fecha        DATETIME          NOT NULL CONSTRAINT DF_Pedido_Fecha DEFAULT(GETDATE()),
    IdMesa       INT               NOT NULL,
    IdEmpleado   INT               NOT NULL,  -- Mozo que atiende
    IdCliente    INT               NULL,
    Situacion    NVARCHAR(20)      NOT NULL CONSTRAINT DF_Pedido_Situacion DEFAULT('Pendiente'), -- Pendiente / Atendido / Pagado / Anulado
    Total        DECIMAL(10,2)     NOT NULL CONSTRAINT DF_Pedido_Total DEFAULT(0),
    CONSTRAINT PK_Pedido PRIMARY KEY (IdPedido),
    CONSTRAINT FK_Pedido_Mesa     FOREIGN KEY (IdMesa)     REFERENCES dbo.Mesa(IdMesa),
    CONSTRAINT FK_Pedido_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleado(IdEmpleado),
    CONSTRAINT FK_Pedido_Cliente  FOREIGN KEY (IdCliente)  REFERENCES dbo.Cliente(IdCliente)
);
GO

CREATE TABLE dbo.DetallePedido
(
    IdDetalle      INT IDENTITY(1,1) NOT NULL,
    IdPedido       INT               NOT NULL,
    IdPlato        INT               NOT NULL,
    Cantidad       INT               NOT NULL CONSTRAINT DF_Detalle_Cantidad DEFAULT(1),
    PrecioUnitario DECIMAL(10,2)     NOT NULL,
    EstadoDetalle  NVARCHAR(20)      NOT NULL CONSTRAINT DF_Detalle_Estado DEFAULT('Solicitado'), -- Solicitado / Servido
    Subtotal       AS (Cantidad * PrecioUnitario) PERSISTED,
    CONSTRAINT PK_DetallePedido PRIMARY KEY (IdDetalle),
    CONSTRAINT FK_Detalle_Pedido FOREIGN KEY (IdPedido) REFERENCES dbo.Pedido(IdPedido),
    CONSTRAINT FK_Detalle_Plato  FOREIGN KEY (IdPlato)  REFERENCES dbo.Plato(IdPlato)
);
GO

CREATE TABLE dbo.Comprobante
(
    IdComprobante INT IDENTITY(1,1) NOT NULL,
    IdPedido      INT               NOT NULL,
    Tipo          NVARCHAR(10)      NOT NULL CONSTRAINT DF_Comp_Tipo DEFAULT('Boleta'), -- Boleta / Factura
    Serie         NVARCHAR(6)       NOT NULL CONSTRAINT DF_Comp_Serie DEFAULT('B001'),
    Numero        INT               NOT NULL,
    Fecha         DATETIME          NOT NULL CONSTRAINT DF_Comp_Fecha DEFAULT(GETDATE()),
    SubTotal      DECIMAL(10,2)     NOT NULL,
    Igv           DECIMAL(10,2)     NOT NULL,
    Total         DECIMAL(10,2)     NOT NULL,
    CONSTRAINT PK_Comprobante PRIMARY KEY (IdComprobante),
    CONSTRAINT FK_Comprobante_Pedido FOREIGN KEY (IdPedido) REFERENCES dbo.Pedido(IdPedido)
);
GO

CREATE TABLE dbo.Usuario
(
    IdUsuario    INT IDENTITY(1,1) NOT NULL,
    NombreUsuario NVARCHAR(40)     NOT NULL,
    Clave        NVARCHAR(40)      NOT NULL,
    NombreCompleto NVARCHAR(80)    NOT NULL,
    Rol          NVARCHAR(20)      NOT NULL CONSTRAINT DF_Usuario_Rol DEFAULT('Administrador'),
    Estado       BIT               NOT NULL CONSTRAINT DF_Usuario_Estado DEFAULT(1),
    CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario),
    CONSTRAINT UQ_Usuario_Nombre UNIQUE (NombreUsuario)
);
GO

/* ============================================================================
   3. PROCEDIMIENTOS ALMACENADOS  (Tema 3: parámetros, seguridad anti inyección)
   ============================================================================ */

/* ---------- CATEGORIA ---------- */
GO
CREATE PROCEDURE dbo.usp_Categoria_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM dbo.Categoria
    ORDER BY Nombre;
END
GO
CREATE PROCEDURE dbo.usp_Categoria_Insertar
    @Nombre NVARCHAR(60), @Descripcion NVARCHAR(150), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Categoria (Nombre, Descripcion, Estado)
    VALUES (@Nombre, @Descripcion, @Estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO
CREATE PROCEDURE dbo.usp_Categoria_Actualizar
    @IdCategoria INT, @Nombre NVARCHAR(60), @Descripcion NVARCHAR(150), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Categoria
       SET Nombre = @Nombre, Descripcion = @Descripcion, Estado = @Estado
     WHERE IdCategoria = @IdCategoria;
END
GO
CREATE PROCEDURE dbo.usp_Categoria_Eliminar
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Baja lógica para conservar la integridad referencial
    UPDATE dbo.Categoria SET Estado = 0 WHERE IdCategoria = @IdCategoria;
END
GO

/* ---------- PLATO ---------- */
GO
CREATE PROCEDURE dbo.usp_Plato_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.IdPlato, p.IdCategoria, c.Nombre AS Categoria, p.Nombre, p.Descripcion,
           p.Precio, p.Disponible, p.Estado
    FROM dbo.Plato p
    INNER JOIN dbo.Categoria c ON c.IdCategoria = p.IdCategoria
    ORDER BY p.Nombre;
END
GO
CREATE PROCEDURE dbo.usp_Plato_Insertar
    @IdCategoria INT, @Nombre NVARCHAR(80), @Descripcion NVARCHAR(200),
    @Precio DECIMAL(10,2), @Disponible BIT, @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Plato (IdCategoria, Nombre, Descripcion, Precio, Disponible, Estado)
    VALUES (@IdCategoria, @Nombre, @Descripcion, @Precio, @Disponible, @Estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO
CREATE PROCEDURE dbo.usp_Plato_Actualizar
    @IdPlato INT, @IdCategoria INT, @Nombre NVARCHAR(80), @Descripcion NVARCHAR(200),
    @Precio DECIMAL(10,2), @Disponible BIT, @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Plato
       SET IdCategoria = @IdCategoria, Nombre = @Nombre, Descripcion = @Descripcion,
           Precio = @Precio, Disponible = @Disponible, Estado = @Estado
     WHERE IdPlato = @IdPlato;
END
GO
CREATE PROCEDURE dbo.usp_Plato_Eliminar
    @IdPlato INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Plato SET Estado = 0 WHERE IdPlato = @IdPlato;
END
GO

/* ---------- MESA ---------- */
GO
CREATE PROCEDURE dbo.usp_Mesa_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdMesa, Numero, Capacidad, Ubicacion, Situacion, Estado
    FROM dbo.Mesa ORDER BY Numero;
END
GO
CREATE PROCEDURE dbo.usp_Mesa_Insertar
    @Numero INT, @Capacidad INT, @Ubicacion NVARCHAR(60), @Situacion NVARCHAR(20), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Mesa (Numero, Capacidad, Ubicacion, Situacion, Estado)
    VALUES (@Numero, @Capacidad, @Ubicacion, @Situacion, @Estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO
CREATE PROCEDURE dbo.usp_Mesa_Actualizar
    @IdMesa INT, @Numero INT, @Capacidad INT, @Ubicacion NVARCHAR(60), @Situacion NVARCHAR(20), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Mesa
       SET Numero = @Numero, Capacidad = @Capacidad, Ubicacion = @Ubicacion,
           Situacion = @Situacion, Estado = @Estado
     WHERE IdMesa = @IdMesa;
END
GO
CREATE PROCEDURE dbo.usp_Mesa_Eliminar
    @IdMesa INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Mesa SET Estado = 0 WHERE IdMesa = @IdMesa;
END
GO

/* ---------- EMPLEADO ---------- */
GO
CREATE PROCEDURE dbo.usp_Empleado_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdEmpleado, Nombres, Apellidos, Dni, Cargo, Telefono, Estado
    FROM dbo.Empleado ORDER BY Apellidos, Nombres;
END
GO
CREATE PROCEDURE dbo.usp_Empleado_Insertar
    @Nombres NVARCHAR(60), @Apellidos NVARCHAR(60), @Dni NVARCHAR(8),
    @Cargo NVARCHAR(40), @Telefono NVARCHAR(15), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Empleado (Nombres, Apellidos, Dni, Cargo, Telefono, Estado)
    VALUES (@Nombres, @Apellidos, @Dni, @Cargo, @Telefono, @Estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO
CREATE PROCEDURE dbo.usp_Empleado_Actualizar
    @IdEmpleado INT, @Nombres NVARCHAR(60), @Apellidos NVARCHAR(60), @Dni NVARCHAR(8),
    @Cargo NVARCHAR(40), @Telefono NVARCHAR(15), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Empleado
       SET Nombres = @Nombres, Apellidos = @Apellidos, Dni = @Dni,
           Cargo = @Cargo, Telefono = @Telefono, Estado = @Estado
     WHERE IdEmpleado = @IdEmpleado;
END
GO
CREATE PROCEDURE dbo.usp_Empleado_Eliminar
    @IdEmpleado INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Empleado SET Estado = 0 WHERE IdEmpleado = @IdEmpleado;
END
GO

/* ---------- CLIENTE ---------- */
GO
CREATE PROCEDURE dbo.usp_Cliente_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdCliente, Nombres, Apellidos, Documento, Telefono, Correo, Direccion, Estado
    FROM dbo.Cliente ORDER BY Nombres;
END
GO
CREATE PROCEDURE dbo.usp_Cliente_Insertar
    @Nombres NVARCHAR(60), @Apellidos NVARCHAR(60), @Documento NVARCHAR(11),
    @Telefono NVARCHAR(15), @Correo NVARCHAR(80), @Direccion NVARCHAR(150), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Cliente (Nombres, Apellidos, Documento, Telefono, Correo, Direccion, Estado)
    VALUES (@Nombres, @Apellidos, @Documento, @Telefono, @Correo, @Direccion, @Estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO
CREATE PROCEDURE dbo.usp_Cliente_Actualizar
    @IdCliente INT, @Nombres NVARCHAR(60), @Apellidos NVARCHAR(60), @Documento NVARCHAR(11),
    @Telefono NVARCHAR(15), @Correo NVARCHAR(80), @Direccion NVARCHAR(150), @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Cliente
       SET Nombres = @Nombres, Apellidos = @Apellidos, Documento = @Documento,
           Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion, Estado = @Estado
     WHERE IdCliente = @IdCliente;
END
GO
CREATE PROCEDURE dbo.usp_Cliente_Eliminar
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Cliente SET Estado = 0 WHERE IdCliente = @IdCliente;
END
GO

/* ---------- PEDIDO  (Tema 3: SqlTransaction cabecera + detalle desde C#) ---------- */
GO
CREATE PROCEDURE dbo.usp_Pedido_Insertar
    @Fecha DATETIME, @IdMesa INT, @IdEmpleado INT, @IdCliente INT,
    @Situacion NVARCHAR(20), @Total DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Pedido (Fecha, IdMesa, IdEmpleado, IdCliente, Situacion, Total)
    VALUES (@Fecha, @IdMesa, @IdEmpleado, @IdCliente, @Situacion, @Total);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO
CREATE PROCEDURE dbo.usp_DetallePedido_Insertar
    @IdPedido INT, @IdPlato INT, @Cantidad INT, @PrecioUnitario DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.DetallePedido (IdPedido, IdPlato, Cantidad, PrecioUnitario)
    VALUES (@IdPedido, @IdPlato, @Cantidad, @PrecioUnitario);
END
GO
CREATE PROCEDURE dbo.usp_Pedido_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT pe.IdPedido, pe.Fecha, m.Numero AS Mesa,
           (e.Nombres + ' ' + e.Apellidos) AS Mozo,
           ISNULL(c.Nombres, 'Varios') AS Cliente,
           pe.Situacion, pe.Total
    FROM dbo.Pedido pe
    INNER JOIN dbo.Mesa m     ON m.IdMesa = pe.IdMesa
    INNER JOIN dbo.Empleado e ON e.IdEmpleado = pe.IdEmpleado
    LEFT  JOIN dbo.Cliente c  ON c.IdCliente = pe.IdCliente
    ORDER BY pe.Fecha DESC;
END
GO
CREATE PROCEDURE dbo.usp_Pedido_ObtenerDetalle
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
CREATE PROCEDURE dbo.usp_Pedido_CambiarSituacion
    @IdPedido INT, @Situacion NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Pedido SET Situacion = @Situacion WHERE IdPedido = @IdPedido;
END
GO
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
CREATE PROCEDURE dbo.usp_DetallePedido_EliminarPorPedido
    @IdPedido INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.DetallePedido WHERE IdPedido = @IdPedido;
END
GO

/* ---------- COCINA (estado de cada línea del pedido) ---------- */
GO
CREATE PROCEDURE dbo.usp_DetallePedido_CambiarEstado
    @IdDetalle INT, @Estado NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.DetallePedido SET EstadoDetalle = @Estado WHERE IdDetalle = @IdDetalle;
END
GO
CREATE PROCEDURE dbo.usp_Pedido_ListarEnPreparacion
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

/* ---------- COMPROBANTE / FACTURACION ---------- */
GO
CREATE PROCEDURE dbo.usp_Comprobante_Insertar
    @IdPedido INT, @Tipo NVARCHAR(10), @Serie NVARCHAR(6),
    @SubTotal DECIMAL(10,2), @Igv DECIMAL(10,2), @Total DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Numero INT;
    SELECT @Numero = ISNULL(MAX(Numero), 0) + 1 FROM dbo.Comprobante WHERE Serie = @Serie;

    INSERT INTO dbo.Comprobante (IdPedido, Tipo, Serie, Numero, Fecha, SubTotal, Igv, Total)
    VALUES (@IdPedido, @Tipo, @Serie, @Numero, GETDATE(), @SubTotal, @Igv, @Total);

    UPDATE dbo.Pedido SET Situacion = 'Pagado' WHERE IdPedido = @IdPedido;

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO

/* ---------- LOGIN ---------- */
GO
CREATE PROCEDURE dbo.usp_Usuario_Validar
    @NombreUsuario NVARCHAR(40), @Clave NVARCHAR(40)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdUsuario, NombreUsuario, NombreCompleto, Rol, Estado
    FROM dbo.Usuario
    WHERE NombreUsuario = @NombreUsuario AND Clave = @Clave AND Estado = 1;
END
GO

/* ---------- USUARIOS (mantenimiento) ---------- */
GO
CREATE PROCEDURE dbo.usp_Usuario_Listar
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdUsuario, NombreUsuario, Clave, NombreCompleto, Rol, Estado
    FROM dbo.Usuario
    ORDER BY NombreUsuario;
END
GO
CREATE PROCEDURE dbo.usp_Usuario_Insertar
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
CREATE PROCEDURE dbo.usp_Usuario_Actualizar
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
CREATE PROCEDURE dbo.usp_Usuario_Eliminar
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Usuario SET Estado = 0 WHERE IdUsuario = @IdUsuario;
END
GO

/* ---------- REPORTE DE VENTAS  (Tema 6: origen de datos del ReportViewer) ---------- */
GO
CREATE PROCEDURE dbo.usp_Reporte_VentasPorFecha
    @FechaInicio DATE, @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT  c.Fecha,
            c.Serie + '-' + RIGHT('000000' + CAST(c.Numero AS VARCHAR(6)), 6) AS Comprobante,
            c.Tipo,
            m.Numero AS Mesa,
            (e.Nombres + ' ' + e.Apellidos) AS Mozo,
            ISNULL(cl.Nombres, 'Varios') AS Cliente,
            c.SubTotal, c.Igv, c.Total
    FROM dbo.Comprobante c
    INNER JOIN dbo.Pedido pe  ON pe.IdPedido = c.IdPedido
    INNER JOIN dbo.Mesa m     ON m.IdMesa = pe.IdMesa
    INNER JOIN dbo.Empleado e ON e.IdEmpleado = pe.IdEmpleado
    LEFT  JOIN dbo.Cliente cl ON cl.IdCliente = pe.IdCliente
    WHERE CAST(c.Fecha AS DATE) BETWEEN @FechaInicio AND @FechaFin
    ORDER BY c.Fecha;
END
GO

/* ---------- REPORTE: PLATOS MÁS VENDIDOS ---------- */
GO
CREATE PROCEDURE dbo.usp_Reporte_PlatosMasVendidos
    @FechaInicio DATE, @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT  p.Nombre AS Plato,
            cat.Nombre AS Categoria,
            SUM(dp.Cantidad) AS TotalVendido,
            p.Precio AS PrecioUnit,
            SUM(dp.Subtotal) AS TotalIngreso
    FROM dbo.DetallePedido dp
    INNER JOIN dbo.Plato p       ON p.IdPlato = dp.IdPlato
    INNER JOIN dbo.Categoria cat ON cat.IdCategoria = p.IdCategoria
    INNER JOIN dbo.Pedido pe     ON pe.IdPedido = dp.IdPedido
    WHERE CAST(pe.Fecha AS DATE) BETWEEN @FechaInicio AND @FechaFin
      AND pe.Situacion <> 'Anulado'
    GROUP BY p.Nombre, cat.Nombre, p.Precio
    ORDER BY TotalVendido DESC;
END
GO

/* ---------- REPORTE: VENTAS POR EMPLEADO ---------- */
GO
CREATE PROCEDURE dbo.usp_Reporte_VentasPorEmpleado
    @FechaInicio DATE, @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT  (e.Nombres + ' ' + e.Apellidos) AS Empleado,
            e.Cargo,
            COUNT(DISTINCT pe.IdPedido) AS TotalPedidos,
            SUM(c.Total) AS TotalVentas
    FROM dbo.Comprobante c
    INNER JOIN dbo.Pedido pe  ON pe.IdPedido = c.IdPedido
    INNER JOIN dbo.Empleado e ON e.IdEmpleado = pe.IdEmpleado
    WHERE CAST(c.Fecha AS DATE) BETWEEN @FechaInicio AND @FechaFin
    GROUP BY e.Nombres, e.Apellidos, e.Cargo
    ORDER BY TotalVentas DESC;
END
GO

/* ---------- REPORTE: CLIENTES ---------- */
GO
CREATE PROCEDURE dbo.usp_Reporte_Clientes
    @FechaInicio DATE, @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT  (cl.Nombres + ' ' + cl.Apellidos) AS Cliente,
            cl.Documento,
            COUNT(DISTINCT pe.IdPedido) AS TotalVisitas,
            SUM(c.Total) AS TotalGastado,
            MAX(c.Fecha) AS UltimaVisita
    FROM dbo.Cliente cl
    INNER JOIN dbo.Pedido pe     ON pe.IdCliente = cl.IdCliente
    INNER JOIN dbo.Comprobante c ON c.IdPedido = pe.IdPedido
    WHERE CAST(c.Fecha AS DATE) BETWEEN @FechaInicio AND @FechaFin
    GROUP BY cl.Nombres, cl.Apellidos, cl.Documento
    ORDER BY TotalGastado DESC;
END
GO

/* ============================================================================
   4. DATOS DE PRUEBA
   ============================================================================ */
INSERT INTO dbo.Usuario (NombreUsuario, Clave, NombreCompleto, Rol, Estado) VALUES
('admin', 'admin123', 'Administrador del Sistema', 'Administrador', 1),
('cajero', 'cajero123', 'Carlos Cajero', 'Cajero', 1),
('mozo', 'mozo123', 'Manuel Mozo Flores', 'Mozo', 1),
('cocinero', 'cocina123', 'Luis Ramírez Díaz', 'Cocinero', 1);

INSERT INTO dbo.Categoria (Nombre, Descripcion, Estado) VALUES
('Entradas',        'Platos de entrada y piqueos', 1),
('Platos de fondo', 'Platos principales',          1),
('Bebidas',         'Bebidas frías y calientes',   1),
('Postres',         'Postres y dulces',            1);

INSERT INTO dbo.Plato (IdCategoria, Nombre, Descripcion, Precio, Disponible, Estado) VALUES
(1, 'Causa Limeña',          'Causa rellena de pollo',          18.00, 1, 1),
(1, 'Anticuchos',            'Brochetas de corazón (2 unid.)',  22.00, 1, 1),
(2, 'Lomo Saltado',          'Clásico lomo saltado con papas',  34.00, 1, 1),
(2, 'Ají de Gallina',        'Ají de gallina con arroz',        28.00, 1, 1),
(2, 'Arroz con Mariscos',    'Arroz con mariscos frescos',      38.00, 1, 1),
(3, 'Chicha Morada (jarra)', 'Jarra 1 litro',                   12.00, 1, 1),
(3, 'Inca Kola (personal)',  'Botella 500 ml',                   5.00, 1, 1),
(4, 'Suspiro a la Limeña',   'Postre tradicional',              14.00, 1, 1),
(4, 'Mazamorra Morada',      'Porción individual',              10.00, 1, 1);

INSERT INTO dbo.Mesa (Numero, Capacidad, Ubicacion, Situacion, Estado) VALUES
(1, 4, 'Salón principal', 'Libre', 1),
(2, 4, 'Salón principal', 'Libre', 1),
(3, 6, 'Terraza',         'Libre', 1),
(4, 2, 'Barra',           'Libre', 1),
(5, 8, 'Salón VIP',       'Libre', 1);

INSERT INTO dbo.Empleado (Nombres, Apellidos, Dni, Cargo, Telefono, Estado) VALUES
('María',  'Gómez Ríos',     '40123456', 'Mozo',          '987654321', 1),
('José',   'Pérez Quispe',   '41234567', 'Mozo',          '986543210', 1),
('Ana',    'Torres Salas',   '42345678', 'Cajero',        '985432109', 1),
('Luis',   'Ramírez Díaz',   '43456789', 'Cocinero',      '984321098', 1);

INSERT INTO dbo.Cliente (Nombres, Apellidos, Documento, Telefono, Correo, Direccion, Estado) VALUES
('Pedro',   'Castillo López', '45678912', '999111222', 'pedro@correo.com',  'Av. Lima 123',     1),
('Lucía',   'Mendoza Vega',   '46789123', '999222333', 'lucia@correo.com',  'Jr. Cusco 456',    1),
('Empresa', 'ABC S.A.C.',     '20512345678','01-4567890','ventas@abc.com',  'Av. Industrial 789',1);
GO

PRINT 'Base de datos RestaurantDB creada correctamente con datos de prueba.';
GO








USE RestaurantDB;

SELECT * FROM dbo.Cliente;
GO
SELECT IdCliente FROM dbo.Cliente
WHERE idCliente = 1;

SELECT * FROM dbo.Usuario;
