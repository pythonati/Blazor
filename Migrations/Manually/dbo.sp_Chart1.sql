USE [HomeMoney]
GO

/****** Object:  StoredProcedure [dbo].[sp_Chart1]    Script Date: 2021-07-27 9:13:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER     PROCEDURE [dbo].[sp_Chart1]
	@dateFrom date = getdate,
	@dateTo date = getdate,
	@accountTypes varchar(max) = null,
	@categoryTypes varchar(max) = null
AS
	select
		CategoryId,
		CategoryName,
		sum(Amount) as Amount
	from
		(
			select
				cast(t.Amount as float) as Amount,
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
				TranType = 1
				and
				(
					@accountTypes is null
					or
					@accountTypes = ''
					or
					charindex('[' + cast(t.AccountId as varchar) + ']', @accountTypes) > 0
				)
				and
				(
					@categoryTypes is null
					or
					@categoryTypes = ''
					or
					charindex('[' + cast(t.CategoryId as varchar) + ']', @categoryTypes) > 0
				)
		) tb
	group by
		CategoryId,
		CategoryName
	order by
		CategoryName

GO


