CREATE TABLE [dbo].[TTiaoma] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [tiaoma]        VARCHAR (13)   NOT NULL,
    [yanse]         NVARCHAR (5)   NOT NULL,
    [chima]         VARCHAR (10)   NOT NULL,
    [jinjia]        DECIMAL (6, 2) NOT NULL,
    [shoujia]       DECIMAL (6, 2) NOT NULL,
    [kuanhaoid]     INT            NOT NULL,
    [gysid]         INT            NOT NULL,
    [gyskuanhao]    VARCHAR (20)   NOT NULL,
    [maishou]       NVARCHAR (5)   NOT NULL,
    [caozuorenid]   INT            NOT NULL,
    [charushijian]  DATETIME       NOT NULL,
    [xiugaishijian] DATETIME       NOT NULL,
    CONSTRAINT [PK_TTiaoma] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TTiaoma_TGongyingshang] FOREIGN KEY ([gysid]) REFERENCES [dbo].[TGongyingshang] ([id]),
    CONSTRAINT [FK_TTiaoma_TKuanhao] FOREIGN KEY ([kuanhaoid]) REFERENCES [dbo].[TKuanhao] ([id]),
    CONSTRAINT [FK_TTiaoma_TUser] FOREIGN KEY ([caozuorenid]) REFERENCES [dbo].[TUser] ([id]),
    CONSTRAINT [IX_TTiaoma] UNIQUE NONCLUSTERED ([tiaoma] ASC)
);

