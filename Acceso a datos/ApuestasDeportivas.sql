USE master
CREATE DATABASE apuestasACDAT
--DROP DATABASE apuestasACDAT
GO
USE apuestasACDAT
GO


-- HAY QUE EXPLICAR LA BASE DE DATOS; NO SE VA A PRESENTAR.
-- TENEMOS QUE DECIDIR UN NIVEL DE ISOLACIÓN DE LAS TRANSACCIONES

--UNA TRANSACCIÓN REPRESENTA LA REALIDAD DE UN MOVIMIENTO DE DINERO, POR LO QUE EL MOVIMIENTO DE DINERO DEBE IR ANTES QUE
-- LA CREACIÓN DE LA TRANSACCIÓN. NO OBSTANTE, LAS TRANSACCIONES TIENEN AUTORIDAD EN CUANTO A QUE NOS AYUDAN A CONTROLAR LOS PAGOS
-- POR LO QUE,  UN MOVIMIENTO QUE NO TENGA SU TRANSACCIÓN CORRESPONDENTE NO TIENE NINGÚN TIPO DE GARANTÍA DE SER UN MOVIMIENTO LEGAL.
-- PODRÍA SER EL RESULTADO DE ALGUIEN QUE EFECTIVAMENTE NOS DEBE/DEBEMOS DINERO, O UN ERROR EN EL SISTEMA

--COMENTARIO DE STACK OVERFLOW SOBRE EL NIVEL DE ISOLACIÓN DE LAS TRANSACCIONES EN APLICACIONES MONETARIAS
--A financial application probably has many situations where one record is read and then based on that one or more records including the original one are altered. Every tim you encounter a situation like that, it is more important that you indicate the write intend on the initial read by requesting a write or update lock. If you do that within the same transaction that executes the writes later on you are not dependent on the isolation level at all. You also will reduce the likelihood of deadlocks.
--In the end, the choice of isolation level really depends on your requirements. The type of application is not a good guide to pick an isolation level. Look at each requirement and see if the implementation requires a specific isolation level.

--AL INSERTAR FILAS EN LA FECHAS QUE TIENEN CAMPOS CON FECHA Y HORA DE CREACIÓN, PONER EN LA DEFINICIÓN DE TABLA
--QUE SE AUTOGENERE

--TENEMOS QUE CONTROLAR EL FORMATO DEL CAMPO resultado EN APUESTAS, EN FUNCIÓN DEL TIPO DE APUESTA QUE ES. Ejemplo:
--Debemos evitar tener una apuesta con el tipo de "cantidad de corners" cuyo resultado esperado sea "El recre de huelva"

--Se debería de poner un trigger que cerrase los partidos que tienen una edad de más de 3 días
--y un procedimiento almacenado que tomara la id del partido como parámetro

--ACLARACIONES IMPORTANTES PARA LA EXPLICACIÓN EN LA DOCUMENTACIÓN:
-- Distinguimos 4 tipos de movimientos de dinero en el balance del usuario: Las ganancias y las pérdidas
-- según el resultado de una apuesta y el depósito o sustracción voluntaria de dinero en la cuenta del
-- propio usuario. Esta distinción la expresan las 4 diferentes combinaciones del signo del importe
-- y la nulabilidad del campo idApuesta (tabla Transacciones):
-- importe positivo e idApuesta NULL: El usuario deposita dinero en su cuenta voluntariamente
-- importe positivo e idApuesta distinto de NULL: El usuario ha ganado una apuesta.
-- importe negativo e idApuesta NULL: El usuario ha retirado dinero de su cuenta voluntariamente
-- importe negativo e idApuesta distinto de NULL:  El usuario acaba de realizar una apuesta
--Dado que 

--Possible design improvements:
-- The closing time of all bets might be possible to implement modifying database user's permissions?
-- Either way, the bit field "puedeApostar" in Partido entities represents whether or not that match accepts
-- bets. Stored procedure "cambiarEstadoApuesta" switches ALL matches' puedeApostar field



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

    CONSTRAINT PKUsuario PRIMARY KEY (ID),
    CONSTRAINT CFechaNacimiento CHECK  ((datediff(dd,fechaNacimiento,GETDATE()) / 365)  > 18))
GO

CREATE TABLE TiposApuestas (
    ID int NOT NULL IDENTITY(1,1),
    tipo varchar(30),
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
	fechaRealizacion datetime NOT NULL,
    resultado int NULL,

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
	--as explained at the start of the script. It's crucial for the design that its nullability is set to NULL
    idApuesta int NULL UNIQUE,
    fecha datetime NOT NULL,
    importe smallmoney NOT NULL,

    CONSTRAINT PKTransacciones PRIMARY KEY (ID),
    CONSTRAINT FKTransaccionesUsuario FOREIGN KEY (idUsuario) REFERENCES Usuarios (ID),
    CONSTRAINT FKTransaccionesApuesta FOREIGN KEY (idApuesta) REFERENCES Apuestas (ID)
)
GO

