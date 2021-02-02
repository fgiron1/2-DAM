--USE master
--CREATE DATABASE apuestasACDAT
--USE apuestasACDAT
--DROP DATABASE apuestasACDAT



-- Distinguimos 4 tipos de movimientos de dinero en el balance del usuario: Las ganancias y las p�rdidas
-- seg�n el resultado de una apuesta y el dep�sito o sustracci�n voluntaria de dinero en la cuenta del
-- propio usuario. Esta distinci�n la expresan las 4 diferentes combinaciones del signo del importe
-- y la nulabilidad del campo idApuesta (tabla Transacciones):
-- importe positivo e idApuesta NULL: El usuario deposita dinero en su cuenta voluntariamente
-- importe positivo e idApuesta distinto de NULL: El usuario ha ganado una apuesta.
-- importe negativo e idApuesta NULL: El usuario ha retirado dinero de su cuenta voluntariamente
-- importe negativo e idApuesta distinto de NULL:  El usuario acaba de realizar una apuesta


SET NOCOUNT ON
SET DATEFORMAT dmy; 
GO

CREATE TABLE Usuarios (
    ID int IDENTITY(1,1),
    nombre varchar(50) NOT NULL,
    apellidos varchar(80) NOT NULL,
    email varchar(320) NOT NULL,
    contrasena varchar(12) NOT NULL,
    saldo smallmoney NOT NULL DEFAULT 0,
    fechaNacimiento date NOT NULL,
	fechaRegistro datetime NOT NULL DEFAULT(GETDATE())

    CONSTRAINT PKUsuario PRIMARY KEY (ID),
    CONSTRAINT CFechaNacimiento CHECK  ((datediff(dd,fechaNacimiento,GETDATE()) / 365)  > 18))
GO

CREATE TABLE TiposApuestas (
    ID int NOT NULL IDENTITY(1,1),
	--Up to 99 different bet categories
    tipo varchar(2),
    maximo int,

    CONSTRAINT PKTiposApuestas PRIMARY KEY (ID)
)
GO

CREATE TABLE Partidos (
    ID int NOT NULL IDENTITY(1,1),
    equipoLocal varchar(50) NOT NULL,
    equipoVisitante varchar(50) NOT NULL,
    fechaInicio datetime NOT NULL,
    fechaFin datetime NOT NULL,
    resultado varchar(5),
    golesLocales smallint DEFAULT 0,
    golesVisitantes smallint DEFAULT 0,
    cornersTotales smallint DEFAULT 0,
	--When true, the user can bet on this match.
	puedeApostar bit NOT NULL

    CONSTRAINT PKPartidos PRIMARY KEY (ID)
)
GO

CREATE TABLE Apuestas (
    ID int NOT NULL IDENTITY(1,1),
    idTipo int NOT NULL,
	idUsuario int NOT NULL,
    idPartido int NOT NULL,
    cantidad smallmoney NOT NULL,
    cuota decimal(4,2) NOT NULL,
	--Helps track illegal bets (bets to a nonexiting or finished match, etc...)
	fechaRealizacion datetime NOT NULL DEFAULT(GETDATE()),
	--resultado expects 3 different formats for the 3 different bet categories i.e.:
	--1-2 (Final results)
	--Local/Visitante (Winning team) -> Do this with an enum
	--15 (Number of corners)
    resultado nvarchar(30) NULL,

    CONSTRAINT PKApuestas PRIMARY KEY (ID),
    CONSTRAINT FKTipo FOREIGN KEY (idTipo) REFERENCES TiposApuestas (ID),
    CONSTRAINT FKPartido FOREIGN KEY (idPartido) REFERENCES Partidos (ID),
	CONSTRAINT FKUsuario FOREIGN KEY (idUsuario) REFERENCES Usuarios (ID)
)
GO

CREATE TABLE Transacciones (
    ID int NOT NULL IDENTITY(1,1),
    idUsuario int NOT NULL,
	--The value of idApuesta field, along with importe's positive or negative value allows us to determine whether
	--it's a voluntary deposit or withdrawal by the user, or if the transaction expresses a win or a loss in a certain bet,
	--as explained at the start of the script. It's crucial for this design that its nullability is set to NULL.
    idApuesta int NULL UNIQUE,
    fecha datetime NOT NULL,
    importe smallmoney NOT NULL,
	fecha_realizacion datetime NOT NULL DEFAULT(GETDATE())

    CONSTRAINT PKTransacciones PRIMARY KEY (ID),
    CONSTRAINT FKTransaccionesUsuario FOREIGN KEY (idUsuario) REFERENCES Usuarios (ID),
    CONSTRAINT FKTransaccionesApuesta FOREIGN KEY (idApuesta) REFERENCES Apuestas (ID)
)
GO

--FUNCTIONS

--CALCULO CUOTA

