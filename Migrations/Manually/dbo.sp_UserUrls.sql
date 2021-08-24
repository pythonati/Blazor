USE [HomeMoney]
GO

/****** Object:  StoredProcedure [dbo].[sp_UserUrls]    Script Date: 23.08.2021 17:59:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER                PROCEDURE [dbo].[sp_UserUrls]
	@pUserId int
AS

	select distinct
		upper(ru.Url) as Url
	from
		UserRoles ur
		inner join RoleUrls ru on ru.RoleId = ur.RoleId
	where
		ur.UserId = @pUserId
GO


