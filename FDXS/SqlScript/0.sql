USE [FD]
GO
/****** Object:  Table [dbo].[TUser]    Script Date: 08/05/2015 10:13:43 ******/
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
	[xiuggaishijian] [datetime] NOT NULL,
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
/****** Object:  Table [dbo].[TTiaoma]    Script Date: 08/05/2015 10:13:43 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THuiyuanZK]    Script Date: 08/05/2015 10:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THuiyuanZK](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jifen] [decimal](10, 2) NOT NULL,
	[zhekou] [decimal](4, 2) NOT NULL,
	[gengxinshijian] [datetime] NOT NULL,
 CONSTRAINT [PK_THuiyuanZK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_THuiyuanZK] UNIQUE NONCLUSTERED 
(
	[jifen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_THuiyuanZK_1] UNIQUE NONCLUSTERED 
(
	[zhekou] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THuiyuan]    Script Date: 08/05/2015 10:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THuiyuan](
	[id] [int] NOT NULL,
	[fendianid] [int] NOT NULL,
	[shoujihao] [varchar](13) NOT NULL,
	[xingming] [nvarchar](5) NOT NULL,
	[xingbie] [tinyint] NOT NULL,
	[shengri] [date] NOT NULL,
	[jifen] [decimal](10, 2) NOT NULL,
	[jfgxshijian] [datetime] NOT NULL,
	[xxgxshijian] [datetime] NOT NULL,
 CONSTRAINT [PK_THuiyuan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_THuiyuan] UNIQUE NONCLUSTERED 
(
	[shoujihao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TJinchuhuo]    Script Date: 08/05/2015 10:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TJinchuhuo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fangxiang] [tinyint] NOT NULL,
	[laiyuanquxiang] [tinyint] NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
	[shangbaoshijian] [datetime] NULL,
 CONSTRAINT [PK_TJinchuhuo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TXiaoshou]    Script Date: 08/05/2015 10:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TXiaoshou](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[xiaoshoushijian] [datetime] NOT NULL,
	[xiaoshouyuan] [nvarchar](5) NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[huiyuanid] [int] NULL,
	[shuliang] [smallint] NOT NULL,
	[danjia] [decimal](6, 2) NOT NULL,
	[zhekou] [decimal](4, 2) NOT NULL,
	[moling] [decimal](6, 2) NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
	[shangbaoshijian] [datetime] NULL,
 CONSTRAINT [PK_TXiaoshou] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TPandian]    Script Date: 08/05/2015 10:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPandian](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[pdshuliang] [smallint] NOT NULL,
	[kcshuliang] [smallint] NOT NULL,
	[charushijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TPandian] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TPandian] UNIQUE NONCLUSTERED 
(
	[tiaomaid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TKucunXZ]    Script Date: 08/05/2015 10:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TKucunXZ](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[shuliang] [smallint] NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TKucunXZ] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TJinchuMX]    Script Date: 08/05/2015 10:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TJinchuMX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jinchuid] [int] NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[shuliang] [smallint] NOT NULL,
 CONSTRAINT [PK_TJinchuMX] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TJinchuMX] UNIQUE NONCLUSTERED 
(
	[jinchuid] ASC,
	[tiaomaid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VKucun]    Script Date: 08/05/2015 10:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VKucun]
AS

SELECT		C.id,ISNULL(B.shuliang,0) AS shuliang
FROM		dbo.TTiaoma AS C
LEFT JOIN	
(SELECT		tiaomaid,CAST(SUM(shuliang) AS SMALLINT) AS shuliang
FROM

--进货数量
(SELECT		b.tiaomaid,b.shuliang
FROM        dbo.TJinchuhuo a
INNER JOIN	dbo.TJinchuMX b
ON			a.id = b.jinchuid
WHERE		fangxiang = 1

UNION ALL

--出货数量
SELECT		b.tiaomaid,-b.shuliang
FROM        dbo.TJinchuhuo a
INNER JOIN	dbo.TJinchuMX b
ON			a.id = b.jinchuid
WHERE		fangxiang = 2

UNION ALL

--库存修正
SELECT		tiaomaid,shuliang
FROM		dbo.TKucunXZ

UNION ALL

--销售数量
SELECT		tiaomaid,CAST(SUM(-shuliang) AS SMALLINT) AS shuliang
FROM		dbo.TXiaoshou
GROUP BY	tiaomaid) AS A

GROUP BY	tiaomaid) AS B
ON			C.id = B.tiaomaid
GO
/****** Object:  ForeignKey [FK_TJinchuhuo_TUser]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TJinchuhuo]  WITH CHECK ADD  CONSTRAINT [FK_TJinchuhuo_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TJinchuhuo] CHECK CONSTRAINT [FK_TJinchuhuo_TUser]
GO
/****** Object:  ForeignKey [FK_TJinchuMX_TJinchuhuo]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TJinchuMX]  WITH CHECK ADD  CONSTRAINT [FK_TJinchuMX_TJinchuhuo] FOREIGN KEY([jinchuid])
REFERENCES [dbo].[TJinchuhuo] ([id])
GO
ALTER TABLE [dbo].[TJinchuMX] CHECK CONSTRAINT [FK_TJinchuMX_TJinchuhuo]
GO
/****** Object:  ForeignKey [FK_TJinchuMX_TTiaoma]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TJinchuMX]  WITH CHECK ADD  CONSTRAINT [FK_TJinchuMX_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TJinchuMX] CHECK CONSTRAINT [FK_TJinchuMX_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TKucunXZ_TTiaoma]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TKucunXZ]  WITH CHECK ADD  CONSTRAINT [FK_TKucunXZ_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TKucunXZ] CHECK CONSTRAINT [FK_TKucunXZ_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TKucunXZ_TUser]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TKucunXZ]  WITH CHECK ADD  CONSTRAINT [FK_TKucunXZ_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TKucunXZ] CHECK CONSTRAINT [FK_TKucunXZ_TUser]
GO
/****** Object:  ForeignKey [FK_TPandian_TTiaoma]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TPandian]  WITH CHECK ADD  CONSTRAINT [FK_TPandian_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TPandian] CHECK CONSTRAINT [FK_TPandian_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TXiaoshou_THuiyuan]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TXiaoshou]  WITH CHECK ADD  CONSTRAINT [FK_TXiaoshou_THuiyuan] FOREIGN KEY([huiyuanid])
REFERENCES [dbo].[THuiyuan] ([id])
GO
ALTER TABLE [dbo].[TXiaoshou] CHECK CONSTRAINT [FK_TXiaoshou_THuiyuan]
GO
/****** Object:  ForeignKey [FK_TXiaoshou_TTiaoma]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TXiaoshou]  WITH CHECK ADD  CONSTRAINT [FK_TXiaoshou_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TXiaoshou] CHECK CONSTRAINT [FK_TXiaoshou_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TXiaoshou_TUser]    Script Date: 08/05/2015 10:13:43 ******/
ALTER TABLE [dbo].[TXiaoshou]  WITH CHECK ADD  CONSTRAINT [FK_TXiaoshou_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TXiaoshou] CHECK CONSTRAINT [FK_TXiaoshou_TUser]
GO