-------------------------
--Interface: calcularCuota()
--Description: This scalar function returns a valid rate for a bet. Calculation is explained below.
--Input: -
--Output: A valid rate yet to be assigned to a bet
--Precondiciones: -
--Postcondiciones: The value returned must always be > 1
--Improvements: This function could be improved by passing the rate's interval through a parameter,
--so as not to hardcode something so prone to change.
--------------------------
--Comments:
-- Distinguimos tres (casualmente la misma cantidad de tipos de apuesta) dificultades en las apuestas realizadas
-- (INDEPENDIENTEMENTE DEL TIPO DE APUESTA): f�cil, dificultad moderada y dif�cil (Respectivamente 1, 2 y 3 en la implementaci�n).
-- Estas dificultades se corresponden naturalmente con lo dif�cil o f�cil que sea ganar la apuesta en cuesti�n.
-- En el c�lculo de la cuota para cada apuesta, se le asignar� de forma arbitraria a la apuesta una dificultad, con su cuota
-- correspondiente. Hemos escogido un intervalo entre 1 y 10 para la cuota, de nuevo, sin ning�n criterio de peso.
--
--Uso la vista vw_valorAleatorio para generar un valor aleatorio porque las funciones del usuario no admiten funciones no deterministas en su definici�n
--

--------------------------

GO
CREATE OR ALTER VIEW vw_valorAleatorio
AS
SELECT RAND() AS Value
GO

GO
CREATE OR ALTER PROCEDURE calcularCuotaAux @dificultad int,
										   @cuotaFinal int OUTPUT
AS

	SELECT @cuotaFinal =
	CASE @dificultad
		WHEN 1 THEN (SELECT Value FROM vw_valorAleatorio)*(3.3-1.1)+1.1
		WHEN 2 THEN (SELECT Value FROM vw_valorAleatorio)*(6.3-3.4)+3.4
		WHEN 3 THEN (SELECT Value FROM vw_valorAleatorio)*(10-6.4)+6.4
	END;

RETURN

GO


GO
CREATE OR ALTER FUNCTION calcularCuota()
RETURNS decimal(4,2) AS
BEGIN
	DECLARE @cuota decimal(4,2)
	DECLARE @dificultad tinyint
	--Assigning a random difficulty from 1 to 3
	SELECT @dificultad = (SELECT Value From vw_valorAleatorio) *(3-1)+1;

	--Assigning the bet's rate according to its difficulty ([1.1-10] interval is divided into three equal parts)
	EXECUTE calcularCuotaAux @dificultad, @cuotaFinal = @cuota OUTPUT

	RETURN @cuota;

END
GO


--Demasiado acoplamiento con la del maximo, precisamente por lo de los partidos activos
-------------------------
--Interface: apuestasPorTipo()
--Description: This scalar function returns the total amount of bets in a particular category for active matches
--Input: A bet category
--Output: The total amount of bets per category
--Precondiciones: The bet category input must be valid (that is, a number between 1 and 3)
--Postcondiciones: 
--Improvements: 
--------------------------
--Comments: IMPORTANT. This function only takes into account non-finished matches
-- 
--------------------------
--Cuando un partido tiene el desto de cerrado a 1, los premios se han repartido y todo est� hecho.
GO
CREATE OR ALTER FUNCTION apuestasActivasPorTipo(@tipoApuesta int)
RETURNS int AS
BEGIN
	DECLARE @cantidadTotal int

	SELECT @cantidadTotal = SUM(sub1.cantidadApuestas) FROM
	--La cantidad de apuestas de tipo @tipoApuesta realizadas por cada partido
	(SELECT idPartido, COUNT(*) AS cantidadApuestas
	FROM Apuestas A
	INNER JOIN Partidos P ON P.ID = A.idPartido
	WHERE A.idTipo = @tipoApuesta AND P.puedeApostar = 1
	GROUP BY idPartido) AS sub1
	GROUP BY idPartido

	RETURN @cantidadTotal

END
GO

--TRIGGERS


--STORED PROCEDURES
--El componente de maximo no se como funciona, asi que no lo voy a incluir hasta que lo sepa xd

GO

CREATE OR ALTER PROCEDURE modificarSaldo @idUsuario int, @cantidad smallmoney, @idApuesta int
AS
    BEGIN TRANSACTION

        UPDATE Usuarios
		SET saldo = saldo + @cantidad
		WHERE ID = @idUsuario
		
		INSERT INTO Transacciones(idUsuario, idApuesta, importe)
        VALUES(@idUsuario, @idApuesta, @cantidad)

GO

