
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/01/2021 19:30:50
-- Generated from EDMX file: D:\программирование\GeekBrains\c#\MailSender\MailSender\CinemaWorkplace\CinemaDataBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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