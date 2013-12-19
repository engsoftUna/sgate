CREATE TABLE tipoproduto (
idtipo int identity primary key,
descricao varchar(250)
)

CREATE TABLE produto (
idproduto int identity primary key,
descricao varchar(250),
dataexpiracao datetime,
valorproduto decimal(20,2),
idtipo int
)

CREATE TABLE pacote (
idpacote int identity primary key,
descricao varchar(250)
)

CREATE TABLE itenspacote (
iditempacote int identity primary key,
idpacote int,
idproduto int
)

ALTER TABLE produto ADD FOREIGN KEY(idtipo) REFERENCES tipoproduto (idtipo)
ALTER TABLE itenspacote ADD FOREIGN KEY(idpacote) REFERENCES pacote (idpacote)
ALTER TABLE itenspacote ADD FOREIGN KEY(idproduto) REFERENCES produto (idproduto)


CREATE TABLE cliente (
       idcliente int identity primary key,
       nome varchar(250),
       cpf varchar(250),
       logradouro varchar(250),
       numero int,
       bairro varchar(250),
       cidade varchar(250),
       uf varchar(250),
       email varchar(250)
)