CREATE TABLE [dbo].[TBCategoria] (
    [Id]     UNIQUEIDENTIFIER NOT NULL,
    [Titulo] NVARCHAR (100)   NOT NULL
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_TBCategoria_Titulo]
    ON [dbo].[TBCategoria]([Titulo] ASC);
GO

ALTER TABLE [dbo].[TBCategoria]
    ADD CONSTRAINT [PK_TBCategoria] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

