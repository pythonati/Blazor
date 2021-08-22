USE [HomeMoney]
GO

/****** Объект: Table [dbo].[Roles] Дата скрипта: 22.08.2021 8:41:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (150) NOT NULL
);


