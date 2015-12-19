ALTER TABLE [dbo].[TChurukuMX] DROP CONSTRAINT [FK_TChurukuMX_TChuruku];
ALTER TABLE [dbo].[TChuruku] DROP CONSTRAINT [FK_TChuruku_TUser];
ALTER TABLE [dbo].[TChurukuMX] DROP CONSTRAINT [FK_TChurukuMX_TTiaoma];
GO


CREATE TABLE [dbo].[tmp_ms_xx_TChuruku] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [picima]          VARCHAR (8)    NULL,
    [fangxiang]       TINYINT        NOT NULL,
    [laiyuanquxiang]  TINYINT        NOT NULL,
    [zhekou]          DECIMAL (4, 2) NULL,
    [jmsid]           INT            NULL,
    [beizhu]          NVARCHAR (50)  NOT NULL,
    [queding]         BIT            NOT NULL,
    [caozuorenid]     INT            NOT NULL,
    [charushijian]    DATETIME       NOT NULL,
    [xiugaishijian]   DATETIME       NOT NULL,
    [shangbaoshijian] DATETIME       NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TChuruku] PRIMARY KEY CLUSTERED ([id] ASC)
);
IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TChuruku])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TChuruku] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TChuruku] ([id], [picima], [fangxiang], [laiyuanquxiang], [beizhu], [queding], [caozuorenid], [charushijian], [xiugaishijian], [shangbaoshijian])
        SELECT   [id],
				 cast(rand([id])*100000000 as int),
                 [fangxiang],
                 [laiyuanquxiang],             
                 [beizhu],
                 CASE WHEN [shangbaoshijian] IS NULL THEN 'False' ELSE 'True' END,
                 [caozuorenid],
                 [charushijian],
                 [xiugaishijian],
                 [shangbaoshijian]
        FROM     [dbo].[TChuruku]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TChuruku] OFF;
    END
DROP TABLE [dbo].[TChuruku];
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TChuruku]', N'TChuruku';
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TChuruku]', N'PK_TChuruku', N'OBJECT';
GO


CREATE TABLE [dbo].[tmp_ms_xx_TChurukuMX] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [churukuid] INT            NOT NULL,
    [tiaomaid]  INT            NOT NULL,
    [danjia]    DECIMAL (6, 2) NOT NULL,
    [shuliang]  SMALLINT       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TChurukuMX] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_IX_TChurukuMX] UNIQUE NONCLUSTERED ([churukuid] ASC, [tiaomaid] ASC)
);
IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TChurukuMX])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TChurukuMX] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TChurukuMX] ([id], [churukuid], [tiaomaid], [danjia], [shuliang])
        SELECT   A.[id],
                 [churukuid],
                 [tiaomaid],
                 B.jinjia,
                 [shuliang]
        FROM     [dbo].[TChurukuMX] A
        INNER JOIN	[dbo].[TTiaoma] B
        ON		A.tiaomaid = B.id 
        ORDER BY A.[id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TChurukuMX] OFF;
    END
DROP TABLE [dbo].[TChurukuMX];
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TChurukuMX]', N'TChurukuMX';
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TChurukuMX]', N'PK_TChurukuMX', N'OBJECT';
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_IX_TChurukuMX]', N'IX_TChurukuMX', N'OBJECT';
GO


CREATE TABLE [dbo].[TJiamengshang] (
    [id]        INT           NOT NULL,
    [mingcheng] NVARCHAR (20) NOT NULL,
    [daima]     SMALLINT      NOT NULL,
    [dizhi]     NVARCHAR (50) NOT NULL,
    [lianxiren] NVARCHAR (5)  NOT NULL,
    [dianhua]   VARCHAR (30)  NOT NULL,
    [zhuangtai] BIT           NOT NULL,
    CONSTRAINT [PK_TJiamengshang] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_TJiamengshang] UNIQUE NONCLUSTERED ([mingcheng] ASC),
    CONSTRAINT [IX_TJiamengshang_1] UNIQUE NONCLUSTERED ([daima] ASC)
);
GO

ALTER TABLE [dbo].[TChurukuMX] WITH NOCHECK
    ADD CONSTRAINT [FK_TChurukuMX_TChuruku] FOREIGN KEY ([churukuid]) REFERENCES [dbo].[TChuruku] ([id]);
ALTER TABLE [dbo].[TChuruku] WITH NOCHECK
    ADD CONSTRAINT [FK_TChuruku_TUser] FOREIGN KEY ([caozuorenid]) REFERENCES [dbo].[TUser] ([id]);
ALTER TABLE [dbo].[TChuruku] WITH NOCHECK
    ADD CONSTRAINT [FK_TChuruku_TJiamengshang] FOREIGN KEY ([jmsid]) REFERENCES [dbo].[TJiamengshang] ([id]);
ALTER TABLE [dbo].[TChurukuMX] WITH NOCHECK
    ADD CONSTRAINT [FK_TChurukuMX_TTiaoma] FOREIGN KEY ([tiaomaid]) REFERENCES [dbo].[TTiaoma] ([id]);
GO


/**********************************进出货的来源去向值发生修改变化*********************************/
UPDATE TChuruku
SET laiyuanquxiang = 0
WHERE laiyuanquxiang = 2
GO

UPDATE TChuruku
SET laiyuanquxiang = 2
WHERE laiyuanquxiang = 3
GO

UPDATE TChuruku
SET laiyuanquxiang = 3
WHERE laiyuanquxiang = 0
GO

UPDATE TChuruku
SET laiyuanquxiang = 99
WHERE laiyuanquxiang = 4
GO

UPDATE TChuruku
SET laiyuanquxiang = 4
WHERE laiyuanquxiang = 5
GO

UPDATE TChuruku
SET laiyuanquxiang = 3
WHERE laiyuanquxiang = 6
GO