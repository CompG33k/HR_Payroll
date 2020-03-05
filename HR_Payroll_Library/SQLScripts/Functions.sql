USE [HRDemoDB]
GO

/****** Object:  UserDefinedFunction [dbo].[GetYearsEmployed]    Script Date: 3/5/2020 10:07:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetYearsEmployed](@EmployeeID int)  
RETURNS int   
AS   
-- Returns the number of years employed.  
BEGIN  
    DECLARE @ret int;  
    
	SELECT @ret = YEAR(getDate()) - YEAR([StartDate]) 
	FROM
	[HRDemoDB].[dbo].[Employee]
	WHERE
	[EndDate] IS NULL
	AND 
	[ID] = @EmployeeID;

     IF (@ret IS NULL)   
        SET @ret = 0;  
    RETURN @ret;  
END; 

GO


USE [HRDemoDB]
GO

/****** Object:  UserDefinedFunction [dbo].[GetNumberOfDependents]    Script Date: 3/5/2020 10:07:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetNumberOfDependents](@EmployeeID int)  
RETURNS int   
AS   
-- Returns the number of years employed.  
BEGIN  
    DECLARE @ret int;  
    
	SELECT @ret = count(*) 
	FROM  [HRDemoDB].[dbo].[Dependent]
	where [employeeID] = @EmployeeID;

    IF (@ret IS NULL)   
        SET @ret = 0;  
    RETURN @ret;  
END; 


GO


