CREATE TABLE [dbo].[TJintuihuo] (
    [id]           INT      IDENTITY (1, 1) NOT NULL,
    [jintui]       BIT      NOT NULL,
    [charushijian] DATETIME NOT NULL,
    CONSTRAINT [PK_TJinhuo] PRIMARY KEY CLUSTERED ([id] ASC)
);

