CREATE TRIGGER Ponto_Descanso_Insert ON Ponto_Descanso
INSTEAD OF INSERT
AS
BEGIN
	IF (SELECT count(*) FROM inserted) = 1
	BEGIN
		DECLARE @id_ponto_recarga as int;
		DECLARE @morada as varchar(255);
		DECLARE @capacidade as int;
		DECLARE @avaliacao as int;
		DECLARE @InsertedID INT;
		SELECT @avaliacao = CAST((RAND() * 5) + 1 AS INT) ;

		

		SELECT @id_ponto_recarga = id_ponto_recarga, @morada = morada, @capacidade = capacidade FROM inserted;

		IF (@id_ponto_recarga) is null
		BEGIN
			INSERT INTO Ponto_Recarga(empresa,capacidade,disponibilidade,morada)values ('Brunao LTDA',@capacidade, 1, @morada)
			
			SET @InsertedID = SCOPE_IDENTITY();
			INSERT INTO Ponto_Descanso(morada, capacidade, avaliacao, id_ponto_recarga) values (@morada,@capacidade,@avaliacao, @InsertedID)
		END
		ELSE
		BEGIN
			INSERT INTO Ponto_Descanso(morada, capacidade, avaliacao, id_ponto_recarga) values (@morada,@capacidade,@avaliacao,@id_ponto_recarga)
		END
		
		SET @InsertedID = SCOPE_IDENTITY();

		INSERT INTO Ponto_Descanso_Comodidades values (@InsertedID,1);
		INSERT INTO Ponto_Descanso_Comodidades values (@InsertedID,2);


	END
END

	




