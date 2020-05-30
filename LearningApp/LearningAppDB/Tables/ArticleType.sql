USE [LearningApp]
GO

/****** Object:  Table [dbo].[ArticleType]    Script Date: 05/30/2020 09:36:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticleType](
	[ArticleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ArticleType] PRIMARY KEY CLUSTERED 
(
	[ArticleTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


