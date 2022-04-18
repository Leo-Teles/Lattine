CREATE DATABASE lattine;
GO

USE lattine;
GO

CREATE TABLE contatosLattine(
   idContatosLattine smallint PRIMARY KEY IDENTITY(1,1),
   localizacao varchar(100) unique not null
);
go

CREATE TABLE telefone(
   idTelefone smallint PRIMARY KEY IDENTITY(1,1),
   idContatosLattine smallint FOREIGN KEY REFERENCES contatosLattine(idContatosLattine),
   numero varchar(50) not null
);
go

CREATE TABLE tipoUsuario(
   idTipoUsuario smallint PRIMARY KEY IDENTITY(1,1),
   titulo varchar(100) unique not null
);
go

CREATE TABLE usuario(
   idUsuario smallint PRIMARY KEY IDENTITY(1,1),
   idTipoUsuario smallint FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
   nome varchar (100) not null,
   sobrenome varchar (100) not null,
   email varchar(100) unique not null,
   senha varchar(50) unique not null,
   dataCadastro datetime
);
go

CREATE TABLE grupoRecursos(
   idGrupoRecursos smallint PRIMARY KEY IDENTITY(1,1),
   idUsuario smallint FOREIGN KEY REFERENCES usuario(idUsuario),
   nomeGrupoRecursos varchar (256) unique not null,
   dataCadastro datetime
);
go

CREATE TABLE infraestrutura(
   idInfraestrutura smallint PRIMARY KEY IDENTITY(1,1),
   dataCadastro datetime
);
go

CREATE TABLE grupoInfraestrutura(
   idGrupoInfraestrutura smallint PRIMARY KEY IDENTITY(1,1),
   idGrupoRecursos smallint FOREIGN KEY REFERENCES grupoRecursos(idGrupoRecursos),
   idInfraestrutura smallint FOREIGN KEY REFERENCES infraestrutura(idInfraestrutura),
);
go

CREATE TABLE maquinaVirtual(
   idMaquinaVirtual smallint PRIMARY KEY IDENTITY(1,1),
   idInfraestrutura smallint FOREIGN KEY REFERENCES infraestrutura(idInfraestrutura),
   nomeMaquinaVirtual varchar (256) unique not null,
   opcoesDisponibilidade varchar (50) not null,
   sistemaOperacional varchar (50) not null,
   tamanho varchar (50) not null,
   nomeAdmin varchar (256) unique not null,
   origemChavePublicaSSH varchar (50) not null
);
go

CREATE TABLE enderecoIP(
   idEnderecoIP smallint PRIMARY KEY IDENTITY(1,1),
   endereco varchar(50) not null
);
go

CREATE TABLE subRede(
   idSubRede smallint PRIMARY KEY IDENTITY(1,1),
   nomeSubRede varchar(256) unique not null,
   intervalosEndereco varchar(50) not null
);
go

CREATE TABLE redeVirtual(
   idRedeVirtual smallint PRIMARY KEY IDENTITY(1,1),
   idInfraestrutura smallint FOREIGN KEY REFERENCES infraestrutura(idInfraestrutura),
   idEnderecoIP smallint FOREIGN KEY REFERENCES enderecoIP(idEnderecoIP),
   idSubRede smallint FOREIGN KEY REFERENCES subRede(idSubRede),
   nomeRedeVirtual varchar (256) unique not null,
   bastionHost bit not null,
   protecaoDDoS bit not null,
   fireWall bit not null
);
go

CREATE TABLE servicoAplicacional(
   idServicoAplicacional smallint PRIMARY KEY IDENTITY(1,1),
   idInfraestrutura smallint FOREIGN KEY REFERENCES infraestrutura(idInfraestrutura),
   nomeServicoAplicacional varchar (256) unique not null,
   pilhaRuntime varchar (50) not null,
   SKUeTamanho varchar (50) not null
);
go
