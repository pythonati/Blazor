USE [HomeMoney]
GO

/****** Object: SqlProcedure [dbo].[sp_Chart1] Script Date: 2021-07-22 3:09:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[sp_Chart1];


GO


CREATE PROCEDURE [dbo].[sp_Chart1]
	@dateFrom date = getdate,
	@dateTo date = getdate,
	@accountTypes varchar(max) = null,
	@categoryTypes varchar(max) = null
AS
	select
		AccountId,
		AccountName,
		CategoryId,
		CategoryName,
		sum(Amount) as Amount
	from
		(
			select
				cast(t.Amount as float) as Amount,
				t.AccountId,
				a.Name as AccountName,
				t.CategoryId,
				c.Name as CategoryName
			from
				Trans t
				left join Accounts a on a.id = t.AccountId
				left join Category c on c.id = t.CategoryId
			where
				Date >= @dateFrom
				and
				Date < dateadd(day, 1, @dateTo)
				and
				Amount < 0
				and
				(
					@accountTypes is null
					or
					@accountTypes = ''
					or
					charindex(cast(t.AccountId as varchar) + ',', @accountTypes) > 0
				)
				and
				(
					@categoryTypes is null
					or
					@categoryTypes = ''
					or
					charindex(cast(t.CategoryId as varchar) + ',', @categoryTypes) > 0
				)
		) tb
	group by
		AccountId,
		AccountName,
		CategoryId,
		CategoryName
