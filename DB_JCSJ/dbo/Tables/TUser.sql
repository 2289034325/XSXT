CREATE TABLE [dbo].[TUser] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [dengluming]    VARCHAR (10)  NOT NULL,
    [mima]          VARCHAR (16)  NOT NULL,
    [yonghuming]    NVARCHAR (5)  NOT NULL,
    [juese]         TINYINT       NOT NULL,
    [beizhu]        NVARCHAR (50) NOT NULL,
    [zhuangtai]     TINYINT       NOT NULL,
    [charushijian]  DATETIME      NOT NULL,
    [xiugaishijian] DATETIME      NOT NULL,
    CONSTRAINT [PK_TUser] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_TUser] UNIQUE NONCLUSTERED ([dengluming] ASC)
);

