USE [LearningApp]
GO

/****** Object:  Table [dbo].[ArticleSeries]    Script Date: 05/30/2020 09:35:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticleSeries](
	[ArticleSeriesID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleID] [int] NOT NULL,
	[RelatedArticleID] [int] NOT NULL,
 CONSTRAINT [PK_ArticleSeries] PRIMARY KEY CLUSTERED 
(
	[ArticleSeriesID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ArticleSeries]  WITH CHECK ADD  CONSTRAINT [FK_ArticleSeries_ArticleDetails] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[ArticleDetails] ([ArticleID])
GO

ALTER TABLE [dbo].[ArticleSeries] CHECK CONSTRAINT [FK_ArticleSeries_ArticleDetails]
GO


