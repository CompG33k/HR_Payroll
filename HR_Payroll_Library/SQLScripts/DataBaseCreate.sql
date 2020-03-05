
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/05/2020 00:17:18
-- Generated from EDMX file: C:\Users\Nick\Source\Repos\HR_Payroll\HR_Payroll_Library\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HRDemoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_Benefit_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Benefit] DROP CONSTRAINT [fk_Benefit_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Dependent_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dependent] DROP CONSTRAINT [FK_Dependent_Employee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Benefit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Benefit];
GO
IF OBJECT_ID(N'[dbo].[Dependent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dependent];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [fname] nchar(10)  NULL,
    [lname] nchar(10)  NULL,
    [benefits] varchar(max)  NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [benefit_enrolled] bit  NOT NULL
);
GO

-- Creating table 'Benefits'
CREATE TABLE [dbo].[Benefits] (
    [id] decimal(18,0)  NOT NULL,
    [bcode] nchar(10)  NULL,
    [description] nchar(10)  NULL,
    [employeeID] int  NOT NULL
);
GO

-- Creating table 'Dependents'
CREATE TABLE [dbo].[Dependents] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [fname] nchar(10)  NULL,
    [lname] nchar(10)  NULL,
    [dcode] int  NULL,
    [employeeID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'Benefits'
ALTER TABLE [dbo].[Benefits]
ADD CONSTRAINT [PK_Benefits]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'Dependents'
ALTER TABLE [dbo].[Dependents]
ADD CONSTRAINT [PK_Dependents]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [employeeID] in table 'Benefits'
ALTER TABLE [dbo].[Benefits]
ADD CONSTRAINT [fk_Benefit_Employee]
    FOREIGN KEY ([employeeID])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Benefit_Employee'
CREATE INDEX [IX_fk_Benefit_Employee]
ON [dbo].[Benefits]
    ([employeeID]);
GO

-- Creating foreign key on [employeeID] in table 'Dependents'
ALTER TABLE [dbo].[Dependents]
ADD CONSTRAINT [FK_Dependent_Employee]
    FOREIGN KEY ([employeeID])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dependent_Employee'
CREATE INDEX [IX_FK_Dependent_Employee]
ON [dbo].[Dependents]
    ([employeeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------