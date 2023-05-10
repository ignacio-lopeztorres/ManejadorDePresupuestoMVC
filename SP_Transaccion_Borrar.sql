-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Transaccion_Borrar 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @Monto DECIMAL(18,2);
	DECLARE @CuentaId INT;
	DECLARE @TipoOperacionId INT;

  SELECT @Monto = Monto, @CuentaId = CuentaId, @TipoOperacionId = cat.TipoOperacionId
	FROM Transacciones
	INNER JOIN Categorias cat
	ON cat.Id = Transacciones.CategoriaId
	WHERE Transacciones.Id = @Id;
	 
	DECLARE @FactorMultiplicativo int = 1;

	IF (@TipoOperacionId = 2)
		SET @FactorMultiplicativo = -1;

	SET @Monto = @Monto * @FactorMultiplicativo;

	UPDATE Cuentas
	SET Balance -= @Monto
	WHERE Id = @CuentaId;

	DELETE Transacciones
	WHERE Id = @Id;
END
