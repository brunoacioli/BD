/*CREATE TABLE GestaoStock_TipoFornecedor (
codigo int NOT NULL PRIMARY KEY,
nome varchar(256) NOT NULL
)


CREATE TABLE GestaoStock_CondPagamento (
codigo int NOT NULL PRIMARY KEY,
nome varchar(256) NOT NULL,
prazo_dias int NOT NULL
)

CREATE TABLE GestaoStock_Produtos(
codigo int NOT NULL PRIMARY KEY,
nome varchar(256) NOT NULL,
preco decimal(10,2) NOT NULL,
iva int NOT NULL 
)

CREATE TABLE GestaoStock_Fornecedor(
codigo int NOT NULL PRIMARY KEY,
nome varchar(256) NOT NULL,
morada varchar(1024) NOT NULL,
nif int NOT NULL,
condPag_codigo int NOT NULL FOREIGN KEY REFERENCES GestaoStock_CondPagamento(codigo),
tipoForn_codigo int NOT NULL FOREIGN KEY REFERENCES GestaoStock_TipoFornecedor(codigo)
)

CREATE TABLE GestaoStock_Encomenda (
numEnc int NOT NULL PRIMARY KEY,
[data] date NOT NULL,
forn_Codigo int NOT NULL FOREIGN KEY REFERENCES GestaoStock_Fornecedor(codigo),
unidades int NOT NULL
)

CREATE TABLE GestaoStock_EncProd(
numEnc int NOT NULL FOREIGN KEY REFERENCES GestaoStock_Encomenda(numEnc),
codProd int NOT NULL FOREIGN KEY REFERENCES GestaoStock_Produtos(codigo),
unidadeProd int NOT NULL
)
 
ALTER TABLE GestaoStock_EncProd
ADD PRIMARY KEY(numEnc,codProd)
*/

