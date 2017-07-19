CREATE TABLE [dbo].[AtacLog] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [RequestDate] DATETIME        NOT NULL,
    [Protocol]    NVARCHAR (200)  NOT NULL,
    [Ip]          NVARCHAR (20)   NOT NULL,
    [UserAgent]   NVARCHAR (1000) NULL,
    CONSTRAINT [PK_AtacLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

