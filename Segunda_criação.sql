/*CREATE TABLE Veiculos (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  marca VARCHAR(255) NOT NULL,
  modelo VARCHAR(255) NOT NULL,
  cor VARCHAR(255) NOT NULL,
  capacidade_bateria INT NOT NULL
);

CREATE TABLE Motoristas(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	nome VARCHAR(255) NOT NULL,
	email VARCHAR(255) NOT NULL,
	foto VARCHAR(255) NOT NULL,
	avaliacao INT NOT NULL,
	telefone VARCHAR(255),
);

CREATE TABLE Motorista_Veiculos(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	id_motorista INT NOT NULL FOREIGN KEY REFERENCES Motoristas(id),
	id_veiculo INT NOT NULL FOREIGN KEY REFERENCES Veiculos(id),
);


CREATE TABLE Formas_de_pagamento(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	tipo VARCHAR(255) NOT NULL,

);

CREATE TABLE Clientes(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	nome VARCHAR(255) NOT NULL,
	email VARCHAR(255) NOT NULL,
	avaliacao INT NOT NULL,
	telefone VARCHAR(255) NOT NULL,
	foto VARCHAR(255) NOT NULL,
);

CREATE TABLE Clientes_Forma_de_Pagamento(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	id_cliente INT NOT NULL FOREIGN KEY REFERENCES Clientes(id),
	id_forma_de_pagamento INT NOT NULL FOREIGN KEY REFERENCES Formas_de_pagamento(id),
);



CREATE TABLE Corridas(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	partida VARCHAR(255) NOT NULL,
	destino VARCHAR(255) NOT NULL,
	duracao INT NOT NULL,
	pagamento INT NOT NULL,
	gorjeta INT NOT NULL,
	id_cliente INT NOT NULL FOREIGN KEY REFERENCES Clientes(id),
	id_motorista INT NOT NULL FOREIGN KEY REFERENCES Motoristas(id),
);

CREATE TABLE Mensagens(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	texto VARCHAR(255) NOT NULL,
	[data] DATETIME NOT NULL,
	[status] VARCHAR(255) NOT NULL,
	corrida_id INT NOT NULL FOREIGN KEY REFERENCES Corridas(id),
);


CREATE TABLE Comodidades(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	tipo VARCHAR(255) NOT NULL,
);



CREATE TABLE Ponto_Recarga(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	empresa VARCHAR(255) NOT NULL,
	capacidade INT NOT NULL,
	disponibilidade BIT NOT NULL,
	morada VARCHAR(255),	
);

CREATE TABLE Ponto_Descanso(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	morada VARCHAR(255) NOT NULL,
	capacidade INT NOT NULL,
	avaliacao INT NOT NULL,
	id_ponto_recarga INT NOT NULL FOREIGN KEY REFERENCES Ponto_Recarga(id),
);

CREATE TABLE Ponto_Descanso_Comodidades(
	id INT NOT NULL IDENTITY PRIMARY KEY,
	id_ponto_descanso INT NOT NULL FOREIGN KEY REFERENCES Ponto_Descanso(id),
	id_comodidades INT NOT NULL FOREIGN KEY REFERENCES Comodidades(id),
);

*/







