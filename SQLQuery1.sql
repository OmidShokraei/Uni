CREATE DATABASE UniDB;
GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/05/2025 12:23:18
-- Generated from EDMX file: C:\Users\p\Desktop\programming\mentor\Uni\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Model1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tbl_courses_tbl_category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_courses] DROP CONSTRAINT [FK_tbl_courses_tbl_category];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_courses_tbl_img]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_courses] DROP CONSTRAINT [FK_tbl_courses_tbl_img];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_courses_tbl_teachers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_courses] DROP CONSTRAINT [FK_tbl_courses_tbl_teachers];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_pages_tbl_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_pages] DROP CONSTRAINT [FK_tbl_pages_tbl_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_Posts_tbl_teachers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Posts] DROP CONSTRAINT [FK_tbl_Posts_tbl_teachers];
GO
IF OBJECT_ID(N'[dbo].[FK_tbl_teachers_tbl_img]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_teachers] DROP CONSTRAINT [FK_tbl_teachers_tbl_img];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tbl_About]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_About];
GO
IF OBJECT_ID(N'[dbo].[tbl_admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_admins];
GO
IF OBJECT_ID(N'[dbo].[tbl_Banners]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Banners];
GO
IF OBJECT_ID(N'[dbo].[tbl_category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_category];
GO
IF OBJECT_ID(N'[dbo].[tbl_courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_courses];
GO
IF OBJECT_ID(N'[dbo].[tbl_img]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_img];
GO
IF OBJECT_ID(N'[dbo].[tbl_Languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Languages];
GO
IF OBJECT_ID(N'[dbo].[tbl_pages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_pages];
GO
IF OBJECT_ID(N'[dbo].[tbl_Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Posts];
GO
IF OBJECT_ID(N'[dbo].[tbl_student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_student];
GO
IF OBJECT_ID(N'[dbo].[tbl_teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_teachers];
GO
IF OBJECT_ID(N'[dbo].[tble_events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tble_events];
GO
IF OBJECT_ID(N'[schoolModelStoreContainer].[View_teachers]', 'U') IS NOT NULL
    DROP TABLE [schoolModelStoreContainer].[View_teachers];
GO
IF OBJECT_ID(N'[schoolModelStoreContainer].[View_courses]', 'U') IS NOT NULL
    DROP TABLE [schoolModelStoreContainer].[View_courses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tbl_student'
CREATE TABLE [dbo].[tbl_student] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(20)  NOT NULL,
    [family] nvarchar(20)  NOT NULL,
    [email] varchar(100)  NOT NULL,
    [password] nvarchar(50)  NOT NULL,
    [phone] varchar(20)  NULL
);
GO

-- Creating table 'tbl_teachers'
CREATE TABLE [dbo].[tbl_teachers] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [Family] nvarchar(20)  NOT NULL,
    [fkImg] int  NULL
);
GO

-- Creating table 'tble_events'
CREATE TABLE [dbo].[tble_events] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(50)  NOT NULL,
    [dis] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'tbl_admins'
CREATE TABLE [dbo].[tbl_admins] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [family] nvarchar(50)  NOT NULL,
    [email] varchar(100)  NOT NULL,
    [password] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tbl_category'
CREATE TABLE [dbo].[tbl_category] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tbl_img'
CREATE TABLE [dbo].[tbl_img] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [address] nvarchar(100)  NOT NULL,
    [alt] nvarchar(100)  NULL,
    [title] nvarchar(100)  NULL
);
GO

-- Creating table 'tbl_courses'
CREATE TABLE [dbo].[tbl_courses] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [title] nvarchar(50)  NOT NULL,
    [fkCat] int  NOT NULL,
    [dis] nvarchar(300)  NOT NULL,
    [img] int  NULL,
    [fkTeacherID] int  NULL,
    [status] bit  NOT NULL
);
GO

-- Creating table 'View_courses'
CREATE TABLE [dbo].[View_courses] (
    [pkID] int  NOT NULL,
    [title] nvarchar(50)  NOT NULL,
    [fkCat] int  NOT NULL,
    [dis] nvarchar(300)  NOT NULL,
    [img] int  NULL,
    [fkTeacherID] int  NULL,
    [Name] nvarchar(20)  NULL,
    [Family] nvarchar(20)  NULL,
    [catTitle] nvarchar(50)  NULL,
    [address] nvarchar(100)  NULL,
    [alt] nvarchar(100)  NULL,
    [imgTitle] nvarchar(100)  NULL,
    [status] bit  NOT NULL
);
GO

-- Creating table 'View_teachers'
CREATE TABLE [dbo].[View_teachers] (
    [Name] nvarchar(20)  NOT NULL,
    [Family] nvarchar(20)  NOT NULL,
    [fkImg] int  NULL,
    [pkID] int  NOT NULL,
    [address] nvarchar(100)  NULL,
    [alt] nvarchar(100)  NULL,
    [title] nvarchar(100)  NULL
);
GO

-- Creating table 'tbl_Posts'
CREATE TABLE [dbo].[tbl_Posts] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Dis] nvarchar(200)  NOT NULL,
    [Contents] nvarchar(max)  NOT NULL,
    [fkWriter] int  NOT NULL,
    [DateOfWrite] datetime  NOT NULL,
    [Image] nvarchar(50)  NOT NULL,
    [ImageTitle] nvarchar(100)  NOT NULL,
    [ImageAlt] nvarchar(100)  NOT NULL,
    [KeyWords] nvarchar(200)  NOT NULL,
    [fkLangID] int  NULL
);
GO

-- Creating table 'tbl_Banners'
CREATE TABLE [dbo].[tbl_Banners] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [img] nvarchar(50)  NULL,
    [Title] nvarchar(100)  NULL,
    [Dis] nvarchar(100)  NULL,
    [Url] nvarchar(50)  NULL,
    [ButtonCaption] nvarchar(50)  NULL,
    [imgAlt] nvarchar(50)  NULL,
    [imgTitle] nvarchar(50)  NULL
);
GO

-- Creating table 'tbl_About'
CREATE TABLE [dbo].[tbl_About] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [Items] nvarchar(max)  NULL,
    [Image] nvarchar(100)  NULL,
    [ImageAlt] nvarchar(50)  NULL,
    [ImageTitle] nvarchar(50)  NULL,
    [ButtonCaption] nvarchar(50)  NULL,
    [ButtonUrl] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [Dis] nvarchar(100)  NULL
);
GO

-- Creating table 'tbl_pages'
CREATE TABLE [dbo].[tbl_pages] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Dis] nvarchar(100)  NULL,
    [Title] nvarchar(100)  NULL,
    [keyword] nvarchar(100)  NULL,
    [Action] nvarchar(100)  NULL,
    [fkLangID] int  NULL
);
GO

-- Creating table 'tbl_Languages'
CREATE TABLE [dbo].[tbl_Languages] (
    [pkID] int IDENTITY(1,1) NOT NULL,
    [Lang] nvarchar(100)  NOT NULL,
    [Icon] nvarchar(50)  NOT NULL,
    [status] bit  NULL,
    [direction] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [pkID] in table 'tbl_student'
ALTER TABLE [dbo].[tbl_student]
ADD CONSTRAINT [PK_tbl_student]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_teachers'
ALTER TABLE [dbo].[tbl_teachers]
ADD CONSTRAINT [PK_tbl_teachers]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tble_events'
ALTER TABLE [dbo].[tble_events]
ADD CONSTRAINT [PK_tble_events]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_admins'
ALTER TABLE [dbo].[tbl_admins]
ADD CONSTRAINT [PK_tbl_admins]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_category'
ALTER TABLE [dbo].[tbl_category]
ADD CONSTRAINT [PK_tbl_category]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_img'
ALTER TABLE [dbo].[tbl_img]
ADD CONSTRAINT [PK_tbl_img]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_courses'
ALTER TABLE [dbo].[tbl_courses]
ADD CONSTRAINT [PK_tbl_courses]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID], [title], [fkCat], [dis], [status] in table 'View_courses'
ALTER TABLE [dbo].[View_courses]
ADD CONSTRAINT [PK_View_courses]
    PRIMARY KEY CLUSTERED ([pkID], [title], [fkCat], [dis], [status] ASC);
GO

-- Creating primary key on [Name], [Family], [pkID] in table 'View_teachers'
ALTER TABLE [dbo].[View_teachers]
ADD CONSTRAINT [PK_View_teachers]
    PRIMARY KEY CLUSTERED ([Name], [Family], [pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_Posts'
ALTER TABLE [dbo].[tbl_Posts]
ADD CONSTRAINT [PK_tbl_Posts]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_Banners'
ALTER TABLE [dbo].[tbl_Banners]
ADD CONSTRAINT [PK_tbl_Banners]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_About'
ALTER TABLE [dbo].[tbl_About]
ADD CONSTRAINT [PK_tbl_About]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_pages'
ALTER TABLE [dbo].[tbl_pages]
ADD CONSTRAINT [PK_tbl_pages]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- Creating primary key on [pkID] in table 'tbl_Languages'
ALTER TABLE [dbo].[tbl_Languages]
ADD CONSTRAINT [PK_tbl_Languages]
    PRIMARY KEY CLUSTERED ([pkID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [fkCat] in table 'tbl_courses'
ALTER TABLE [dbo].[tbl_courses]
ADD CONSTRAINT [FK_tbl_courses_tbl_category]
    FOREIGN KEY ([fkCat])
    REFERENCES [dbo].[tbl_category]
        ([pkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_courses_tbl_category'
CREATE INDEX [IX_FK_tbl_courses_tbl_category]
ON [dbo].[tbl_courses]
    ([fkCat]);
GO

-- Creating foreign key on [img] in table 'tbl_courses'
ALTER TABLE [dbo].[tbl_courses]
ADD CONSTRAINT [FK_tbl_courses_tbl_img]
    FOREIGN KEY ([img])
    REFERENCES [dbo].[tbl_img]
        ([pkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_courses_tbl_img'
CREATE INDEX [IX_FK_tbl_courses_tbl_img]
ON [dbo].[tbl_courses]
    ([img]);
GO

-- Creating foreign key on [fkTeacherID] in table 'tbl_courses'
ALTER TABLE [dbo].[tbl_courses]
ADD CONSTRAINT [FK_tbl_courses_tbl_teachers]
    FOREIGN KEY ([fkTeacherID])
    REFERENCES [dbo].[tbl_teachers]
        ([pkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_courses_tbl_teachers'
CREATE INDEX [IX_FK_tbl_courses_tbl_teachers]
ON [dbo].[tbl_courses]
    ([fkTeacherID]);
GO

-- Creating foreign key on [fkImg] in table 'tbl_teachers'
ALTER TABLE [dbo].[tbl_teachers]
ADD CONSTRAINT [FK_tbl_teachers_tbl_img]
    FOREIGN KEY ([fkImg])
    REFERENCES [dbo].[tbl_img]
        ([pkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_teachers_tbl_img'
CREATE INDEX [IX_FK_tbl_teachers_tbl_img]
ON [dbo].[tbl_teachers]
    ([fkImg]);
GO

-- Creating foreign key on [fkWriter] in table 'tbl_Posts'
ALTER TABLE [dbo].[tbl_Posts]
ADD CONSTRAINT [FK_tbl_Posts_tbl_teachers]
    FOREIGN KEY ([fkWriter])
    REFERENCES [dbo].[tbl_teachers]
        ([pkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Posts_tbl_teachers'
CREATE INDEX [IX_FK_tbl_Posts_tbl_teachers]
ON [dbo].[tbl_Posts]
    ([fkWriter]);
GO

-- Creating foreign key on [fkLangID] in table 'tbl_pages'
ALTER TABLE [dbo].[tbl_pages]
ADD CONSTRAINT [FK_tbl_pages_tbl_Languages]
    FOREIGN KEY ([fkLangID])
    REFERENCES [dbo].[tbl_Languages]
        ([pkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_pages_tbl_Languages'
CREATE INDEX [IX_FK_tbl_pages_tbl_Languages]
ON [dbo].[tbl_pages]
    ([fkLangID]);
GO

-- Creating foreign key on [fkLangID] in table 'tbl_Posts'
ALTER TABLE [dbo].[tbl_Posts]
ADD CONSTRAINT [FK_tbl_Posts_tbl_teachers1]
    FOREIGN KEY ([fkLangID])
    REFERENCES [dbo].[tbl_Languages]
        ([pkID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_Posts_tbl_teachers1'
CREATE INDEX [IX_FK_tbl_Posts_tbl_teachers1]
ON [dbo].[tbl_Posts]
    ([fkLangID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------


USE UniDB;
GO

INSERT INTO tbl_Banners(img,Title, Dis, Url, ButtonCaption, imgAlt, imgTitle) 
VALUES ('assets\img\Banners\hero-bg.jpg', 'عنوان','توضیحات','Views\Home\Index.cshtml','صفحه اصلی','عکس','عکس صفحه اصلی')
SELECT * FROM tbl_Banners;
INSERT INTO tbl_pages(Name)
VALUES ('Index'),('About');

SELECT * FROM tbl_pages;

INSERT INTO tbl_About(Title,Items)
VALUES ('درباره ما', 'درباره ما')

SELECT * FROM tbl_About;

INSERT INTO tbl_Languages(Lang,Icon,status)
VALUES ('English','assets\img\icons\england.png','true'),
('فارسی','assets\img\icons\iran.png','true')


SELECT * FROM tbl_Languages;