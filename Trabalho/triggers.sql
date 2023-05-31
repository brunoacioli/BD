/*CREATE TRIGGER start_corridas ON Corridas
INSTEAD OF INSERT 
AS
BEGIN
	IF (SELECT count(*) FROM inserted) > 0		BEGIN
			DECLARE @partida as varchar(255);
			DECLARE @destino as varchar(255);
			DECLARE @id_cliente as int;
			DECLARE @id_motorista as int;
			DECLARE @status as varchar(50);
			

			SELECT @partida = partida, @destino = destino, @id_cliente = id_cliente, @id_motorista = id_motorista,@status = [status]  FROM inserted;

			INSERT INTO Corridas(partida,destino,inicio,id_cliente,id_motorista,[status]) values(@partida,@destino,GETDATE(),@id_cliente, @id_motorista, @status);

		END
END;



CREATE TRIGGER update_corridas ON Corridas
INSTEAD OF UPDATE 
AS
BEGIN
	IF (SELECT count(*) FROM inserted) > 0		BEGIN
			DECLARE @gorjeta as int;					
			DECLARE @status as varchar(50);
			DECLARE @id as INT;
			DECLARE @inicio as datetime;
			DECLARE @fim as datetime = GETDATE();			
			
			
			DECLARE @valor_pagamento as int;
			SELECT @valor_pagamento = CAST((RAND() * 100) + 1 AS INT) ;

			SELECT @id = id, @gorjeta = gorjeta, @status = [status], @inicio = inicio  FROM inserted;

			DECLARE @HourDiff as int;
			SELECT @HourDiff = DATEDIFF(hour, @inicio,@fim) ;
			
			DECLARE @MinuteDiff as int;
			SELECT @MinuteDiff = DATEDIFF(minute, @inicio,@fim) % 60;
			PRINT @MinuteDiff;
			DECLARE @SecondDiff as int;
			SELECT @SecondDiff = DATEDIFF(second, @inicio,@fim) % 60; 

			DECLARE @duracao as varchar(255) = CONCAT(@HourDiff,':',@MinuteDiff, ':', @SecondDiff);
			

			UPDATE Corridas SET gorjeta = @gorjeta, [status] = @status, pagamento = @valor_pagamento,fim = @fim, duracao = @duracao WHERE id = @id;			

		END
END;

*/

/*
	
*/




