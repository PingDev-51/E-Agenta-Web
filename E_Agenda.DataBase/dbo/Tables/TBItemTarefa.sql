CREATE TABLE [dbo].[TBItemTarefa] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Titulo]    NVARCHAR (100)   NOT NULL,
    [Concluido] BIT              NOT NULL,
    [TarefaId]  UNIQUEIDENTIFIER NOT NULL
);
GO

CREATE NONCLUSTERED INDEX [IX_TBItemTarefa_TarefaId]
    ON [dbo].[TBItemTarefa]([TarefaId] ASC);
GO

ALTER TABLE [dbo].[TBItemTarefa]
    ADD CONSTRAINT [PK_TBItemTarefa] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

