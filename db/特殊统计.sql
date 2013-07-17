declare @start_hour int,
        @end_hour int,
        @start_date datetime,
        @end_date datetime        

select @start_hour=9,
       @end_hour=9,
       @end_date=getdate(),
       @start_date=dateadd(day,-14,@end_date)

--日期
select 
	convert(varchar(13),min(RetTime),120) as StartRetDate,
	convert(varchar(13),max(RetTime),120) as EndRetDate,
	null as Big,
	null as Small,
	null as Center,
	null as Side,
	null as Odd,
	null as Even,
	null as NotAppear,
	null as GradeNum
	 into #main_tbl
from dbo.SourceData_28_Beijing 
where datepart(hour,RetTime)>=@start_hour and
      datepart(hour,RetTime)<=@end_hour and
      (convert(varchar(10),RetTime,120) between convert(varchar(10),@start_date,120) and convert(varchar(10),@end_date,120))
group by datepart(day,RetTime)

--大小
update #main_tbl
set Big=select count(1)
from dbo.ResultCategory_28 rc
	join 

select * from #main_tbl

drop table #main_tbl