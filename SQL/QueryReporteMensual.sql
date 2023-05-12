DECLARE @usuarioId INT = 1;
declare @anio int = 2023

SELECT Month(FechaTransaccion) AS Mes,
SUM(Monto) as Monto, cat.TipoOperacionId
FROM Transacciones
INNER JOIN Categorias cat
ON cat.Id = Transacciones.CategoriaId
WHERE Transacciones.UsuarioId = @usuarioId AND YEAR(FechaTransaccion) = @anio
GROUP BY Month(FechaTransaccion), cat.TipoOperacionId