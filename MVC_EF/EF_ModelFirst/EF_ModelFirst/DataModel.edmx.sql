
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/02/2015 12:10:12
-- Generated from EDMX file: \\psf\Home\Documents\Visual Studio 2013\Projects\EF_ModelFirst\EF_ModelFirst\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_UserOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_UserR_Department_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Department_User] DROP CONSTRAINT [FK_UserR_Department_User];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentR_Department_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_Department_User] DROP CONSTRAINT [FK_DepartmentR_Department_User];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentClass_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentClass] DROP CONSTRAINT [FK_StudentClass_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentClass_Class]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentClass] DROP CONSTRAINT [FK_StudentClass_Class];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[R_Department_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_Department_User];
GO
IF OBJECT_ID(N'[dbo].[Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Student];
GO
IF OBJECT_ID(N'[dbo].[Class]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Class];
GO
IF OBJECT_ID(N'[dbo].[StudentClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentClass];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NOT NULL,
    [Address] nvarchar(256)  NOT NULL,
    [Phone] nvarchar(16)  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderTime] datetime  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'R_Department_User'
CREATE TABLE [dbo].[R_Department_User] (
    [R_Department_UserId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [DepartmentId] int  NOT NULL
);
GO

-- Creating table 'Student'
CREATE TABLE [dbo].[Student] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Class'
CREATE TABLE [dbo].[Class] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'StudentClass'
CREATE TABLE [dbo].[StudentClass] (
    [Student_Id] int  NOT NULL,
    [Class_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [R_Department_UserId] in table 'R_Department_User'
ALTER TABLE [dbo].[R_Department_User]
ADD CONSTRAINT [PK_R_Department_User]
    PRIMARY KEY CLUSTERED ([R_Department_UserId] ASC);
GO

-- Creating primary key on [Id] in table 'Student'
ALTER TABLE [dbo].[Student]
ADD CONSTRAINT [PK_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Class'
ALTER TABLE [dbo].[Class]
ADD CONSTRAINT [PK_Class]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Student_Id], [Class_Id] in table 'StudentClass'
ALTER TABLE [dbo].[StudentClass]
ADD CONSTRAINT [PK_StudentClass]
    PRIMARY KEY CLUSTERED ([Student_Id], [Class_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_UserOrder]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOrder'
CREATE INDEX [IX_FK_UserOrder]
ON [dbo].[Order]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'R_Department_User'
ALTER TABLE [dbo].[R_Department_User]
ADD CONSTRAINT [FK_UserR_Department_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserR_Department_User'
CREATE INDEX [IX_FK_UserR_Department_User]
ON [dbo].[R_Department_User]
    ([UserId]);
GO

-- Creating foreign key on [DepartmentId] in table 'R_Department_User'
ALTER TABLE [dbo].[R_Department_User]
ADD CONSTRAINT [FK_DepartmentR_Department_User]
    FOREIGN KEY ([DepartmentId])
    REFERENCES [dbo].[Department]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentR_Department_User'
CREATE INDEX [IX_FK_DepartmentR_Department_User]
ON [dbo].[R_Department_User]
    ([DepartmentId]);
GO

-- Creating foreign key on [Student_Id] in table 'StudentClass'
ALTER TABLE [dbo].[StudentClass]
ADD CONSTRAINT [FK_StudentClass_Student]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Class_Id] in table 'StudentClass'
ALTER TABLE [dbo].[StudentClass]
ADD CONSTRAINT [FK_StudentClass_Class]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[Class]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentClass_Class'
CREATE INDEX [IX_FK_StudentClass_Class]
ON [dbo].[StudentClass]
    ([Class_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------