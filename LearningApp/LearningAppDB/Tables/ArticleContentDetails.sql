USE [LearningApp]
GO

/****** Object:  Table [dbo].[ArticleContentDetails]    Script Date: 05/30/2020 08:50:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticleContentDetails](
	[ArticleContentID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleID] [int] NOT NULL,
	[ArticleContent] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ArticleContentDetails] PRIMARY KEY CLUSTERED 
(
	[ArticleContentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[ArticleContentDetails]  WITH CHECK ADD  CONSTRAINT [FK_ArticleContentDetails_ArticleDetails] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[ArticleDetails] ([ArticleID])
GO

ALTER TABLE [dbo].[ArticleContentDetails] CHECK CONSTRAINT [FK_ArticleContentDetails_ArticleDetails]
GO