--FUNCTIONS

--CALCULO MAXIMO-CUOTA

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
-- NON-DETERMINISTIC FUNCTION
-- Distinguimos tres (casualmente la misma cantidad de tipos de apuesta) dificultades en las apuestas realizadas
-- (INDEPENDIENTEMENTE DEL TIPO DE APUESTA): fácil, dificultad moderada y difícil (Respectivamente 1, 2 y 3 en la implementación).
-- Estas dificultades se corresponden naturalmente con lo difícil o fácil que sea ganar la apuesta en cuestión.
-- En el cálculo de la cuota para cada apuesta, se le asignará de forma arbitraria a la apuesta una dificultad, con su cuota
-- correspondiente. Hemos escogido un intervalo entre 1 y 10 para la cuota, de nuevo, sin ningún criterio de peso.

--------------------------
GO
CREATE OR ALTER FUNCTION calcularCuota()
RETURNS decimal(4,2) AS
BEGIN
	DECLARE @cuota decimal(4,2)
	DECLARE @dificultad tinyint
	--Assigning a random difficulty from 1 to 3
	SELECT @dificultad = RAND()*(3-1)+1;

	--Assigning the bet's rate according to its difficulty ([1.1-10] interval is divided into three equal parts)
	SELECT @cuota =
	CASE @dificultad
		WHEN 1 THEN RAND()*(3.3-1.1)+1.1
		WHEN 2 THEN RAND()*(6.3-3.4)+3.4
		WHEN 3 THEN RAND()*(10-6.4)+6.4
	END;

	RETURN @cuota;

END
GO

--TRIGGERS


---------------------------------------------ESTE TRIGGER ES INNECESARIO----------------------------------------------------------------------------
--El control sobre el dinero de la transacción es responsabilidad del procedimiento apostar. Tomando dicho valor como referencia,
--si contradice a la cantidad apostada que expresa la entidad transacción, se eliminará la apuesta y se revocará la transacción
--(Se creará una transacción por el mismo valor pero en positivo, es decir, se le devuelve el dinero al usuario).
--ESTE TRIGGER A LO MEJOR ES INUTIL: En el proceso de creación de una apuesta, el dinero que se usa como cantidad
--es exactamente el mismo que se ha usado para crear la transacción; ambos se hacen en el cuerpo del mismo procedimiento
--usando la variable con el mismo valor. La utilidad de este método yace en que si por algún otro motivo extraño esos números
--difieren, la base de dato reconozca esa diferencia. No obstante, es muy costoso para lo poco útil que es.

--Puede que este triger se pudiera definir de forma más típica de base de datos
--GO
--CREATE OR ALTER TRIGGER apuestaIgualSustraccion
--ON Apuestas
--FOR INSERT
--AS

----La cantidad de dinero apostada de la fila recién insertada
--DECLARE @cantidad smallmoney
--SELECT @cantidad = cantidad FROM inserted

----El importe de la transaccion que le corresponde a la apuesta recién insertada
--DECLARE @importe smallmoney
--SELECT @importe = importe
--FROM Transacciones AS T
--WHERE T.idApuesta = inserted.idApuesta

--IF(@cantidad <> @importe)
--	BEGIN
--		--Se elimina la apuesta introducida
--		DELETE FROM Apuestas AS A
--		WHERE A.ID = inserted.ID

--		--Se crea una nueva transacción en la que se le devuelva el dinero al usuario
--		INSERT INTO Transacciones

--	END


--GO-----------------------------------------------------------------------------------------------------------------------------------------------------

GO
CREATE OR ALTER TRIGGER superaMaximoApuestas
GO

GO
CREATE OR ALTER TRIGGER dniEnListaNegra
GO

--STORED PROCEDURES
--COMIENZA LOS PROCEDIMIENTOS CON BEGIN TRANSACTION
GO
CREATE OR ALTER PROCEDURE apostar(usuario, cantidad, partido)--Crea entidad apuesta PRIMERO y despues resta el dinero, y finalmente crea transacción (Usa sustraerSaldo)
AS
	--Estas tres comprobaciones se pueden hacer en un if y apañao
	--Si el partido permite apuestas y
	--si el usuario tiene saldo y
	--si no ha superado el maximo de apuestas, se crea una apuesta por @cantidad y se almacena su id,
	--inicializando el resultado previsto del partido a null
	--Seguidamente se le sustrae al usuario el dinero.
	--Por último, se crea una entidad Transaccion por el valor de @cantidad con el id previamente almacenado
GO

GO
CREATE OR ALTER PROCEDURE anadirSaldo(usuario, cantidad) --Crea entidad transaccion
AS

GO

GO
CREATE OR ALTER PROCEDURE sustraerSaldo(usuario, cantidad) --Crea entidad transaccion
AS

GO

GO
CREATE OR ALTER PROCEDURE cambiarEstadoApuestas
AS
	UPDATE Partidos
	-- ~ Operator flips the bit
	SET puedeApostar = ~puedeApostar
GO