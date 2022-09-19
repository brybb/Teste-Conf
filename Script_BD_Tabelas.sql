CREATE DATABASE TesteConfitecDB;
GO

Use TesteConfitecDB;

GO

CREATE TABLE Escolaridade (
Id Int Primary Key Identity(1,1) not null,
Descricao Varchar(200) not null,
DataCadastro Datetime not null,
Ativo bit default(0)
)


GO

CREATE TABLE Usuario(
Id Int Primary Key Identity(1,1) not null,
Nome Varchar(255),
Sobrenome Varchar(255),
Email Varchar(255) not null,
DataNascimento Date not null,
EscolaridadeId Int FOREIGN KEY (EscolaridadeId) REFERENCES Escolaridade(Id),
DataCadastro Datetime not null,
Ativo bit default(0)
)

GO


CREATE TABLE HistoricoEscolar (
Id Int Primary Key Identity(1,1) not null,
UsuarioId Int FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id) ON DELETE CASCADE,
Nome Varchar(max) not null,
Arquivo Varchar(255),
Ativo bit default(0)
)



INSERT INTO Escolaridade (Descricao,DataCadastro,Ativo) values ('Infantil',GETDATE(),1)
INSERT INTO Escolaridade (Descricao,DataCadastro,Ativo) values ('Fundamental',GETDATE(),1)
INSERT INTO Escolaridade (Descricao,DataCadastro,Ativo) values ('Médio',GETDATE(),1)
INSERT INTO Escolaridade (Descricao,DataCadastro,Ativo) values ('Superior',GETDATE(),1)

