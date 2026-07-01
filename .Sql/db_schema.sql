IF DB_ID('E_Agenda') IS NULL
BEGIN
    CREATE DATABASE [E_Agenda];
END;

USE [E_Agenda]
GO

CREATE TABLE [dbo].[TBContato]
(
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(100) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Telefone] nvarchar(12) NOT NULL,
    [Cargo] nvarchar(100) NULL,
    [Empresa] nvarchar(100) NULL,
    PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[TBCompromisso]
(
    [Id] uniqueidentifier NOT NULL,
    [Assunto] nvarchar(100) NOT NULL,
    [DataOcorrencia] date NOT NULL,
    [HoraDeInicio] time(0) NOT NULL,
    [HoraDeTermino] time(0) NOT NULL,
    [TipoDeCompromisso] int NOT NULL,
    [Local] nvarchar(100),
    [Link] nvarchar(100) NOT NULL,
    [ContatoId] uniqueidentifier,
    PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[TBCategoria]
(
    [Id] uniqueidentifier NOT NULL,
    [Titulo] nvarchar(100) NOT NULL,
    [DespesasId] uniqueidentifier NOT NULL,
    PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[TBDespesas]
(
    [Id] uniqueidentifier NOT NULL,
    [Descricao] nvarchar(100) NOT NULL,
    [DataOcorrencia] date NOT NULL,
    [Valor] decimal(18,0) NOT NULL,
    [FormaPagamento] int NOT NULL,
    [CategoriasId] uniqueidentifier NOT NULL,
    PRIMARY KEY ([Id])
);


ALTER TABLE [dbo].[TBCompromisso]
ADD CONSTRAINT [TBCompromisso_TBContato]
FOREIGN KEY ([ContatoId]) 
REFERENCES [dbo].[TBContato]([Id])
ON DELETE NO ACTION
ON UPDATE NO ACTION;



ALTER TABLE [dbo].[TBCategoria]
ADD CONSTRAINT [TBCategoria_TBDespesas]
FOREIGN KEY ([DespesasId]) 
REFERENCES [dbo].[TBDespesas]([Id])
ON DELETE NO ACTION
ON UPDATE NO ACTION;



ALTER TABLE [dbo].[TBDespesas]
ADD CONSTRAINT [TBDespesas_TBCategoria]
FOREIGN KEY ([CategoriasId]) 
REFERENCES [dbo].[TBCategoria]([Id])
ON DELETE NO ACTION
ON UPDATE NO ACTION;



