ALTER TABLE [dbo].[TJinchuhuo] DROP CONSTRAINT [FK_TJinchuhuo_TUser];
ALTER TABLE [dbo].[TJinchuMX] DROP CONSTRAINT [FK_TJinchuMX_TJinchuhuo];
ALTER TABLE [dbo].[TJinchuMX] DROP CONSTRAINT [FK_TJinchuMX_TTiaoma];
GO


CREATE TABLE [dbo].[tmp_ms_xx_TJinchuhuo] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [fangxiang]       TINYINT       NOT NULL,
    [laiyuanquxiang]  TINYINT       NOT NULL,
    [picima]          VARCHAR (8)   NULL,
    [beizhu]          NVARCHAR (50) NOT NULL,
    [queding]         BIT           NOT NULL,
    [caozuorenid]     INT           NOT NULL,
    [charushijian]    DATETIME      NOT NULL,
    [xiugaishijian]   DATETIME      NOT NULL,
    [shangbaoshijian] DATETIME      NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TJinchuhuo] PRIMARY KEY CLUSTERED ([id] ASC)
);
IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TJinchuhuo])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TJinchuhuo] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TJinchuhuo] ([id], [fangxiang], [laiyuanquxiang], [beizhu], [queding], [caozuorenid], [charushijian], [xiugaishijian], [shangbaoshijian])
        SELECT   [id],
                 [fangxiang],
                 [laiyuanquxiang],
                 [beizhu],
                 CASE WHEN [shangbaoshijian] IS NULL THEN 'False' ELSE 'True' END,
                 [caozuorenid],
                 [charushijian],
                 [xiugaishijian],
                 [shangbaoshijian]
        FROM     [dbo].[TJinchuhuo]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TJinchuhuo] OFF;
    END
DROP TABLE [dbo].[TJinchuhuo];
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TJinchuhuo]', N'TJinchuhuo';
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TJinchuhuo]', N'PK_TJinchuhuo', N'OBJECT';
GO


CREATE TABLE [dbo].[tmp_ms_xx_TJinchuMX] (
    [id]       INT            IDENTITY (1, 1) NOT NULL,
    [jinchuid] INT            NOT NULL,
    [tiaomaid] INT            NOT NULL,
    [danjia]   DECIMAL (6, 2) NOT NULL,
    [shuliang] SMALLINT       NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_TJinchuMX] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_IX_TJinchuMX] UNIQUE NONCLUSTERED ([jinchuid] ASC, [tiaomaid] ASC)
);
IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[TJinchuMX])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TJinchuMX] ON;
        INSERT INTO [dbo].[tmp_ms_xx_TJinchuMX] ([id], [jinchuid], [tiaomaid], [danjia], [shuliang])
        SELECT   A.[id],
                 [jinchuid],
                 [tiaomaid],
                 B.[jinjia],
                 [shuliang]
        FROM     [dbo].[TJinchuMX] A
        INNER JOIN	[dbo].[TTiaoma] B
        ON		A.tiaomaid = B.id 
        ORDER BY A.[id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_TJinchuMX] OFF;
    END
DROP TABLE [dbo].[TJinchuMX];
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_TJinchuMX]', N'TJinchuMX';
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_TJinchuMX]', N'PK_TJinchuMX', N'OBJECT';
EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_IX_TJinchuMX]', N'IX_TJinchuMX', N'OBJECT';
GO


ALTER TABLE [dbo].[TJinchuhuo] WITH NOCHECK
    ADD CONSTRAINT [FK_TJinchuhuo_TUser] FOREIGN KEY ([caozuorenid]) REFERENCES [dbo].[TUser] ([id]);
ALTER TABLE [dbo].[TJinchuMX] WITH NOCHECK
    ADD CONSTRAINT [FK_TJinchuMX_TJinchuhuo] FOREIGN KEY ([jinchuid]) REFERENCES [dbo].[TJinchuhuo] ([id]);
ALTER TABLE [dbo].[TJinchuMX] WITH NOCHECK
    ADD CONSTRAINT [FK_TJinchuMX_TTiaoma] FOREIGN KEY ([tiaomaid]) REFERENCES [dbo].[TTiaoma] ([id]);
GO

/************************************来源去向列的值意义发生修改变化***************************************/
UPDATE TJinchuhuo
SET laiyuanquxiang = 1
WHERE laiyuanquxiang = 3
GO

UPDATE TJinchuhuo
SET laiyuanquxiang = 3
WHERE laiyuanquxiang = 4
GO

UPDATE TJinchuhuo
SET laiyuanquxiang = 4
WHERE laiyuanquxiang = 5
GO

UPDATE TJinchuhuo
SET laiyuanquxiang = 99
WHERE laiyuanquxiang = 6
GO