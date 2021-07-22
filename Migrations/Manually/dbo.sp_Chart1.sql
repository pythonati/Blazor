USE [HomeMoney]
GO

/****** Object: SqlProcedure [dbo].[sp_Chart1] Script Date: 2021-07-22 8:02:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[sp_Chart1];


GO


CREATE PROCEDURE [dbo].[sp_Chart1]
	@dateFrom date = getdate,
	@dateTo date = getdate,
	@accountTypes nvarchar = null,
	@categoryTypes nvarchar = null
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
				left join Accounts a on a.id = t.AccountId and a.Id in (isnull(@accountTypes, a.Id))
				left join Category c on c.id = t.CategoryId and c.Id in (isnull(@categoryTypes, c.Id))
			where
				Date >= @dateFrom
				and
				Date < dateadd(day, 1, @dateTo)
				and
				Amount < 0
		) tb
	group by
		AccountId,
		AccountName,
		CategoryId,
		CategoryName
