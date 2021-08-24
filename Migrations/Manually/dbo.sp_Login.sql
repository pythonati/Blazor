USE [HomeMoney]
GO

/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 23.08.2021 17:15:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER              PROCEDURE [dbo].[sp_Login]
	@pLogin nvarchar(max),
	@pPassword varchar(max),
	@pLoginType int = 1
AS
	declare @existsUser int = 0
	declare @newUser int = 0
	declare @isPasswordEqual bit;
	
	set @pLogin = upper(@pLogin)

	select top 1
		@existsUser = Id,
		@isPasswordEqual = iif(Password = @pPassword, 1, 0)
	from
		Users
	where
		Login = @pLogin

	if @pLoginType = 2 and @existsUser = 0 begin		--Создать если нет такого пользователя
		insert into Users
			(
				Login,
				Password
			)
			select
				@pLogin,
				@pPassword

		select @newUser = scope_identity()

		--Присвоить пользователю Роль по умолчанию
		insert into UserRoles
			(
				UserId,
				RoleId
			)
			select
				@newUser,
				1
	end;

/*	--см. C# код
    public enum LoginResults
    {
        Registered = 1,
        Found = 2,
        NotFound = 3,
        NotRegistered = 4
    }
*/
	declare @Result int = 0
    declare @UserId int = 0

	if @pLoginType = 2 and @existsUser > 0
		set @Result = 4		--NotRegistered

	if @pLoginType = 2 and @existsUser = 0 begin
		set @Result = 1		--Registered
		set @UserId = @newUser
	end;

	if @pLoginType = 1 and @existsUser > 0 begin
		if @isPasswordEqual = 1 begin
			set @Result = 2		--Found
			set @UserId = @existsUser
		end
		else
			set @Result = 3		--NotFound
	end;

	if @pLoginType = 1 and @existsUser = 0 begin
		set @Result = 3		--NotFound
	end;

	select
        @Result as Result,
        @UserId as UserId
GO


