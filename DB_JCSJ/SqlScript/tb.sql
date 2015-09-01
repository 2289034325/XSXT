USE [JCSJ]
GO
/****** Object:  Table [dbo].[TFendianKucun]    Script Date: 09/01/2015 12:33:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFendianKucun](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fendianid] [int] NOT NULL,
	[shangbaoshijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TFendianKucun] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFendianJinchuhuo]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFendianJinchuhuo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fendianid] [int] NOT NULL,
	[oid] [int] NOT NULL,
	[fangxiang] [tinyint] NOT NULL,
	[laiyuanquxiang] [tinyint] NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[fashengshijian] [datetime] NOT NULL,
	[shangbaoshijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TFendianJinchuhuo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TFendianJinchuhuo] UNIQUE NONCLUSTERED 
(
	[fendianid] ASC,
	[oid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TCangkuFahuoFendian]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCangkuFahuoFendian](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ckjinchuid] [int] NOT NULL,
	[fendianid] [int] NOT NULL,
	[scshijian] [datetime] NOT NULL,
	[xzshijian] [datetime] NULL,
 CONSTRAINT [PK_TCangkuFahuo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TCangkuFahuoFendian] UNIQUE NONCLUSTERED 
(
	[ckjinchuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TCangkuKucun]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCangkuKucun](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cangkuid] [int] NOT NULL,
	[shangbaoshijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TCangkuKucun] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TCangkuJinchuhuo]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCangkuJinchuhuo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cangkuid] [int] NOT NULL,
	[oid] [int] NOT NULL,
	[fangxiang] [tinyint] NOT NULL,
	[laiyuanquxiang] [tinyint] NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[fashengshijian] [datetime] NOT NULL,
	[shangbaoshijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TCangkuJinchuhuo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TCangkuJinchuhuo] UNIQUE NONCLUSTERED 
(
	[cangkuid] ASC,
	[oid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TXiaoshou]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TXiaoshou](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fendianid] [int] NOT NULL,
	[oid] [int] NOT NULL,
	[xiaoshoushijian] [datetime] NOT NULL,
	[xiaoshouyuan] [nvarchar](5) NOT NULL,
	[huiyuanid] [int] NULL,
	[tiaomaid] [int] NULL,
	[shuliang] [smallint] NOT NULL,
	[jinjia] [decimal](6, 2) NOT NULL,
	[shoujia] [decimal](6, 2) NOT NULL,
	[zhekou] [decimal](4, 2) NOT NULL,
	[moling] [decimal](6, 2) NOT NULL,
	[beizhu] [nvarchar](100) NOT NULL,
	[shangbaoshijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TXiaoshou] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TXiaoshou] UNIQUE NONCLUSTERED 
(
	[fendianid] ASC,
	[oid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFendianKucunMX]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFendianKucunMX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kucunid] [int] NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[shuliang] [smallint] NOT NULL,
	[jinhuoriqi] [date] NOT NULL,
 CONSTRAINT [PK_TFendianKucunMX] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFendianJinchuhuoMX]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFendianJinchuhuoMX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jinchuhuoid] [int] NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[shuliang] [smallint] NOT NULL,
 CONSTRAINT [PK_TFendianJinchuhuoMX] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TFendianJinchuhuoMX] UNIQUE NONCLUSTERED 
(
	[jinchuhuoid] ASC,
	[tiaomaid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TCangkuKucunMX]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCangkuKucunMX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kucunid] [int] NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[shuliang] [smallint] NOT NULL,
	[jinhuoriqi] [date] NOT NULL,
 CONSTRAINT [PK_TCangkuKucunMX] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TCangkuJinchuhuoMX]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCangkuJinchuhuoMX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jinchuhuoid] [int] NOT NULL,
	[tiaomaid] [int] NOT NULL,
	[shuliang] [smallint] NOT NULL,
 CONSTRAINT [PK_TCangkuJinchuhuoMX] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TCangkuJinchuhuoMX] UNIQUE NONCLUSTERED 
(
	[jinchuhuoid] ASC,
	[tiaomaid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TUser]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmsid] [int] NOT NULL,
	[dengluming] [varchar](10) NOT NULL,
	[mima] [varchar](16) NOT NULL,
	[jiqima] [varchar](16) NOT NULL,
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
/****** Object:  Table [dbo].[TTiaoma]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TTiaoma](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmsid] [int] NOT NULL,
	[kuanhaoid] [int] NOT NULL,
	[gysid] [int] NOT NULL,
	[gyskuanhao] [varchar](20) NOT NULL,
	[tiaoma] [varchar](13) NOT NULL,
	[yanse] [nvarchar](5) NOT NULL,
	[chima] [varchar](10) NOT NULL,
	[jinjia] [decimal](6, 2) NOT NULL,
	[shoujia] [decimal](6, 2) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TTiaoma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TTiaoma] UNIQUE NONCLUSTERED 
(
	[tiaoma] ASC,
	[jmsid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TKuanhao]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TKuanhao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmsid] [int] NOT NULL,
	[kuanhao] [varchar](20) NOT NULL,
	[leixing] [tinyint] NOT NULL,
	[xingbie] [tinyint] NOT NULL,
	[pinming] [nvarchar](6) NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TKuanhao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TKuanhao] UNIQUE NONCLUSTERED 
(
	[kuanhao] ASC,
	[jmsid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THuiyuan]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THuiyuan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmsid] [int] NOT NULL,
	[fendianid] [int] NOT NULL,
	[shoujihao] [varchar](11) NOT NULL,
	[xingming] [nvarchar](5) NOT NULL,
	[xingbie] [tinyint] NOT NULL,
	[shengri] [date] NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[jifen] [decimal](10, 2) NOT NULL,
	[jfjsshijian] [datetime] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_THuiyuan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_THuiyuan] UNIQUE NONCLUSTERED 
(
	[shoujihao] ASC,
	[jmsid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TGongyingshang]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TGongyingshang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmsid] [int] NOT NULL,
	[mingcheng] [nvarchar](20) NOT NULL,
	[lianxiren] [nvarchar](5) NOT NULL,
	[dianhua] [varchar](11) NOT NULL,
	[dizhi] [nvarchar](50) NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TGongyingshang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TGongyingshang] UNIQUE NONCLUSTERED 
(
	[mingcheng] ASC,
	[jmsid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TFendian]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TFendian](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmsid] [int] NOT NULL,
	[dianming] [nvarchar](10) NOT NULL,
	[fzxingbie] [tinyint] NOT NULL,
	[fzleixing] [tinyint] NOT NULL,
	[mianji] [smallint] NOT NULL,
	[keliuliang] [smallint] NOT NULL,
	[dangci] [tinyint] NOT NULL,
	[dpxingzhi] [tinyint] NOT NULL,
	[zhuanrangfei] [decimal](8, 2) NOT NULL,
	[yuezu] [decimal](8, 2) NOT NULL,
	[dizhi] [nvarchar](50) NOT NULL,
	[lianxiren] [nvarchar](5) NOT NULL,
	[dianhua] [varchar](11) NOT NULL,
	[kaidianriqi] [date] NOT NULL,
	[zhuangtai] [tinyint] NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[jiqima] [varchar](16) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TFendian] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TFendian] UNIQUE NONCLUSTERED 
(
	[dianming] ASC,
	[jmsid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TCangku]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TCangku](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmsid] [int] NOT NULL,
	[mingcheng] [nvarchar](10) NOT NULL,
	[dizhi] [nvarchar](50) NOT NULL,
	[lianxiren] [nvarchar](5) NOT NULL,
	[dianhua] [varchar](11) NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
	[jiqima] [varchar](16) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TCangku] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TCangku] UNIQUE NONCLUSTERED 
(
	[mingcheng] ASC,
	[jmsid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TJiamengshang]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TJiamengshang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mingcheng] [nvarchar](20) NOT NULL,
	[zhanghaoshu] [tinyint] NOT NULL,
	[tiaomashu] [int] NOT NULL,
	[huiyuanshu] [int] NOT NULL,
	[fendianshu] [smallint] NOT NULL,
	[kuanhaoshu] [int] NOT NULL,
	[cangkushu] [tinyint] NOT NULL,
	[gongyingshangshu] [smallint] NOT NULL,
	[xsjilushu] [int] NOT NULL,
	[jchjilushu] [int] NOT NULL,
	[kcjilushu] [int] NOT NULL,
	[shoucifufei] [decimal](8, 0) NOT NULL,
	[xufeidanjia] [decimal](6, 0) NOT NULL,
	[jiezhiriqi] [date] NOT NULL,
	[lianxiren] [nvarchar](5) NOT NULL,
	[dianhua] [varchar](11) NOT NULL,
	[beizhu] [nvarchar](100) NOT NULL,
	[dtyzm] [varchar](6) NOT NULL,
	[caozuorenid] [int] NOT NULL,
	[charushijian] [datetime] NOT NULL,
	[xiugaishijian] [datetime] NOT NULL,
 CONSTRAINT [PK_TJiamengshang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TJiamengshang] UNIQUE NONCLUSTERED 
(
	[mingcheng] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THuiyuanZK]    Script Date: 09/01/2015 12:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THuiyuanZK](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jifen] [decimal](10, 2) NOT NULL,
	[zhekou] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_THuiyuanZK] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_THuiyuanZK] UNIQUE NONCLUSTERED 
(
	[jifen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_THuiyuanZK_1] ON [dbo].[THuiyuanZK] 
(
	[zhekou] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_TFendianKucun_TFendian]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TFendianKucun]  WITH CHECK ADD  CONSTRAINT [FK_TFendianKucun_TFendian] FOREIGN KEY([fendianid])
REFERENCES [dbo].[TFendian] ([id])
GO
ALTER TABLE [dbo].[TFendianKucun] CHECK CONSTRAINT [FK_TFendianKucun_TFendian]
GO
/****** Object:  ForeignKey [FK_TFendianJinchuhuo_TFendian]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TFendianJinchuhuo]  WITH CHECK ADD  CONSTRAINT [FK_TFendianJinchuhuo_TFendian] FOREIGN KEY([fendianid])
REFERENCES [dbo].[TFendian] ([id])
GO
ALTER TABLE [dbo].[TFendianJinchuhuo] CHECK CONSTRAINT [FK_TFendianJinchuhuo_TFendian]
GO
/****** Object:  ForeignKey [FK_TCangkuFahuoFendian_TCangkuJinchuhuo]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangkuFahuoFendian]  WITH CHECK ADD  CONSTRAINT [FK_TCangkuFahuoFendian_TCangkuJinchuhuo] FOREIGN KEY([ckjinchuid])
REFERENCES [dbo].[TCangkuJinchuhuo] ([id])
GO
ALTER TABLE [dbo].[TCangkuFahuoFendian] CHECK CONSTRAINT [FK_TCangkuFahuoFendian_TCangkuJinchuhuo]
GO
/****** Object:  ForeignKey [FK_TCangkuFahuoFendian_TFendian]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangkuFahuoFendian]  WITH CHECK ADD  CONSTRAINT [FK_TCangkuFahuoFendian_TFendian] FOREIGN KEY([fendianid])
REFERENCES [dbo].[TFendian] ([id])
GO
ALTER TABLE [dbo].[TCangkuFahuoFendian] CHECK CONSTRAINT [FK_TCangkuFahuoFendian_TFendian]
GO
/****** Object:  ForeignKey [FK_TCangkuKucun_TCangku]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangkuKucun]  WITH CHECK ADD  CONSTRAINT [FK_TCangkuKucun_TCangku] FOREIGN KEY([cangkuid])
REFERENCES [dbo].[TCangku] ([id])
GO
ALTER TABLE [dbo].[TCangkuKucun] CHECK CONSTRAINT [FK_TCangkuKucun_TCangku]
GO
/****** Object:  ForeignKey [FK_TCangkuJinchuhuo_TCangku]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangkuJinchuhuo]  WITH CHECK ADD  CONSTRAINT [FK_TCangkuJinchuhuo_TCangku] FOREIGN KEY([cangkuid])
REFERENCES [dbo].[TCangku] ([id])
GO
ALTER TABLE [dbo].[TCangkuJinchuhuo] CHECK CONSTRAINT [FK_TCangkuJinchuhuo_TCangku]
GO
/****** Object:  ForeignKey [FK_TXiaoshou_TFendian]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TXiaoshou]  WITH CHECK ADD  CONSTRAINT [FK_TXiaoshou_TFendian] FOREIGN KEY([fendianid])
REFERENCES [dbo].[TFendian] ([id])
GO
ALTER TABLE [dbo].[TXiaoshou] CHECK CONSTRAINT [FK_TXiaoshou_TFendian]
GO
/****** Object:  ForeignKey [FK_TXiaoshou_THuiyuan]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TXiaoshou]  WITH CHECK ADD  CONSTRAINT [FK_TXiaoshou_THuiyuan] FOREIGN KEY([huiyuanid])
REFERENCES [dbo].[THuiyuan] ([id])
GO
ALTER TABLE [dbo].[TXiaoshou] CHECK CONSTRAINT [FK_TXiaoshou_THuiyuan]
GO
/****** Object:  ForeignKey [FK_TXiaoshou_TTiaoma]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TXiaoshou]  WITH CHECK ADD  CONSTRAINT [FK_TXiaoshou_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TXiaoshou] CHECK CONSTRAINT [FK_TXiaoshou_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TFendianKucunMX_TFendianKucun]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TFendianKucunMX]  WITH CHECK ADD  CONSTRAINT [FK_TFendianKucunMX_TFendianKucun] FOREIGN KEY([kucunid])
REFERENCES [dbo].[TFendianKucun] ([id])
GO
ALTER TABLE [dbo].[TFendianKucunMX] CHECK CONSTRAINT [FK_TFendianKucunMX_TFendianKucun]
GO
/****** Object:  ForeignKey [FK_TFendianKucunMX_TTiaoma]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TFendianKucunMX]  WITH CHECK ADD  CONSTRAINT [FK_TFendianKucunMX_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TFendianKucunMX] CHECK CONSTRAINT [FK_TFendianKucunMX_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TFendianJinchuhuoMX_TFendianJinchuhuo]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TFendianJinchuhuoMX]  WITH CHECK ADD  CONSTRAINT [FK_TFendianJinchuhuoMX_TFendianJinchuhuo] FOREIGN KEY([jinchuhuoid])
REFERENCES [dbo].[TFendianJinchuhuo] ([id])
GO
ALTER TABLE [dbo].[TFendianJinchuhuoMX] CHECK CONSTRAINT [FK_TFendianJinchuhuoMX_TFendianJinchuhuo]
GO
/****** Object:  ForeignKey [FK_TFendianJinchuhuoMX_TTiaoma]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TFendianJinchuhuoMX]  WITH CHECK ADD  CONSTRAINT [FK_TFendianJinchuhuoMX_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TFendianJinchuhuoMX] CHECK CONSTRAINT [FK_TFendianJinchuhuoMX_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TCangkuKucunMX_TCangkuKucun]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangkuKucunMX]  WITH CHECK ADD  CONSTRAINT [FK_TCangkuKucunMX_TCangkuKucun] FOREIGN KEY([kucunid])
REFERENCES [dbo].[TCangkuKucun] ([id])
GO
ALTER TABLE [dbo].[TCangkuKucunMX] CHECK CONSTRAINT [FK_TCangkuKucunMX_TCangkuKucun]
GO
/****** Object:  ForeignKey [FK_TCangkuKucunMX_TTiaoma]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangkuKucunMX]  WITH CHECK ADD  CONSTRAINT [FK_TCangkuKucunMX_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TCangkuKucunMX] CHECK CONSTRAINT [FK_TCangkuKucunMX_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TCangkuJinchuhuoMX_TCangkuJinchuhuo]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangkuJinchuhuoMX]  WITH CHECK ADD  CONSTRAINT [FK_TCangkuJinchuhuoMX_TCangkuJinchuhuo] FOREIGN KEY([jinchuhuoid])
REFERENCES [dbo].[TCangkuJinchuhuo] ([id])
GO
ALTER TABLE [dbo].[TCangkuJinchuhuoMX] CHECK CONSTRAINT [FK_TCangkuJinchuhuoMX_TCangkuJinchuhuo]
GO
/****** Object:  ForeignKey [FK_TCangkuJinchuhuoMX_TTiaoma]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangkuJinchuhuoMX]  WITH CHECK ADD  CONSTRAINT [FK_TCangkuJinchuhuoMX_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TCangkuJinchuhuoMX] CHECK CONSTRAINT [FK_TCangkuJinchuhuoMX_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TUser_TJiamengshang]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TUser]  WITH CHECK ADD  CONSTRAINT [FK_TUser_TJiamengshang] FOREIGN KEY([jmsid])
REFERENCES [dbo].[TJiamengshang] ([id])
GO
ALTER TABLE [dbo].[TUser] CHECK CONSTRAINT [FK_TUser_TJiamengshang]
GO
/****** Object:  ForeignKey [FK_TTiaoma_TGongyingshang]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TTiaoma]  WITH CHECK ADD  CONSTRAINT [FK_TTiaoma_TGongyingshang] FOREIGN KEY([gysid])
REFERENCES [dbo].[TGongyingshang] ([id])
GO
ALTER TABLE [dbo].[TTiaoma] CHECK CONSTRAINT [FK_TTiaoma_TGongyingshang]
GO
/****** Object:  ForeignKey [FK_TTiaoma_TJiamengshang]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TTiaoma]  WITH CHECK ADD  CONSTRAINT [FK_TTiaoma_TJiamengshang] FOREIGN KEY([jmsid])
REFERENCES [dbo].[TJiamengshang] ([id])
GO
ALTER TABLE [dbo].[TTiaoma] CHECK CONSTRAINT [FK_TTiaoma_TJiamengshang]
GO
/****** Object:  ForeignKey [FK_TTiaoma_TKuanhao]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TTiaoma]  WITH CHECK ADD  CONSTRAINT [FK_TTiaoma_TKuanhao] FOREIGN KEY([kuanhaoid])
REFERENCES [dbo].[TKuanhao] ([id])
GO
ALTER TABLE [dbo].[TTiaoma] CHECK CONSTRAINT [FK_TTiaoma_TKuanhao]
GO
/****** Object:  ForeignKey [FK_TTiaoma_TUser]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TTiaoma]  WITH CHECK ADD  CONSTRAINT [FK_TTiaoma_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TTiaoma] CHECK CONSTRAINT [FK_TTiaoma_TUser]
GO
/****** Object:  ForeignKey [FK_TKuanhao_TJiamengshang]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TKuanhao]  WITH CHECK ADD  CONSTRAINT [FK_TKuanhao_TJiamengshang] FOREIGN KEY([jmsid])
REFERENCES [dbo].[TJiamengshang] ([id])
GO
ALTER TABLE [dbo].[TKuanhao] CHECK CONSTRAINT [FK_TKuanhao_TJiamengshang]
GO
/****** Object:  ForeignKey [FK_TKuanhao_TUser]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TKuanhao]  WITH CHECK ADD  CONSTRAINT [FK_TKuanhao_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TKuanhao] CHECK CONSTRAINT [FK_TKuanhao_TUser]
GO
/****** Object:  ForeignKey [FK_THuiyuan_TFendian]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[THuiyuan]  WITH CHECK ADD  CONSTRAINT [FK_THuiyuan_TFendian] FOREIGN KEY([fendianid])
REFERENCES [dbo].[TFendian] ([id])
GO
ALTER TABLE [dbo].[THuiyuan] CHECK CONSTRAINT [FK_THuiyuan_TFendian]
GO
/****** Object:  ForeignKey [FK_THuiyuan_TJiamengshang]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[THuiyuan]  WITH CHECK ADD  CONSTRAINT [FK_THuiyuan_TJiamengshang] FOREIGN KEY([jmsid])
REFERENCES [dbo].[TJiamengshang] ([id])
GO
ALTER TABLE [dbo].[THuiyuan] CHECK CONSTRAINT [FK_THuiyuan_TJiamengshang]
GO
/****** Object:  ForeignKey [FK_TGongyingshang_TJiamengshang]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TGongyingshang]  WITH CHECK ADD  CONSTRAINT [FK_TGongyingshang_TJiamengshang] FOREIGN KEY([jmsid])
REFERENCES [dbo].[TJiamengshang] ([id])
GO
ALTER TABLE [dbo].[TGongyingshang] CHECK CONSTRAINT [FK_TGongyingshang_TJiamengshang]
GO
/****** Object:  ForeignKey [FK_TGongyingshang_TUser]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TGongyingshang]  WITH CHECK ADD  CONSTRAINT [FK_TGongyingshang_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TGongyingshang] CHECK CONSTRAINT [FK_TGongyingshang_TUser]
GO
/****** Object:  ForeignKey [FK_TFendian_TJiamengshang]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TFendian]  WITH CHECK ADD  CONSTRAINT [FK_TFendian_TJiamengshang] FOREIGN KEY([jmsid])
REFERENCES [dbo].[TJiamengshang] ([id])
GO
ALTER TABLE [dbo].[TFendian] CHECK CONSTRAINT [FK_TFendian_TJiamengshang]
GO
/****** Object:  ForeignKey [FK_TFendian_TUser]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TFendian]  WITH CHECK ADD  CONSTRAINT [FK_TFendian_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TFendian] CHECK CONSTRAINT [FK_TFendian_TUser]
GO
/****** Object:  ForeignKey [FK_TCangku_TJiamengshang]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangku]  WITH CHECK ADD  CONSTRAINT [FK_TCangku_TJiamengshang] FOREIGN KEY([jmsid])
REFERENCES [dbo].[TJiamengshang] ([id])
GO
ALTER TABLE [dbo].[TCangku] CHECK CONSTRAINT [FK_TCangku_TJiamengshang]
GO
/****** Object:  ForeignKey [FK_TCangku_TUser]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TCangku]  WITH CHECK ADD  CONSTRAINT [FK_TCangku_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TCangku] CHECK CONSTRAINT [FK_TCangku_TUser]
GO
/****** Object:  ForeignKey [FK_TJiamengshang_TUser]    Script Date: 09/01/2015 12:33:19 ******/
ALTER TABLE [dbo].[TJiamengshang]  WITH CHECK ADD  CONSTRAINT [FK_TJiamengshang_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TJiamengshang] CHECK CONSTRAINT [FK_TJiamengshang_TUser]
GO
