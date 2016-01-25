
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/24/2016 16:09:12
-- Generated from EDMX file: D:\CCCC#\BlaBla\PromosiMVC\PromosiMVC\PromosiDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PromosDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserPushes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PushesSet] DROP CONSTRAINT [FK_UserPushes];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyPush]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PushSet] DROP CONSTRAINT [FK_CompanyPush];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanySet] DROP CONSTRAINT [FK_BranchCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_CityCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanySet] DROP CONSTRAINT [FK_CityCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_PushPushes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PushesSet] DROP CONSTRAINT [FK_PushPushes];
GO
IF OBJECT_ID(N'[dbo].[FK_LogTypeLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogSet] DROP CONSTRAINT [FK_LogTypeLog];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyFollowings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FollowingsSet] DROP CONSTRAINT [FK_CompanyFollowings];
GO
IF OBJECT_ID(N'[dbo].[FK_UserFollowings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FollowingsSet] DROP CONSTRAINT [FK_UserFollowings];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[CompanySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanySet];
GO
IF OBJECT_ID(N'[dbo].[BranchSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BranchSet];
GO
IF OBJECT_ID(N'[dbo].[CitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CitySet];
GO
IF OBJECT_ID(N'[dbo].[PushSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PushSet];
GO
IF OBJECT_ID(N'[dbo].[PushesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PushesSet];
GO
IF OBJECT_ID(N'[dbo].[LogSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogSet];
GO
IF OBJECT_ID(N'[dbo].[LogTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogTypeSet];
GO
IF OBJECT_ID(N'[dbo].[FollowingsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FollowingsSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Surname] nvarchar(max)  NULL,
    [Phonenumber] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [RegistrationId] nvarchar(max)  NOT NULL,
    [DeviceToken] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CompanySet'
CREATE TABLE [dbo].[CompanySet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [NIP] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Phonenumber] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [ChannelName] nvarchar(max)  NOT NULL,
    [BranchId] bigint  NOT NULL,
    [CityId] bigint  NOT NULL
);
GO

-- Creating table 'BranchSet'
CREATE TABLE [dbo].[BranchSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CitySet'
CREATE TABLE [dbo].[CitySet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PushSet'
CREATE TABLE [dbo].[PushSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Available] bit  NOT NULL,
    [CompanyId] bigint  NOT NULL
);
GO

-- Creating table 'PushesSet'
CREATE TABLE [dbo].[PushesSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [PushId] bigint  NOT NULL,
    [UserId] bigint  NOT NULL,
    [Checked] bit  NOT NULL
);
GO

-- Creating table 'LogSet'
CREATE TABLE [dbo].[LogSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ObjectId] bigint  NOT NULL,
    [ObjectType] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [LogTypeId] bigint  NOT NULL
);
GO

-- Creating table 'LogTypeSet'
CREATE TABLE [dbo].[LogTypeSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FollowingsSet'
CREATE TABLE [dbo].[FollowingsSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CompanyId] bigint  NOT NULL,
    [UserId] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompanySet'
ALTER TABLE [dbo].[CompanySet]
ADD CONSTRAINT [PK_CompanySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BranchSet'
ALTER TABLE [dbo].[BranchSet]
ADD CONSTRAINT [PK_BranchSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CitySet'
ALTER TABLE [dbo].[CitySet]
ADD CONSTRAINT [PK_CitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PushSet'
ALTER TABLE [dbo].[PushSet]
ADD CONSTRAINT [PK_PushSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PushesSet'
ALTER TABLE [dbo].[PushesSet]
ADD CONSTRAINT [PK_PushesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogSet'
ALTER TABLE [dbo].[LogSet]
ADD CONSTRAINT [PK_LogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogTypeSet'
ALTER TABLE [dbo].[LogTypeSet]
ADD CONSTRAINT [PK_LogTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FollowingsSet'
ALTER TABLE [dbo].[FollowingsSet]
ADD CONSTRAINT [PK_FollowingsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'PushesSet'
ALTER TABLE [dbo].[PushesSet]
ADD CONSTRAINT [FK_UserPushes]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPushes'
CREATE INDEX [IX_FK_UserPushes]
ON [dbo].[PushesSet]
    ([UserId]);
GO

-- Creating foreign key on [CompanyId] in table 'PushSet'
ALTER TABLE [dbo].[PushSet]
ADD CONSTRAINT [FK_CompanyPush]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[CompanySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyPush'
CREATE INDEX [IX_FK_CompanyPush]
ON [dbo].[PushSet]
    ([CompanyId]);
GO

-- Creating foreign key on [BranchId] in table 'CompanySet'
ALTER TABLE [dbo].[CompanySet]
ADD CONSTRAINT [FK_BranchCompany]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[BranchSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchCompany'
CREATE INDEX [IX_FK_BranchCompany]
ON [dbo].[CompanySet]
    ([BranchId]);
GO

-- Creating foreign key on [CityId] in table 'CompanySet'
ALTER TABLE [dbo].[CompanySet]
ADD CONSTRAINT [FK_CityCompany]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[CitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityCompany'
CREATE INDEX [IX_FK_CityCompany]
ON [dbo].[CompanySet]
    ([CityId]);
GO

-- Creating foreign key on [PushId] in table 'PushesSet'
ALTER TABLE [dbo].[PushesSet]
ADD CONSTRAINT [FK_PushPushes]
    FOREIGN KEY ([PushId])
    REFERENCES [dbo].[PushSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PushPushes'
CREATE INDEX [IX_FK_PushPushes]
ON [dbo].[PushesSet]
    ([PushId]);
GO

-- Creating foreign key on [LogTypeId] in table 'LogSet'
ALTER TABLE [dbo].[LogSet]
ADD CONSTRAINT [FK_LogTypeLog]
    FOREIGN KEY ([LogTypeId])
    REFERENCES [dbo].[LogTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogTypeLog'
CREATE INDEX [IX_FK_LogTypeLog]
ON [dbo].[LogSet]
    ([LogTypeId]);
GO

-- Creating foreign key on [CompanyId] in table 'FollowingsSet'
ALTER TABLE [dbo].[FollowingsSet]
ADD CONSTRAINT [FK_CompanyFollowings]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[CompanySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyFollowings'
CREATE INDEX [IX_FK_CompanyFollowings]
ON [dbo].[FollowingsSet]
    ([CompanyId]);
GO

-- Creating foreign key on [UserId] in table 'FollowingsSet'
ALTER TABLE [dbo].[FollowingsSet]
ADD CONSTRAINT [FK_UserFollowings]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFollowings'
CREATE INDEX [IX_FK_UserFollowings]
ON [dbo].[FollowingsSet]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------