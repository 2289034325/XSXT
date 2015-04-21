CREATE TABLE [dbo].[THuiyuan] (
    [id]            INT          IDENTITY (1, 1) NOT NULL,
    [fendianid]     INT          NOT NULL,
    [shoujihao]     VARCHAR (11) NOT NULL,
    [xingming]      NVARCHAR (5) NOT NULL,
    [xingbie]       TINYINT      NOT NULL,
    [shengri]       DATE         NOT NULL,
    [caozuorenid]   INT          NOT NULL,
    [charushijian]  DATETIME     NOT NULL,
    [xiugaishijian] DATETIME     NOT NULL,
    CONSTRAINT [PK_THuiyuan] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_THuiyuan_TUser] FOREIGN KEY ([caozuorenid]) REFERENCES [dbo].[TUser] ([id])
);

