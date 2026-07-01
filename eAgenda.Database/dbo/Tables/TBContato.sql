CREATE TABLE [dbo].[TBContato] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Nome]     NVARCHAR (100)   NOT NULL,
    [Email]    NVARCHAR (255)   NOT NULL,
    [Telefone] NVARCHAR (20)    NOT NULL,
    [Cargo]    NVARCHAR (100)   NULL,
    [Empresa]  NVARCHAR (100)   NULL,
    CONSTRAINT [PK_TBContato] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

ALTER TABLE [dbo].[TBContato]
    ADD CONSTRAINT [PK_TBContato] PRIMARY KEY CLUSTERED ([Id] ASC);
GO


CREATE UNIQUE NONCLUSTERED INDEX [UQ_TBContato_Email]
    ON [dbo].[TBContato]([Email] ASC);
GO


CREATE UNIQUE NONCLUSTERED INDEX [UQ_TBContato_Telefone]
    ON [dbo].[TBContato]([Telefone] ASC);
GO

