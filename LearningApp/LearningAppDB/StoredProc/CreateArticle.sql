USE [LearningApp]
GO

/****** Object:  StoredProcedure [dbo].[CreateArticle]    Script Date: 05/30/2020 09:38:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateArticle] 
	-- Add the parameters for the stored procedure here
	@articleName nvarchar(50),
	@articleType nvarchar(20),
	@isSeries bit,
	@articleContent nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;
	

	declare @type int;
	declare @articleid int;
	set @type = (select top 1 ArticleTypeID from ArticleType where ArticleType = @articleType);
	
	insert into ArticleDetails(ArticleName,ArticleTypeID,isSeries,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy)
	values
	(@articleName,@type,@isSeries,GetDate(),'ajay',null,null)
	
	set @articleid = (select top 1 ArticleID from ArticleDetails where ArticleName = @articleName)
	
	insert into ArticleContentDetails(ArticleID,ArticleContent)
	values
	(@articleid,@articleContent)
	
    -- Insert statements for procedure here
	
END

GO


