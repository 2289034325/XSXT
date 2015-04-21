CREATE TABLE [dbo].[TCangku] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [mingcheng]     NVARCHAR (10) NOT NULL,
    [dizhi]         NVARCHAR (50) NOT NULL,
    [lianxiren]     NVARCHAR (5)  NOT NULL,
    [dianhua]       VARCHAR (11)  NOT NULL,
    [beizhu]        NVARCHAR (50) NOT NULL,
    [caozuorenid]   INT           NOT NULL,
    [charushijian]  DATETIME      NOT NULL,
    [xiugaishijian] DATETIME      NOT NULL,
    CONSTRAINT [PK_TCangku] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TCangku_TUser] FOREIGN KEY ([caozuorenid]) REFERENCES [dbo].[TUser] ([id])
);

