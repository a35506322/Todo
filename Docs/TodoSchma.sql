USE [Todo]
GO

/****** Object:  Table [dbo].[TodoList]    Script Date: 2024/3/31 下午 08:28:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TodoList](
	[TodoId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[TodoContent] [nvarchar](500) NOT NULL,
	[IsComplete] [varchar](2) NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[CompleteTime] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TodoList] ADD  CONSTRAINT [DF_TodoList_TodoNo]  DEFAULT (newid()) FOR [TodoId]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TodoList', @level2type=N'COLUMN',@level2name=N'TodoId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TodoList', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'標題' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TodoList', @level2type=N'COLUMN',@level2name=N'Title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成事項內容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TodoList', @level2type=N'COLUMN',@level2name=N'TodoContent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否完成 (Y:是 N:否)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TodoList', @level2type=N'COLUMN',@level2name=N'IsComplete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新增時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TodoList', @level2type=N'COLUMN',@level2name=N'AddTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'完成時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TodoList', @level2type=N'COLUMN',@level2name=N'CompleteTime'
GO


