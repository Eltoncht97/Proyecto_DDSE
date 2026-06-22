/* ============================================================================
   MIGRACIÓN: el comprobante devuelve su número correlativo (parámetro OUTPUT)
   Corrige que la boleta/factura mostraba "Serie-Número: B001-000000".
   ============================================================================ */
USE RestaurantDB;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Comprobante_Insertar
    @IdPedido INT, @Tipo NVARCHAR(10), @Serie NVARCHAR(6),
    @SubTotal DECIMAL(10,2), @Igv DECIMAL(10,2), @Total DECIMAL(10,2),
    @Numero INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Numero = ISNULL(MAX(Numero), 0) + 1 FROM dbo.Comprobante WHERE Serie = @Serie;

    INSERT INTO dbo.Comprobante (IdPedido, Tipo, Serie, Numero, Fecha, SubTotal, Igv, Total)
    VALUES (@IdPedido, @Tipo, @Serie, @Numero, GETDATE(), @SubTotal, @Igv, @Total);

    UPDATE dbo.Pedido SET Situacion = 'Pagado' WHERE IdPedido = @IdPedido;

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO

PRINT 'usp_Comprobante_Insertar actualizado: ahora devuelve @Numero OUTPUT.';
GO
