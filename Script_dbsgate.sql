CREATE TABLE tipoproduto (
idtipo int identity PRIMARY KEY,
tipo varchar(250)
)

CREATE TABLE produto (
idproduto int PRIMARY KEY,
descricao varchar(250),
dataexpiracao datetime,
valorproduto decimal(20,2),
idtipo int
)

CREATE TABLE pacote (
idpacote int PRIMARY KEY,
pacote varchar(250)
)

CREATE TABLE itenspacote(
idItemPacote int identity primary key,
idPacote int,
idproduto int
)

ALTER TABLE produto ADD FOREIGN KEY(idtipo) REFERENCES tipoproduto (idtipo)
ALTER TABLE itenspacote ADD FOREIGN KEY(idpacote) REFERENCES pacote (idpacote)
ALTER TABLE itenspacote ADD FOREIGN KEY(idproduto) REFERENCES produto (idproduto)


CREATE TABLE cliente (
       idcliente int identity PRIMARY KEY,
       nome varchar(250),
       cpf varchar(250),
       logradouro varchar(250),
       numero int,
       bairro varchar(250),
       cidade varchar(250),
       uf varchar(250),
       email varchar(250)
)