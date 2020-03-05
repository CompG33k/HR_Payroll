USE [HRDemoDB]
GO

/****** Object:  StoredProcedure [dbo].[GetEmployeeSummary]    Script Date: 3/5/2020 10:06:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEmployeeSummary]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ID]
      ,[fname]
      ,[lname]
      ,[StartDate]
      ,[benefit_enrolled]
	  ,[dbo].[GetNumberOfDependents]([ID]) as Dependents
	  ,[dbo].[GetYearsEmployed]([ID]) as YearsEmployed
  FROM [HRDemoDB].[dbo].[Employee]

END
GO


