CREATE TABLE [dbo].[TBDespesaCategoria] (
    [DespesaId]   UNIQUEIDENTIFIER NOT NULL,
    [CategoriaId] UNIQUEIDENTIFIER NOT NULL
);
GO

ALTER TABLE [dbo].[TBDespesaCategoria]
    ADD CONSTRAINT [FK_TBDespesaCategoria_TBDespesa] FOREIGN KEY ([DespesaId]) REFERENCES [dbo].[TBDespesa] ([Id]);
GO

ALTER TABLE [dbo].[TBDespesaCategoria]
    ADD CONSTRAINT [FK_TBDespesaCategoria_TBCategoria] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[TBCategoria] ([Id]);
GO

ALTER TABLE [dbo].[TBDespesaCategoria]
    ADD CONSTRAINT [PK_TBDespesaCategoria] PRIMARY KEY CLUSTERED ([DespesaId] ASC, [CategoriaId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_TBDespesaCategoria_CategoriaId]
    ON [dbo].[TBDespesaCategoria]([CategoriaId] ASC);
GO

