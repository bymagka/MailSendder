
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/04/2021 20:38:20
-- Generated from EDMX file: D:\программирование\GeekBrains\c#\MailSender\MailSender\CinemaWorkplace\CinemaDataBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SessionTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketDatabase] DROP CONSTRAINT [FK_SessionTicket];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sessions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sessions];
GO
IF OBJECT_ID(N'[dbo].[TicketDatabase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketDatabase];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [SessionId] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Movie] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TicketDatabase'
CREATE TABLE [dbo].[TicketDatabase] (
    [Row] smallint  NOT NULL,
    [Place] smallint  NOT NULL,
    [Client] nvarchar(max)  NOT NULL,
    [SessionId] int  NOT NULL,
    [OrderID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SessionId] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [PK_Sessions]
    PRIMARY KEY CLUSTERED ([SessionId] ASC);
GO

-- Creating primary key on [OrderID] in table 'TicketDatabase'
ALTER TABLE [dbo].[TicketDatabase]
ADD CONSTRAINT [PK_TicketDatabase]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SessionId] in table 'TicketDatabase'
ALTER TABLE [dbo].[TicketDatabase]
ADD CONSTRAINT [FK_SessionTicket]
    FOREIGN KEY ([SessionId])
    REFERENCES [dbo].[Sessions]
        ([SessionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionTicket'
CREATE INDEX [IX_FK_SessionTicket]
ON [dbo].[TicketDatabase]
    ([SessionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------