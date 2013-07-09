DECLARE @MAX_TOTAL INT,
        @PAGE_INDEX INT,
        @PAGE_SIZE INT,
        @SITE_SYS_NO INT
SELECT @MAX_TOTAL=5000,
       @PAGE_INDEX=1,
       @PAGE_SIZE=10,
       @SITE_SYS_NO=10001

--查询每个号码及类型的出现次数,总次数以maxTotal为准
DECLARE @MAX_PERIOD INT
SELECT @MAX_PERIOD=MAX(PeriodNum) FROM dbo.SourceData_28_Beijing
DECLARE @MIN_PERIOD INT
SELECT @MIN_PERIOD=@MAX_PERIOD-@MAX_TOTAL


(
SELECT 
	CONVERT(NCHAR(40),BJ.RetNum) as Name,
	COUNT(BJ.RetNum) AS Total
FROM dbo.SourceData_28_Beijing BJ
	JOIN dbo.UseSite US 
		ON BJ.SiteSysNo=US.SysNo
WHERE BJ.SiteSysNo=@SITE_SYS_NO
	  AND BJ.PeriodNum>@MIN_PERIOD
	  --:CONDITION
GROUP BY BJ.RetNum
)
UNION ALL
(
SELECT RC.BigOrSmall AS Name,
       COUNT(RC.BigOrSmall) AS Total
FROM dbo.SourceData_28_Beijing BJ
	JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
	JOIN dbo.UseSite US
		ON BJ.SiteSysNo=US.SysNo
WHERE BJ.SiteSysNo=@SITE_SYS_NO
      AND BJ.PeriodNum>@MIN_PERIOD
      --:CONDITION
GROUP BY RC.BigOrSmall
)
UNION ALL
(
SELECT RC.MiddleOrSide AS Name,
       COUNT(RC.MiddleOrSide) AS Total
FROM dbo.SourceData_28_Beijing BJ
	JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
	JOIN dbo.UseSite US
		ON BJ.SiteSysNo=US.SysNo
WHERE BJ.SiteSysNo=@SITE_SYS_NO
      AND BJ.PeriodNum>@MIN_PERIOD
      --:CONDITION
GROUP BY RC.MiddleOrSide
)
UNION ALL
(
SELECT RC.OddOrDual AS Name,
       COUNT(RC.OddOrDual) AS Total
FROM dbo.SourceData_28_Beijing BJ
	JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
	JOIN dbo.UseSite US
		ON BJ.SiteSysNo=US.SysNo
WHERE BJ.SiteSysNo=@SITE_SYS_NO
      AND BJ.PeriodNum>@MIN_PERIOD
      --:CONDITION
GROUP BY RC.OddOrDual
)

--查询列表
SELECT COUNT(1) Total,
       @PAGE_INDEX PageIndex,
       @PAGE_SIZE PageSize,
       CEILING(COUNT(1)/CONVERT(DECIMAL,@PAGE_SIZE)) AS [PageCount]
FROM dbo.SourceData_28_Beijing BJ
	JOIN dbo.UseSite US
		ON BJ.SiteSysNo=US.SysNo
	JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
WHERE BJ.SiteSysNo=@SITE_SYS_NO
      AND BJ.PeriodNum>@MIN_PERIOD
      --:CONDITION

SELECT * FROM 
(
SELECT BJ.PeriodNum,
       BJ.RetTime,
       BJ.RetNum,
       RC.BigOrSmall,
       RC.MiddleOrSide,
       RC.OddOrDual,
       ROW_NUMBER() OVER (ORDER BY BJ.PeriodNum DESC) AS ROW
FROM dbo.SourceData_28_Beijing BJ
	JOIN dbo.UseSite US
		ON BJ.SiteSysNo=US.SysNo
	JOIN dbo.ResultCategory_28 RC
		ON BJ.RetNum=RC.RetNum
WHERE BJ.SiteSysNo=@SITE_SYS_NO
      AND BJ.PeriodNum>@MIN_PERIOD
      --:CONDITION
) AS TEMP
WHERE ROW>@PAGE_INDEX*@PAGE_SIZE
      AND ROW<(@PAGE_INDEX+1)*@PAGE_SIZE
      