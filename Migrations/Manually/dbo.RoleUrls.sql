USE [HomeMoney]
GO

/****** Объект: Table [dbo].[RoleUrls] Дата скрипта: 22.08.2021 8:42:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleUrls] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [RoleId] INT           NOT NULL,
    [Url]    VARCHAR (250) NOT NULL
);