GO
CREATE OR ALTER PROCEDURE apostar @idUsuario int, @cantidad smallmoney, @tipoApuesta int, @resultado varchar(30), @partido int --Crea entidad apuesta PRIMERO y despues resta el dinero, y finalmente crea transacci�n (Usa sustraerSaldo)
AS
	BEGIN TRANSACTION
		
		--Usuario: saldo, 
		--Partido: apuesta
		DECLARE @saldo smallmoney
		DECLARE @puedeApostar bit
		DECLARE @maximo int
		DECLARE @idNuevaApuesta int
		DECLARE @cuota decimal(4,2)

		SELECT @saldo = saldo
		FROM Usuarios
		WHERE ID = @idUsuario

		SELECT @puedeApostar = puedeApostar
		FROM Partidos
		WHERE ID = @partido

		SELECT @maximo = maximo
		FROM TiposApuestas
		WHERE tipo = @tipoApuesta

		--Si el usuario tiene saldo suficiente y el partido permite apuestas
		IF(@saldo >= 0.20 AND @puedeApostar = 1)
			BEGIN
				SET @cuota = dbo.calcularCuota()
				--Fecha e ID autogenerados. Revisar los triggers de insertar una apuesta
				INSERT INTO Apuestas(idTipo, idUsuario, idPartido, cuota, resultado, cantidad)
				VALUES(@tipoApuesta, @idUsuario, @partido, (SELECT * FROM dbo.calcularCuota()), @resultado, @cantidad)

				--Se sustrae el dinero al usuario (SCOPE_IDENTITY() devuelve la �ltima ID generada en el lote)
				--Este procedimiento tambi�n se encarga de crear la entidad transacci�n correspondiente
				SET @idNuevaApuesta = SCOPE_IDENTITY()
				EXECUTE modificarSaldo @idUsuario, @cantidad, @idNuevaApuesta

			END
		ELSE Print 'Error: Saldo insuficiente o apuesta cerrada'
GO


GO



GO
CREATE OR ALTER PROCEDURE anularApuesta @idApuesta int
AS
	BEGIN TRANSACTION
		DECLARE @cantidad smallmoney
		DECLARE @idUsuario int

		SELECT @cantidad = cantidad, @idUsuario = idUsuario
		FROM Apuestas AS A
		WHERE A.ID = @idApuesta

		DELETE FROM Apuestas
		WHERE ID = @idApuesta

		--Se crea la transacci�n y se actualiza el balance
		EXECUTE modificarSaldo @idUsuario, @cantidad, @idApuesta


GO

GO
CREATE OR ALTER PROCEDURE cerrarApuestasAbiertas
AS
	UPDATE Partidos
	-- ~ Operator flips the bit on open bets
	SET puedeApostar = ~puedeApostar
	WHERE puedeApostar = 1
GO

GO --Un poco innecesario en verdad
CREATE OR ALTER PROCEDURE cambiarMaximoSeguro @tipoApuesta int, @nuevoMaximo int
AS

	DECLARE @totalApuestas int
	SET @totalApuestas = dbo.apuestasActivasPorTipo(@tipoApuesta)

	IF(@nuevoMaximo >= @totalApuestas)
		BEGIN
			UPDATE TiposApuestas
			SET maximo = @nuevoMaximo
		END
	ELSE
		Print 'El nuevo maximo no puede ser menor que la cantidad de apuestas activas'
	

GO

---------------------------------
--Interface: entregarPremio @idPartido int
--Description: This procedure closes the bets for a match and modifies every better's balance adding their profits/losses
--Input: The id of a match whose bets are still open and wish to close
--Output: -
--Precondiciones: The match's bets must be open
--Postcondiciones: The match's bets are closed
--Comments: Another way of defining this procedure and modificarSaldo procedure is explained below
---------------------------------

GO
CREATE OR ALTER PROCEDURE entregarPremio @idPartido int
AS
	--Primero se actualiza el campo esApostable del partido a 0
	UPDATE Partidos
	SET puedeApostar = 0

	--Opcion para hacer esto:
	--Podria usar el procedimiento modificarSaldo, pero tendria que modificar sus parametros y poner una variable tipo tabla.
	--La cosa es que pasarle variables tipo tabla a un parametro directamente no se puede
	--y en su lugar, se define un tip� tabla, lo pueblas donde y como quieras quieras y en el procedimiento
	--lo que se hace es crear una transacci�n con los datos del tipo previamente creado.
	--Lo que pasa es que todos los movimientos de dinero usan ese mismo tipo como forma
	--de comunicarle al procedimiento de modificarDinero la informaci�n para crear la transacci�n. Como es
	--tan usado, no se si dar� problemas de disponibilidad.

	--Creamos todas las transacciones correspondientes
	INSERT INTO Transacciones(idApuesta, idUsuario, importe)
	SELECT A.ID, A.idUsuario, A.cuota * A.cantidad AS cantidadResultante FROM Apuestas A
	WHERE A.idPartido = @idPartido
	GROUP BY A.idUsuario, A.cuota, A.cantidad, A.ID

	--Actualizamos los balances de los jugadores
	--Si no hago el join entre las dos exactas tablas, me actualiza todos los saldos con el primer
	--valor de dicha tabla, en lugar de ir uno por uno
	UPDATE Usuarios
	SET saldo = saldo + InfoTran1.cantidad
	FROM (SELECT (A.cuota * A.cantidad) cantidad FROM Apuestas A
		  WHERE A.idPartido = @idPartido
		  GROUP BY A.idUsuario, A.cuota, A.cantidad, A.ID) AS InfoTran1
		  INNER JOIN
		  (SELECT (A.cuota * A.cantidad) cantidad FROM Apuestas A
		  WHERE A.idPartido = @idPartido
		  GROUP BY A.idUsuario, A.cuota, A.cantidad, A.ID) AS InfoTran2
		  ON Infotran1.cantidad = Infotran2.cantidad
		


GO