USE [HomeMoney]
GO

/****** Объект: Table [dbo].[Users] Дата скрипта: 11.08.2021 17:18:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (250) NOT NULL
);


