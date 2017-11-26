USE [Atomus]
GO

/****** Object:  StoredProcedure [dbo].[uspCreateEmployee]    Script Date: 26/11/2017 11:17:30 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[uspCreateEmployee] 
	 @FirstName nvarchar (200)
	,@LastName nvarchar (200) 
	,@Company nvarchar (200)
	,@Address nvarchar (500)
	,@City nvarchar (200)
	,@County nvarchar (200)
	,@Postcode nvarchar (10)
	,@Phone1 nvarchar (20)
	,@Phone2 nvarchar (20)
	,@Email nvarchar (100)
	,@Website nvarchar (500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON

	BEGIN
	    
			INSERT INTO [dbo].[Employee]
			           ([FirstName]
			           ,[LastName]
			           ,[Company]
			           ,[Address]
			           ,[City]
			           ,[County]
			           ,[Postcode]
			           ,[Phone1]
			           ,[Phone2]
			           ,[Email]
			           ,[Website])
			     VALUES
			           (@FirstName
			           ,@LastName 
			           ,@Company
			           ,@Address
			           ,@City
			           ,@County
			           ,@Postcode
			           ,@Phone1
			           ,@Phone2 
			           ,@Email
			           ,@Website)
			
			SELECT SCOPE_IDENTITY()
	END

END

GO


