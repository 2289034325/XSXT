USE [CK]
GO
/****** Object:  Table [dbo].[TUser]    Script Date: 09/01/2015 12:34:09 ******/
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
/****** Object:  Table [dbo].[TTiaoma]    Script Date: 09/01/2015 12:34:09 ******/
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
/****** Object:  Table [dbo].[TChuruku]    Script Date: 09/01/2015 12:34:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TChuruku](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fangxiang] [tinyint] NOT NULL,
	[laiyuanquxiang] [tinyint] NOT NULL,
	[beizhu] [nvarchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[TKucunXZ]    Script Date: 09/01/2015 12:34:09 ******/
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
/****** Object:  Table [dbo].[TChurukuMX]    Script Date: 09/01/2015 12:34:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TChurukuMX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[churukuid] [int] NOT NULL,
	[tiaomaid] [int] NOT NULL,
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
/****** Object:  View [dbo].[VKucun]    Script Date: 09/01/2015 12:34:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VKucun]
AS

SELECT		C.id,ISNULL(B.shuliang,0) AS shuliang,B.jinhuoriqi
FROM		dbo.TTiaoma AS C
LEFT JOIN	
(SELECT		tiaomaid,CAST(SUM(shuliang) AS SMALLINT) AS shuliang,MAX(jinhuoriqi) AS jinhuoriqi
FROM

	--进货数量
	(SELECT		b.tiaomaid,b.shuliang,CAST(a.charushijian as DATE) AS jinhuoriqi
	FROM        dbo.TChuruku a
	INNER JOIN	dbo.TChurukuMX b
	ON			a.id = b.churukuid
	WHERE		fangxiang = 1

	UNION ALL

	--出货数量，取一个最小的时间值作为进货日期，以不影响真正进货记录之间的进货日期进行比较
	SELECT		b.tiaomaid,-b.shuliang,CAST( '1900-01-01' AS DATE) AS jinhuoriqi
	FROM        dbo.TChuruku a
	INNER JOIN	dbo.TChurukuMX b
	ON			a.id = b.churukuid
	WHERE		fangxiang = 2

	UNION ALL

	--库存修正，库存修正的记录，以插入时间作为进货日期
	SELECT		tiaomaid,shuliang,CAST(charushijian AS DATE) AS jinhuoriqi
	FROM		dbo.TKucunXZ) AS A

GROUP BY	tiaomaid) AS B
ON			C.id = B.tiaomaid
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TChuruku"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VKucun'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VKucun'
GO
/****** Object:  ForeignKey [FK_TChuruku_TUser]    Script Date: 09/01/2015 12:34:09 ******/
ALTER TABLE [dbo].[TChuruku]  WITH CHECK ADD  CONSTRAINT [FK_TChuruku_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TChuruku] CHECK CONSTRAINT [FK_TChuruku_TUser]
GO
/****** Object:  ForeignKey [FK_TKucunXZ_TTiaoma]    Script Date: 09/01/2015 12:34:09 ******/
ALTER TABLE [dbo].[TKucunXZ]  WITH CHECK ADD  CONSTRAINT [FK_TKucunXZ_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TKucunXZ] CHECK CONSTRAINT [FK_TKucunXZ_TTiaoma]
GO
/****** Object:  ForeignKey [FK_TKucunXZ_TUser]    Script Date: 09/01/2015 12:34:09 ******/
ALTER TABLE [dbo].[TKucunXZ]  WITH CHECK ADD  CONSTRAINT [FK_TKucunXZ_TUser] FOREIGN KEY([caozuorenid])
REFERENCES [dbo].[TUser] ([id])
GO
ALTER TABLE [dbo].[TKucunXZ] CHECK CONSTRAINT [FK_TKucunXZ_TUser]
GO
/****** Object:  ForeignKey [FK_TChurukuMX_TChuruku]    Script Date: 09/01/2015 12:34:09 ******/
ALTER TABLE [dbo].[TChurukuMX]  WITH CHECK ADD  CONSTRAINT [FK_TChurukuMX_TChuruku] FOREIGN KEY([churukuid])
REFERENCES [dbo].[TChuruku] ([id])
GO
ALTER TABLE [dbo].[TChurukuMX] CHECK CONSTRAINT [FK_TChurukuMX_TChuruku]
GO
/****** Object:  ForeignKey [FK_TChurukuMX_TTiaoma]    Script Date: 09/01/2015 12:34:09 ******/
ALTER TABLE [dbo].[TChurukuMX]  WITH CHECK ADD  CONSTRAINT [FK_TChurukuMX_TTiaoma] FOREIGN KEY([tiaomaid])
REFERENCES [dbo].[TTiaoma] ([id])
GO
ALTER TABLE [dbo].[TChurukuMX] CHECK CONSTRAINT [FK_TChurukuMX_TTiaoma]
GO
