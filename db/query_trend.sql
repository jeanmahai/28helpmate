DECLARE @START_DATE DATETIME,
		@END_DATE DATETIME,
		@PAGE_SIZE INT,
		@PAGE_INDEX INT
SELECT @START_DATE=DATEADD(DAY,-1,GETDATE()),
@END_DATE=GETDATE(),
@PAGE_SIZE=10,
@PAGE_INDEX=1

--SELECT COUNT(1) AS TOTAL
--FROM dbo.SourceData_28_Beijing
--WHERE (RetTime BETWEEN @START_DATE AND @END_DATE)

--SELECT RetNum,COUNT(RetNum) AS TIMES
--FROM dbo.SourceData_28_Beijing
--WHERE (RetTime BETWEEN @START_DATE AND @END_DATE)
--GROUP BY RetNum

--SELECT *
--FROM (
--SELECT 
--	ROW_NUMBER() OVER  (ORDER BY PERIODNUM DESC) AS ROWNO,
--	*
--FROM dbo.SourceData_28_Beijing
--WHERE (RetTime BETWEEN @START_DATE AND @END_DATE)
--	) AS TEMP
--WHERE ROWNO>(@PAGE_SIZE*@PAGE_INDEX) AND ROWNO<(@PAGE_INDEX+1)*@PAGE_SIZE


(
SELECT RC.BigOrSmall AS Name
      ,COUNT(RC.BigOrSmall) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
WHERE BJ.RetTime BETWEEN @START_DATE AND @END_DATE
GROUP BY RC.BigOrSmall
)
union
(
SELECT RC.MiddleOrSide AS Name
      ,COUNT(RC.MiddleOrSide) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
WHERE BJ.RetTime BETWEEN @START_DATE AND @END_DATE
GROUP BY RC.MiddleOrSide
)
union
(
SELECT RC.OddOrDual AS Name
      ,COUNT(RC.OddOrDual) AS Total
      
FROM dbo.SourceData_28_Beijing BJ
	INNER JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
WHERE BJ.RetTime BETWEEN @START_DATE AND @END_DATE
GROUP BY RC.OddOrDual
)
union
(
SELECT convert(nvarchar(40),RetNum) as Name,
	   COUNT(RetNum) AS Total
FROM dbo.SourceData_28_Beijing
WHERE (RetTime BETWEEN @START_DATE AND @END_DATE)
GROUP BY RetNum
)