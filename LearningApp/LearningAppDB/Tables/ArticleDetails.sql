USE [LearningApp]
GO

/****** Object:  Table [dbo].[ArticleDetails]    Script Date: 05/30/2020 09:34:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticleDetails](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleName] [nvarchar](300) NOT NULL,
	[ArticleTypeID] [int] NOT NULL,
	[isSeries] [bit] NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [date] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_ArticleDetails] PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


