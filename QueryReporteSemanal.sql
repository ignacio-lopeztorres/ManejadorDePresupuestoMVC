DECLARE @fechaInicio DATE = '2023-05-01';
DECLARE @fechaFin DATE = '2023-05-30';
DECLARE @usuarioId INT = 1;

SELECT DATEDIFF(d, @fechaInicio, FechaTransaccion) / 7 + 1 AS Semana,
SUM(Monto) as Monto, cat.TipoOperacionId
FROM Transacciones
INNER JOIN Categorias cat
ON cat.Id = Transacciones.CategoriaId
WHERE Transacciones.UsuarioId = @usuarioId AND
FechaTransaccion BETWEEN @fechaInicio AND @fechaFin
GROUP BY DATEDIFF(d, @fechaInicio, FechaTransaccion) / 7, cat.TipoOperacionId