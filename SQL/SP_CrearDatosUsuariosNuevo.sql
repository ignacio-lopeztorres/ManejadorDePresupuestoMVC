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
CREATE PROCEDURE CrearDatosUsuariosNuevo
	-- Add the parameters for the stored procedure here
	@UsuarioId int
AS
BEGIN
  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
	DECLARE @Efectivo nvarchar(50) = 'Efectivo';
	DECLARE @CuentasDeBancos nvarchar(50) = 'Cuentas De Bancos';
	DECLARE @Tarjetas nvarchar(50) = 'Tarjetas';

	insert INTO TiposCuentas (Nombre, UsuarioId, Orden)
	VALUES (@Efectivo, @UsuarioId, 1),
	(@CuentasDeBancos, @UsuarioId, 2),
	(@Tarjetas, @UsuarioId, 3);

	INSERT INTO Cuentas(Nombre, Balance, TipoCuentaId)
	SELECT Nombre, 0, Id
	FROM TiposCuentas
	WHERE UsuarioId = @UsuarioId;

	INSERT INTO Categorias (Nombre, TipoOperacionId, UsuarioId)
	VALUES ('Libros', 2, @UsuarioId),
	('Salario', 1, @UsuarioId),
	('mesada', 1, @UsuarioId),
	('Comida', 2, @UsuarioId);
END