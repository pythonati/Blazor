use HomeMoney
go

insert into RoleUrls
	(
		RoleId,
		Url
	)
	select
		1,
		'/transaction'
