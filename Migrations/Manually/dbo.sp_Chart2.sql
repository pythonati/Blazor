USE [HomeMoney]
GO

/****** Object:  StoredProcedure [dbo].[sp_Chart2]    Script Date: 2021-07-26 1:08:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE OR ALTER     PROCEDURE [dbo].[sp_Chart2]
	@dateFrom date = getdate,
	@dateTo date = getdate,
	@accountTypes varchar(max) = null,
	@categoryTypes varchar(max) = null,
	@labelTypes varchar(max) = null
AS

	select
		CategoryId,
		CategoryName,
		LabelId,
		LabelName,
		sum(Amount) as Amount
	from
		(
			select
				cast(t.Amount as float) as Amount,
				t.CategoryId,
				c.Name as CategoryName,
				isnull(l.Id, 0) as LabelId,
				l.Name as LabelName
			from
				Trans t
				left join Accounts a on a.id = t.AccountId
				left join Category c on c.id = t.CategoryId
				left join TransLables tl on tl.TransactionId = t.Id
				left join Lables l on l.Id = tl.LableId
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
				and
				(
					@labelTypes is null
					or
					@labelTypes = ''
					or
					charindex(cast(tl.LableId as varchar) + ',', @labelTypes) > 0
				)
		) tb
	group by
		CategoryId,
		CategoryName,
		LabelId,
		LabelName
	order by
		CategoryName,
		LabelName

GO


