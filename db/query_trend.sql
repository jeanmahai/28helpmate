DECLARE @START_DATE DATETIME,
		@END_DATE DATETIME,
		@PAGE_SIZE INT,
		@PAGE_INDEX INT,
		@SiteSysNo INT
SELECT @START_DATE=CONVERT(DATETIME,'2013/7/8 00:00:00'),
@END_DATE=CONVERT(DATETIME,'2013/7/8 23:59:59'),
@PAGE_SIZE=10,
@PAGE_INDEX=1,
@SiteSysNo=10001

--SELECT COUNT(1) AS TOTAL
--FROM dbo.SourceData_28_Beijing
--WHERE (RetTime BETWEEN @START_DATE AND @END_DATE)

--SELECT RetNum,COUNT(RetNum) AS TIMES
--FROM dbo.SourceData_28_Beijing
--WHERE (RetTime BETWEEN @START_DATE AND @END_DATE)
--GROUP BY RetNum

SELECT *
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.UseSite US ON BJ.SiteSysNo=US.SysNo
WHERE (RetTime BETWEEN @START_DATE AND @END_DATE)
	AND US.SysNo=@SiteSysNo
order by BJ.PeriodNum DESC


(
SELECT RC.BigOrSmall AS Name
      ,COUNT(RC.BigOrSmall) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
	INNER JOIN DBO.UseSite US
    ON BJ.SiteSysNo=US.SysNo
WHERE BJ.RetTime BETWEEN @START_DATE AND @END_DATE
	AND US.SysNo=@SiteSysNo
GROUP BY RC.BigOrSmall
)
union
(
SELECT RC.MiddleOrSide AS Name
      ,COUNT(RC.MiddleOrSide) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
		INNER JOIN DBO.UseSite US
    ON BJ.SiteSysNo=US.SysNo
WHERE BJ.RetTime BETWEEN @START_DATE AND @END_DATE
AND US.SysNo=@SiteSysNo
GROUP BY RC.MiddleOrSide
)
union
(
SELECT RC.OddOrDual AS Name
      ,COUNT(RC.OddOrDual) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
		INNER JOIN DBO.UseSite US
    ON BJ.SiteSysNo=US.SysNo
WHERE BJ.RetTime BETWEEN @START_DATE AND @END_DATE
AND US.SysNo=@SiteSysNo
GROUP BY RC.OddOrDual
)
union
(
SELECT convert(nvarchar(40),RetNum) as Name,
	   COUNT(RetNum) AS Total
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.UseSite US
		ON BJ.SiteSysNo=US.SysNo
WHERE (RetTime BETWEEN @START_DATE AND @END_DATE)
	AND US.SysNo=@SiteSysNo
GROUP BY RetNum
)