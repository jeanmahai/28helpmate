--��ѯ���20�ڵĽ��
--SELECT TOP 20 *
--FROM dbo.SourceData_28_Beijing
--WHERE SiteSysNo=10001
--ORDER BY PeriodNum DESC

--��ѯ���20�ڿ���������ͬ�Ľ��

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

--��ѯ���20�ں�����ͬ����һ�ڵĿ������,Ԥ�����һ�ڵ���һ��
select *
from dbo.SourceData_28_Beijing
where PeriodNum in ()
	and SiteSysNo=
order by PeriodNum desc
