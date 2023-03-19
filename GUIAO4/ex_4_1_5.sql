/*CREATE TABLE GestaoConferencia_Instituicao (
	morada varchar(1024) NOT NULL,
	endereco varchar(1024) NOT NULL PRIMARY KEY
	)

CREATE TABLE GestaoConferencia_Pessoa (
	nome varchar(128) NOT NULL,
	email varchar(128) NOT NULL PRIMARY KEY,
	endereco_instituicao varchar(1024) FOREIGN KEY REFERENCES GestaoConferencia_Instituicao
	)

CREATE TABLE GestaoConferencia_Autor (
	email varchar(128) NOT NULL FOREIGN KEY REFERENCES GestaoConferencia_Pessoa(email)
	PRIMARY KEY(email)
)

CREATE TABLE GestaoConferencia_Participantes(
	morada varchar(1024) NOT NULL,
	data_de_inscricao date NOT NULL,
	pessoa_email varchar(128) NOT NULL FOREIGN KEY REFERENCES GestaoConferencia_Pessoa(email)
	PRIMARY KEY(pessoa_email)
	)

CREATE TABLE GestaoConferencia_estudante (
	comprovativo varchar(128) NOT NULL,
	participante_email varchar(128) NOT NULL FOREIGN KEY REFERENCES GestaoConferencia_Participantes(pessoa_email),
	PRIMARY KEY(participante_email)
	)

CREATE TABLE GestaoConferencia_NaoEstudante(
	referencia_da_transacao varchar(128) NOT NULL,
	participante_email varchar(128) NOT NULL FOREIGN KEY REFERENCES GestaoConferencia_Participantes(pessoa_email),
	PRIMARY KEY(participante_email)
	)

CREATE TABLE GestaoConferencia_Artigos(
	numero_registo int NOT NULL PRIMARY KEY,
	titulo varchar(256) NOT NULL
	)

CREATE TABLE GestaoConferencia_AutorArtigos(
	numero_artigo int NOT NULL FOREIGN KEY REFERENCES GestaoConferencia_Artigos(numero_registo),
	email_autor varchar(128) NOT NULL FOREIGN KEY REFERENCES GestaoConferencia_Autor(email),
	PRIMARY KEY(numero_artigo, email_autor)
	)*/