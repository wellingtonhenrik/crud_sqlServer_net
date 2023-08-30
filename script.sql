
create table EMPRESA (
EMPRESAID UNIQUEIDENTIFIER NOT NULL,
NOMEFANTASIA NVARCHAR(100) NOT NULL,
RAZAOSOCIAL NVARCHAR(100) NOT NULL,
CPNJ NVARCHAR(14) NOT NULL,
PRIMARY  KEY(EMPRESAID))
GO

create table FUNCIONARIO (
FUNCIONARIOID UNIQUEIDENTIFIER NOT NULL,
NOME NVARCHAR(150) NOT NULL,
CPF NVARCHAR(11) NOT NULL,
MATRICULA NVARCHAR(100) NOT NULL,
DATAADMISSAO DATE NOT NULL,
EMPRESAID UNIQUEIDENTIFIER NOT NULL,
PRIMARY KEY(FUNCIONARIOID),
FOREIGN KEY (EMPRESAID) REFERENCES EMPRESA(EMPRESAID))
GO


 