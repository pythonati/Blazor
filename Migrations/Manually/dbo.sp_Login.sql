USE [HomeMoney]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER     PROCEDURE [dbo].[sp_Login]
	@login nvarchar(max),
	@password varchar(max),
	@loginType int = 2
AS
	if loginType = 1 begin		--Создать если нет такого пользователя
		select
			Id
		from
			Users
		where
			Login = @login
	end;
		
GO


