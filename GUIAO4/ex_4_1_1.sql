/*CREATE TABLE RentACar_Client(
	nif int NOT NULL PRIMARY KEY,
	nome varchar(255) NOT NULL,
	ENDERECO varchar(1024) NOT NULL,
	num_carta varchar(32) NOT NULL
	)

	CREATE TABLE RentACar_Balcao(
	numero int NOT NULL PRIMARY KEY,
	nome varchar(255) NOT NULL,
	endereco varchar(1024) NOT NULL
	)

	CREATE TABLE RentACar_TipoVeiculo (
	codigo int NOT NULL PRIMARY KEY,
	arcondicionado bit NOT NULL,
	desginacao varchar(1024) NOT NULL
	)

	CREATE TABLE RentACar_Ligeiro (
	num_lugares int NOT NULL,
	portas int NOT NULL,
	combustivel varchar(32) NOT NULL,
	codigo_veiculo int NOT NULL FOREIGN KEY REFERENCES RentACar_TipoVeiculo(codigo)
	)

	CREATE TABLE RentACar_Pesado (
	peso int NOT NULL,
	passageiros int NOT NULL,
	codigo_veiculo int NOT NULL FOREIGN KEY REFERENCES RentACar_TipoVeiculo(codigo)
	)

	CREATE TABLE RentACar_Similaridade (
	codigo1 int NOT NULL FOREIGN KEY REFERENCES RentACar_TipoVeiculo(codigo),
	codigo2 int NOT NULL FOREIGN KEY REFERENCES RentACar_TipoVeiculo(codigo),
	PRIMARY KEY(codigo1,codigo2),
	)

	ALTER TABLE RentACar_Ligeiro
	ADD PRIMARY KEY(codigo_veiculo)
	

	ALTER TABLE RentACar_Pesado
	ADD PRIMARY KEY(codigo_veiculo)
	

	CREATE TABLE RentACar_Veiculo(
	matricula varchar(32) NOT NULL PRIMARY KEY,
	marca varchar(32) NOT NULL,
	ano int NOT NULL,
	codigo_tipo int NOT NULL FOREIGN KEY REFERENCES RentACar_TipoVeiculo(codigo)
	)

	CREATE TABLE RentACar_Aluguer(
	numero int NOT NULL PRIMARY KEY,
	duracao_dias int NOT NULL,
	[data] date NOT NULL,
	nif_client int NOT NULL FOREIGN KEY REFERENCES RentACar_Client(nif),
	n_balcao int NOT NULL FOREIGN KEY REFERENCES RentACar_Balcao(numero),
	n_veiculo varchar(32) NOT NULL FOREIGN KEY REFERENCES RentACar_Veiculo(matricula)
	)*/




