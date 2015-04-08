CREATE TABLE [dbo].[TXiaoshou] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [shangpinid]   INT            NOT NULL,
    [danjia]       DECIMAL (6, 2) NOT NULL,
    [shuliang]     SMALLINT       NOT NULL,
    [zhekou]       DECIMAL (3, 1) NOT NULL,
    [moling]       DECIMAL (4, 2) NOT NULL,
    [charushijian] DATETIME       NOT NULL,
    CONSTRAINT [PK_TXiaoshou] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TXiaoshou_TShangpinxinxi] FOREIGN KEY ([shangpinid]) REFERENCES [dbo].[TJintuimingxi] ([id])
);

