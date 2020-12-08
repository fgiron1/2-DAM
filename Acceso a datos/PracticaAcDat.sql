--Funcion que dice si un pedido cabe en un almacen
--Trigger en insercion en Asignaciones
	--Comprobacion de que el IDEnvio tiene su FechaAsignacion a NULL, si no, acabamos. (IDEnvio e IDAlmacen estan en la tabla temporal inserted)
	--Comprobamos capacidad de el almacen preferido (lo obtenemos con un SELECT WHERE ID = IDEnvio)
	--Si cabe, se comprueba que el IDEnvio sea igual al de AlmacenPreferido. Si lo es, todo correcto.
	--Si no, preguntamos al usuario en java si quiere ponerlo en otro almacen. Si es así
	--Obtenemos una lista ordenada por cercanía de los almacenes que tienen espacio para el envío y cogemos el más cercano


--Este trigger prioriza el almacen preferido independientemente de lo que se inserte en la tabla Asignaciones

GO
CREATE OR ALTER TRIGGER AsignarAlmacen
ON Asignaciones
INSTEAD OF INSERT
AS
BEGIN
	
	DECLARE @IDEnvio bigint
	DECLARE @FechaAsignacion date
	DECLARE @IDAlmacenPreferido bigint
	DECLARE @IDAlmacen bigint
	DECLARE @IDAlmacenMasCercano bigint

	--Almacenamos los datos necesarios
	SELECT @IDEnvio = IDEnvio,
	       @IDAlmacen = IDAlmacen
	FROM inserted

	SELECT @FechaAsignacion = FechaAsignacion,
	       @IDAlmacenPreferido = AlmacenPreferido 
	FROM Envios
	WHERE ID = @IDEnvio

	--Comprobamos que no se haya asignado ningun almacen aun
	IF(@FechaAsignacion IS NULL)
	--Comprobamos si en el almacen preferido hay suficiente espacio para el envio
	--Sintaxis redundante, pero SQL no me deja poner la funcion sola
		IF(dbo.FNHayEspacio(@IDEnvio, @IDAlmacen) = 1)
			BEGIN
				--Se actualiza el envio como asignado
				UPDATE Envios
				SET FechaAsignacion = CURRENT_TIMESTAMP
				WHERE ID = @IDEnvio

				--Se inserta una nueva fila en la tabla asignaciones
				INSERT INTO Asignaciones(IDEnvio, IDAlmacen)
				SELECT I.IDEnvio, I.IDAlmacen
				FROM inserted I
			END
		ELSE
			--Todas las distancias entre un almacen en particular a otro cualquiera
			--no estan expresadas de la forma: distancia de IDAlmacen1 a IDAlmacen2.
			--Una parte sí, pero otras son de la forma: distancia de IDAlmacen2 a IDAlmacen1.
			--Por ello, hay unas comprobaciones adicionales.
			
			--Ordenamos la subconsulta por la distancia y almacenamos el ID del almacen
			--más cercano al preferido
			SELECT TOP 1 
					--Este CASE nos permite diferenciar entre el ID del almacen preferido
					--y el id del almacen mas cercano al preferido
					@IDAlmacenMasCercano = CASE sub1.IDAlmacen1 
							WHEN @IDAlmacen THEN sub1.IDAlmacen2
							ELSE sub1.IDAlmacen1
					END
				FROM
				--Esta consulta devuelve las distancias entre los almacenes
				--que tienen espacio para almacenar un envio dado cuya id es @IDEnvio
				(SELECT IDAlmacen1, IDAlmacen2, Distancia FROM Distancias
				WHERE (IDAlmacen1 = @IDAlmacen OR
					  IDAlmacen2 = @IDAlmacen) AND
					  --Tengo que ver si las llamadas a la funcion se hacen por cada fila o solo la primera, que pasa mucho
					  (dbo.FNHayEspacio(@IDEnvio, IDAlmacen1) = 1 OR
					  dbo.FNHayEspacio(@IDEnvio, IDAlmacen2) = 1)
				ORDER BY Distancia ASC) sub1
				
END;
GO


GO
CREATE OR ALTER FUNCTION FNHayEspacio(@IDEnvio bigint, @IDAlmacen bigint)
RETURNS bit
AS
BEGIN
	
	DECLARE @NumeroContenedores int
	DECLARE @capacidadRestante int
	DECLARE @resultado bit

	--Los envios cuyo almacen de destino ya estan asignado figuran en la tabla Asignaciones
	--Es decir, si figura en la tabla Asignaciones, no debe de tener su campo FechaAsignacion a NULL
	--(Este trigger lo garantiza)

	--Calculamos la cantidad de contenedores que ocupan los envios que esten asignados a @IDAlmacen (cuyas ID figuren en Asignaciones)
	SELECT @NumeroContenedores = SUM(NumeroContenedores)
	FROM Asignaciones
	INNER JOIN Envios ON IDEnvio = ID
	WHERE IDAlmacen = @IDAlmacen

	SELECT @capacidadRestante = (Capacidad - @NumeroContenedores) FROM Almacenes
	WHERE ID = @IDAlmacen

	IF(@capacidadRestante >= 0)
		SET	@resultado = 1
	ELSE
		SET @resultado = 0

	RETURN @resultado

END
GO