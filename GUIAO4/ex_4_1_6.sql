/*CREATE TABLE GestaoATL_Pessoa(
cc int NOT NULL PRIMARY KEY,
nome varchar(128) NOT NULL,
morada varchar(1024) NOT NULL,
data_de_nascimento date NOT NULL
)

CREATE TABLE GestaoATL_Turma(
id int NOT NULL PRIMARY KEY,
designacao varchar(256) NOT NULL,
ano_letivo int NOT NULL,
classe varchar(128) NOT NULL,
no_max_alunos int NOT NULL
)

CREATE TABLE GestaoATL_NaoAluno(
cc_nao_aluno int NOT NULL FOREIGN KEY REFERENCES GestaoATL_Pessoa(cc),
contato_telefonico varchar(13) NOT NULL,
email varchar(128) NOT NULL
)

ALTER TABLE GestaoATL_NaoAluno
ADD PRIMARY KEY(cc_nao_aluno)

CREATE TABLE GestaoATL_Professor(
cc_professor int NOT NULL FOREIGN KEY REFERENCES GestaoATL_NaoAluno(cc_nao_aluno),
id_turma int NOT NULL FOREIGN KEY REFERENCES GestaoATL_Turma(id)
)

CREATE TABLE GestaoATL_PessoaAutorizacao(
cc_pessoa_autorizacao int NOT NULL FOREIGN KEY REFERENCES GestaoATL_NaoAluno(cc_nao_aluno),
relacao_com_aluno varchar(128) NOT NULL
)*/

/*ALTER TABLE GestaoATL_Professor
ADD PRIMARY KEY(cc_professor)*/

/*ALTER TABLE GestaoATL_PessoaAutorizacao
ADD PRIMARY KEY(cc_pessoa_autorizacao)

CREATE TABLE GestaoATL_Encarregado(
cc_encarregado int NOT NULL FOREIGN KEY REFERENCES GestaoATL_PessoaAutorizacao(cc_pessoa_autorizacao),
)

CREATE TABLE GestaoATL_Aluno(
cc_aluno int NOT NULL FOREIGN KEY REFERENCES GestaoATL_Pessoa(cc),
id_turma int NOT NULL FOREIGN KEY REFERENCES GestaoATL_Turma(id),
cc_pessoa_autorizacao int NOT NULL FOREIGN KEY REFERENCES GestaoATL_PessoaAutorizacao(cc_pessoa_autorizacao),
PRIMARY KEY(cc_aluno)
)

CREATE TABLE GestaoATL_Atividade(
id int NOT NULL PRIMARY KEY,
desiganacao varchar(256) NOT NULL,
custo int NOT NULL
)

CREATE TABLE GestaoATL_AlunoAtividade(
cc_aluno int NOT NULL FOREIGN KEY REFERENCES GestaoATL_Aluno(cc_aluno),
id_atividade int NOT NULL FOREIGN KEY REFERENCES GestaoATL_Atividade(id)
PRIMARY KEY(cc_aluno)
)


CREATE TABLE GestaoATL_AtividadeTurma (
id_atividade int NOT NULL FOREIGN KEY REFERENCES GestaoATL_Atividade(id),
id_turma int NOT NULL FOREIGN KEY REFERENCES GestaoATL_Turma(id),
PRIMARY KEY(id_atividade, id_turma)
)

CREATE TABLE GestaoATL_NaoEncarregado(
cc_nao_encarregado int NOT NULL FOREIGN KEY REFERENCES GestaoATL_PessoaAutorizacao(cc_pessoa_autorizacao),
PRIMARY KEY(cc_nao_encarregado)
)

ALTER TABLE GestaoATL_Encarregado
ADD PRIMARY KEY(cc_encarregado)
*/


