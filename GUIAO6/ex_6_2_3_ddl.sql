/*
CREATE TABLE PrescricaoMed_Medico(
num_id int NOT NULL PRIMARY KEY,
nome varchar(255) NOT NULL,
especialidade varchar(255) NOT NULL
)


CREATE TABLE PrescricaoMed_Farmacia(
nif int NOT NULL PRIMARY KEY,
nome varchar(255) NOT NULL,
telefone varchar(255) NOT NULL,
endereco varchar(255) NOT NULL,
)




CREATE TABLE PrescricaoMed_Farmaceutica(
registo_nacional varchar(255) NOT NULL PRIMARY KEY,
nome varchar(255) NOT NULL,
telefone varchar(255) NOT NULL,
endereco varchar(255) NOT NULL,
)


CREATE TABLE PrescricaoMed_Prescricao(
numero_unico int NOT NULL PRIMARY KEY,
[data] date not null,
num_medico int NOT NULL FOREIGN KEY REFERENCES PrescricaoMed_Medico(num_id),
nif_farmacia int NOT NULL FOREIGN KEY REFERENCES PrescricaoMed_Farmacia(nif),
)



CREATE TABLE PrescricaoMed_Paciente(
num_utente int NOT NULL PRIMARY KEY,
nome varchar(255) NOT NULL,
nascimento date NOT NULL,
endereco varchar(255) NOT NULL,
num_prescricao int NOT NULL FOREIGN KEY REFERENCES PrescricaoMed_Prescricao(numero_unico),
)



CREATE TABLE PrescricaoMed_Farmaco(
nome_comercial varchar(255) NOT NULL PRIMARY KEY,
formula varchar(255) NOT NULL,
registo_farmaceutica varchar(255) NOT NULL FOREIGN KEY REFERENCES PrescricaoMed_Farmaceutica(registo_nacional),
)



CREATE TABLE PrescricaoMed_Farmaco_farmacia(
nif_farmacia int NOT NULL FOREIGN KEY REFERENCES  PrescricaoMed_Farmacia(nif),
nome_comercial varchar(255) NOT NULL FOREIGN KEY REFERENCES PrescricaoMed_Farmaco(nome_comercial),
)

*/