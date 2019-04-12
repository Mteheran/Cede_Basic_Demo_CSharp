-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spInsert_Event
	@EventId uniqueidentifier, 
    @PersonalId uniqueidentifier,
	@Name nvarchar(200),
	@Description nvarchar(max),
	@EventDate datetime,
	@IsPrivate bit,
	@DateCreated datetime,
	@Status int,
	@IsDeleted bit

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[Event]
           ([EventId]
           ,[PersonalId]
           ,[Name]
           ,[Description]
           ,[EventDate]
           ,[IsPrivate]
           ,[DateCreated]
           ,[Status]
           ,[IsDeleted])
     VALUES
           (@EventId
           ,@PersonalId
           ,@Name
           ,@Description 
		   ,@EventDate
		   ,@IsPrivate   
           ,@DateCreated
		   ,@Status
		    ,@IsDeleted)

END
GO
