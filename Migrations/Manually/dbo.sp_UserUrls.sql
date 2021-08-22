USE [HomeMoney]
GO

/****** Объект: SqlProcedure [dbo].[sp_UserUrls] Дата скрипта: 22.08.2021 8:48:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE                PROCEDURE [dbo].[sp_UserUrls]
	@pUserId int
AS

	select distinct
		ru.Url
	from
		UserRoles ur
		inner join RoleUrls ru on ru.RoleId = ur.RoleId
	where
		ur.UserId = @pUserId
