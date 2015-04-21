CREATE TABLE [dbo].[TKuanhao] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [kuanhao]       VARCHAR (20)  NOT NULL,
    [leixing]       TINYINT       NOT NULL,
    [pinming]       NVARCHAR (6)  NOT NULL,
    [beizhu]        NVARCHAR (50) NOT NULL,
    [caozuorenid]   INT           NOT NULL,
    [charushijian]  DATETIME      NOT NULL,
    [xiugaishijian] DATETIME      NOT NULL,
    CONSTRAINT [PK_TKuanhao] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TKuanhao_TUser] FOREIGN KEY ([caozuorenid]) REFERENCES [dbo].[TUser] ([id]),
    CONSTRAINT [IX_TKuanhao] UNIQUE NONCLUSTERED ([kuanhao] ASC)
);

