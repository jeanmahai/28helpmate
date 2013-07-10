--查询最近20期的结果
--SELECT TOP 20 *
--FROM dbo.SourceData_28_Beijing
--WHERE SiteSysNo=10001
--ORDER BY PeriodNum DESC

--查询最近20期开奖号码相同的结果

--DECLARE @Last_Num int,@Max_Period int
--select top 1 @Last_Num=RetNum,@Max_Period=PeriodNum
--from dbo.SourceData_28_Beijing
--where SiteSysNo=10001
--order by PeriodNum desc

--select top 20  *
--from dbo.SourceData_28_Beijing
--where RetNum=@Last_Num 
--	and PeriodNum<>@Max_Period
--	and SiteSysNo=10001
--order by PeriodNum desc

--查询最近20期号码相同的下一期的开奖结果,预测最近一期的下一期
select *
from dbo.SourceData_28_Beijing
where PeriodNum in ()
	and SiteSysNo=
order by PeriodNum desc
