/****** Object:  Table [dbo].[TVersion]    Script Date: 10/07/2015 14:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TVersion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[banben] [int] NOT NULL,
	[shengjishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TVersion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TUser]    Script Date: 10/07/2015 14:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dengluming] [varchar](10) NOT NULL,
	[mima] [varchar](16) NOT NULL,
	[yonghuming] [nvarchar](5) NOT NULL,
	[juese] [tinyint] NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[zhuangtai] [tinyint] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TUser] UNIQUE NONCLUSTERED 
(
	[dengluming] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TTiaoma]    Script Date: 10/07/2015 14:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TTiaoma](
	[id] [int] NOT NULL,
	[tiaoma] [varchar](13) NOT NULL,
	[kuanhao] [varchar](20) NOT NULL,
	[gongyingshang] [nvarchar](10) NOT NULL,
	[gyskuanhao] [varchar](20) NOT NULL,
	[leixing] [tinyint] NOT NULL,
	[pinming] [nvarchar](6) NOT NULL,
	[yanse] [nvarchar](5) NOT NULL,
	[chima] [varchar](10) NOT NULL,
	[jinjia] [decimal](6, 2) NOT NULL,
	[shoujia] [decimal](6, 2) NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TTiaoma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TTiaoma] UNIQUE NONCLUSTERED 
(
	[tiaoma] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TChuruku]    Script Date: 10/07/2015 14:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TChuruku](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[picima] [varchar](8) NULL,
	[fangxiang] [tinyint] NOT NULL,
	[laiyuanquxiang] [tinyint] NOT NULL,
	[zhekou] [decimal](4, 2) NULL,
	[jmsid] [int] NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[queding] [bit] NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
	[shangbaoshijian] [datetime] NULL,
 CONSTRAINT [PK_TChuruku] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TKucunXZ]    Script Date: 10/07/2015 14:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TKucunXZ](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[shuliang] [smallint] NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiuggaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TKucunXZ] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TChurukuMX]    Script Date: 10/07/2015 14:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TChurukuMX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[churukuid] [int] NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[danjia] [decimal](6, 2) NOT NULL,
	[shuliang] [smallint] NOT NULL,
 CONSTRAINT [PK_TChurukuMX] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TChurukuMX] UNIQUE NONCLUSTERED 
(
	[churukuid] ASC,
	[tiaomaid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TJiamengshang]    Script Date: 12/14/2015 14:58:39 ******/
CREATE TABLE [dbo].[TJiamengshang](
	[id] [int] NOT NULL,
	[mingcheng] [nvarchar](20) NOT NULL,
	[daima] [smallint] NOT NULL,
	[dizhi] [nvarchar](50) NOT NULL,
	[lianxiren] [nvarchar](5) NOT NULL,
	[dianhua] [varchar](30) NOT NULL,
	[zhuangtai] [bit] NOT NULL,
 CONSTRAINT [PK_TJiamengshang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TJiamengshang] UNIQUE NONCLUSTERED 
(
	[mingcheng] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TJiamengshang_1] UNIQUE NONCLUSTERED 
(
	[daima] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  View [dbo].[VKucun]    Script Date: 10/07/2015 14:37:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VKucun]
AS

SELECT		C.id,ISNULL(B.shuliang,0) AS shuliang,B.jinhuoriqi
FROM		dbo.TTiaoma AS C
LEFT JOIN	--如果同一个条码有多次进货记录，以最近的日期作为其进货日期
(SELECT		tiaomaid,CAST(SUM(shuliang) AS SMALLINT) AS shuliang,MAX(jinhuoriqi) AS jinhuoriqi
FROM

	--进货数量
	(SELECT		b.tiaomaid,b.shuliang,CAST(a.charushijian as DATE) AS jinhuoriqi
	FROM        dbo.TChuruku a
	INNER JOIN	dbo.TChurukuMX b
	ON			a.id = b.churukuid
	WHERE		fangxiang = 1

	UNION ALL

	--出货数量
	SELECT		b.tiaomaid,-b.shuliang,NULL AS jinhuoriqi
	FROM        dbo.TChuruku a
	INNER JOIN	dbo.TChurukuMX b
	ON			a.id = b.churukuid
	WHERE		fangxiang = 2

	UNION ALL

	--库存修正，库存修正的记录，进货日期不明
	SELECT		tiaomaid,shuliang,NULL AS jinhuoriqi
	FROM		dbo.TKucunXZ) AS A

GROUP BY	tiaomaid) AS B
ON			C.id = B.tiaomaid
GO
/****** Object:  ForeignKey [FK_TChuruku_TUser]    Script Date: 10/07/2015 14:37:51 ******/
ALTER TABLE [dbo].[TChuruku]  WITH CHECK ADD  CONSTRAINT [FK_TChuruku_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TChuruku] CHECK CONSTRAINT [FK_TChuruku_TUser]
GO
/****** Object:  ForeignKey [FK_TChurukuMX_TChuruku]    Script Date: 10/07/2015 14:37:51 ******/
ALTER TABLE [dbo].[TChurukuMX]  WITH CHECK ADD  CONSTRAINT [FK_TChurukuMX_TChuruku] FOREIGN KEY([churukuid])
REFERENCES [dbo].[TChuruku] ([id])
GO
ALTER TABLE [dbo].[TChurukuMX] CHECK CONSTRAINT [FK_TChurukuMX_TChuruku]
GO
/****** Object:  ForeignKey [FK_TChurukuMX_TTiaoma]    Script Date: 10/07/2015 14:37:51 ******/
ALTER TABLE [dbo].[TChurukuMX]  WITH CHECK ADD  CONSTRAINT [FK_TChurukuMX_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TChurukuMX] CHECK CONSTRAINT [FK_TChurukuMX_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TKucunXZ_TTiaoma]    Script Date: 10/07/2015 14:37:51 ******/
ALTER TABLE [dbo].[TKucunXZ]  WITH CHECK ADD  CONSTRAINT [FK_TKucunXZ_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TKucunXZ] CHECK CONSTRAINT [FK_TKucunXZ_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TKucunXZ_TUser]    Script Date: 10/07/2015 14:37:51 ******/
ALTER TABLE [dbo].[TKucunXZ]  WITH CHECK ADD  CONSTRAINT [FK_TKucunXZ_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TKucunXZ] CHECK CONSTRAINT [FK_TKucunXZ_TUser]
GO
/****** Object:  ForeignKey [FK_TChuruku_TJiamengshang]    Script Date: 10/07/2015 14:37:51 ******/
ALTER TABLE [dbo].[TChuruku] WITH NOCHECK
    ADD CONSTRAINT [FK_TChuruku_TJiamengshang] FOREIGN KEY ([jmsid]) REFERENCES [dbo].[TJiamengshang] ([id]);
GO
ALTER TABLE [dbo].[TChuruku] CHECK CONSTRAINT [FK_TChuruku_TJiamengshang]
GO
