CREATE TABLE [dbo].[TJintuimingxi] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [jinhuoid]   INT            NOT NULL,
    [tiaoma]     BIGINT         NOT NULL,
    [kuanhao]    NVARCHAR (10)  NOT NULL,
    [pinming]    NVARCHAR (6)   NOT NULL,
    [yanse]      NVARCHAR (5)   NOT NULL,
    [chima]      NVARCHAR (5)   NOT NULL,
    [jinjia]     DECIMAL (6, 2) NOT NULL,
    [shoujia]    DECIMAL (6, 2) NOT NULL,
    [shuliang]   SMALLINT       NOT NULL,
    [jinhuoriqi] DATE           NOT NULL,
    CONSTRAINT [PK_TJinhuomingxi] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TJinhuomingxi_TJinhuo] FOREIGN KEY ([jinhuoid]) REFERENCES [dbo].[TJintuihuo] ([id])
);

