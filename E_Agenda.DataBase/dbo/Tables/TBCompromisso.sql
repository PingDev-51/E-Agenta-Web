CREATE TABLE [dbo].[TBCompromisso] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Assunto]        NVARCHAR (100)   NOT NULL,
    [DataOcorrencia] DATE             NOT NULL,
    [HoraInicio]     TIME (7)         NOT NULL,
    [HoraTermino]    TIME (7)         NOT NULL,
    [Tipo]           INT              NOT NULL,
    [Local]          NVARCHAR (255)   NULL,
    [Link]           NVARCHAR (500)   NULL,
    [ContatoId]      UNIQUEIDENTIFIER NULL
);
GO

ALTER TABLE [dbo].[TBCompromisso]
    ADD CONSTRAINT [FK_TBCompromisso_TBContato] FOREIGN KEY ([ContatoId]) REFERENCES [dbo].[TBContato] ([Id]);
GO

CREATE NONCLUSTERED INDEX [IX_TBCompromisso_ContatoId]
    ON [dbo].[TBCompromisso]([ContatoId] ASC);
GO

ALTER TABLE [dbo].[TBCompromisso]
    ADD CONSTRAINT [PK_TBCompromisso] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

