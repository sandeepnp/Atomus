USE [Atomus]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetEmployees]    Script Date: 26/11/2017 11:17:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_GetEmployees]

AS
BEGIN

	SELECT [Id]
	      ,[FirstName]
	      ,[LastName]
	      ,[Company]
	      ,[Address]
	      ,[City]
	      ,[County]
	      ,[Postcode]
	      ,[Phone1]
	      ,[Phone2]
	      ,[Email]
	      ,[Website]
	      ,[Created]
	      ,[Updated]
	  FROM [dbo].[Employee]

END

GO


