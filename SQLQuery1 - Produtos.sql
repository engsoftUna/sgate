-- Geração de Modelo físico
-- Sql ANSI 2003 - brModelo.



CREATE TABLE produto (
idproduto int PRIMARY KEY,
descricao varchar(250),
dataexpiracao datetime,
valorproduto decimal(20,2),
idpacote int,
idtipo varchar(250)
)

CREATE TABLE pacote (
idpacote int PRIMARY KEY,
pacote varchar(250)
)

CREATE TABLE tipoproduto (
idtipo varchar(250) PRIMARY KEY,
tipo varchar(250)
)

ALTER TABLE produto ADD FOREIGN KEY(idpacote) REFERENCES pacote (idpacote)
ALTER TABLE produto ADD FOREIGN KEY(idtipo) REFERENCES tipoproduto (idtipo)
