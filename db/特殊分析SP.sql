-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SpecialAnalysis]
	-- Add the parameters for the stored procedure here
	@SourceSysNo INT,
	@SiteSysNo INT,
	@BeginHour INT,
	@EndHour INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--����б�
	DECLARE @TblResultList TABLE(Idx INT IDENTITY(1,1), Date NVARCHAR(20),
		Big INT, Small INT, Middle INT, Side INT, Odd INT, Dual INT);
	--δ���ֵĺ���
	DECLARE @TblNotList TABLE(Idx INT IDENTITY(1,1), Date NVARCHAR(20), RetNum INT);
	--��Ʒ��
	DECLARE @TblBestList TABLE(Idx INT IDENTITY(1,1), Date NVARCHAR(20), RetNum INT);	
	--��/С����/�ߣ���/˫ �ܿ���������
	DECLARE @TblCntList TABLE(AvgBig INT, AvgSmall INT, AvgMiddle INT,
		AvgSide INT, AvgOdd INT, AvgDual INT);
	--���ȶ��ĺ���
	DECLARE @TblStableList TABLE(RetNum INT, Days INT, Cnt INT);
	INSERT INTO @TblStableList
	SELECT RetNum, 0, 0 FROM dbo.ResultCategory_28(NOLOCK)
	--��Ӯ����
	DECLARE @TblWinList TABLE(BigCnt INT, SmallCnt INT, MiddleCnt INT,
		SideCnt INT, OddCnt INT, DualCnt INT);
	INSERT INTO @TblWinList VALUES(0,0,0,0,0,0)

	DECLARE @NowHour INT, @BeginDate DATETIME, @EndDate DATETIME, @n INT, @WinCnt INT;

	--Ӯ��ֵ
	IF(@SourceSysNo = 10001)
	BEGIN
		IF(@BeginHour = 9 AND @EndHour = 12)
		BEGIN
			SET @WinCnt = 17;
		END
		ELSE IF(@BeginHour = 9)
		BEGIN
			SET @WinCnt = 5;
		END
		ELSE IF(@BeginHour = @EndHour)
		BEGIN
			SET @WinCnt = 6;
		END
		ELSE
		BEGIN
			SET @WinCnt = 18;
		END
	END
	ELSE IF(@SourceSysNo = 10002)
	BEGIN
		IF(@BeginHour = @EndHour)
		BEGIN
			SET @WinCnt = 7;
		END
		ELSE
		BEGIN
			SET @WinCnt = 22;
		END
	END

	IF(@BeginHour = @EndHour)
	BEGIN
		SET @EndHour = @EndHour + 1;
	END
	SELECT @n = 15,
		   @NowHour = DATEPART(HOUR, GETDATE()),
		   @BeginDate = CONVERT(DATETIME, CONVERT(NVARCHAR(12), GETDATE(), 111) + N' ' + CONVERT(NVARCHAR(2), @BeginHour) + N':00:00');
	IF(@EndHour = 24)
	BEGIN
		SET @EndDate = CONVERT(DATETIME, CONVERT(NVARCHAR(12), GETDATE(), 111) + N' ' + N'23:59:59');
	END
	ELSE
	BEGIN
		SET @EndDate = CONVERT(DATETIME, CONVERT(NVARCHAR(12), GETDATE(), 111) + N' ' + CONVERT(NVARCHAR(2), @EndHour) + N':00:00');
	END
	IF(@NowHour < @EndHour)
	BEGIN
		SELECT @BeginDate = DATEADD(DAY, -1, @BeginDate),
			   @EndDate = DATEADD(DAY, -1, @EndDate);
	END

	--��ʱ�����
	DECLARE @TblTempResult TABLE(RetNum INT, BigOrSmall NVARCHAR(2), MiddleOrSide NVARCHAR(2), OddOrDual NVARCHAR(2));
	DECLARE @Date NVARCHAR(10), @BigCnt INT, @SmallCnt INT, @MiddleCnt INT, @SideCnt INT,
		@OddCnt INT, @DualCnt INT, @Month INT, @Day INT;

	WHILE(@n > 0)
	BEGIN
		DELETE @TblTempResult;
		--����
		IF(@SourceSysNo = 10001)
		BEGIN
			INSERT INTO @TblTempResult
			SELECT A.RetNum, B.BigOrSmall, B.MiddleOrSide, B.OddOrDual
				FROM dbo.SourceData_28_Beijing(NOLOCK) A
				LEFT JOIN dbo.ResultCategory_28(NOLOCK) B
					ON A.RetNum = B.RetNum
				WHERE A.RetTime >= @BeginDate AND A.RetTime < @EndDate AND A.SiteSysNo = @SiteSysNo
		END
		--���ô�
		ELSE IF(@SourceSysNo = 10002)
		BEGIN
			INSERT INTO @TblTempResult
			SELECT A.RetNum, B.BigOrSmall, B.MiddleOrSide, B.OddOrDual
				FROM dbo.SourceData_28_Canada(NOLOCK) A
				LEFT JOIN dbo.ResultCategory_28(NOLOCK) B
					ON A.RetNum = B.RetNum
				WHERE A.RetTime >= @BeginDate AND A.RetTime < @EndDate AND A.SiteSysNo = @SiteSysNo
		END
		--����
		SELECT @BigCnt = COUNT(1) FROM @TblTempResult WHERE BigOrSmall = N'��'
		SELECT @SmallCnt = COUNT(1) FROM @TblTempResult WHERE BigOrSmall = N'С'
		SELECT @MiddleCnt = COUNT(1) FROM @TblTempResult WHERE MiddleOrSide = N'��'
		SELECT @SideCnt = COUNT(1) FROM @TblTempResult WHERE MiddleOrSide = N'��'
		SELECT @OddCnt = COUNT(1) FROM @TblTempResult WHERE OddOrDual = N'��'
		SELECT @DualCnt = COUNT(1) FROM @TblTempResult WHERE OddOrDual = N'˫'
		SELECT @Month = DATEPART(MONTH, @BeginDate), @Day = DATEPART(DAY, @BeginDate);
		--��Ӯ����
		IF(@BigCnt > @WinCnt)
		BEGIN
			UPDATE @TblWinList SET BigCnt = BigCnt + 1
		END
		ELSE IF(@SmallCnt > @WinCnt)
		BEGIN
			UPDATE @TblWinList SET SmallCnt = SmallCnt + 1
		END
		IF(@MiddleCnt > @WinCnt)
		BEGIN
			UPDATE @TblWinList SET MiddleCnt = MiddleCnt + 1
		END
		ELSE IF(@SideCnt > @WinCnt)
		BEGIN
			UPDATE @TblWinList SET SideCnt = SideCnt + 1
		END
		IF(@OddCnt > @WinCnt)
		BEGIN
			UPDATE @TblWinList SET OddCnt = OddCnt + 1
		END
		ELSE IF(@DualCnt > @WinCnt)
		BEGIN
			UPDATE @TblWinList SET DualCnt = DualCnt + 1
		END

		SET @Date = CONVERT(NVARCHAR(2), @Month) + N'��' + CONVERT(NVARCHAR(2), @Day) + N'��';
		IF(@BeginHour + 1 = @EndHour)
		BEGIN
			SET @Date = @Date + CONVERT(NVARCHAR(2), @BeginHour) + N'ʱ';
		END
		ELSE
		BEGIN
			SET @Date = @Date + CONVERT(NVARCHAR(2), @BeginHour) + N'-'
			SET @Date = @Date + CONVERT(NVARCHAR(2), @EndHour) + N'ʱ';
		END
		--���
		INSERT INTO @TblResultList VALUES(@Date, @BigCnt, @SmallCnt, @MiddleCnt, @SideCnt, @OddCnt, @DualCnt)
		--δ���ֵĺ���
		INSERT INTO @TblNotList
		SELECT @Date, RetNum FROM dbo.ResultCategory_28(NOLOCK)
			WHERE RetNum NOT IN (SELECT RetNum FROM @TblTempResult)
			AND RetNum NOT IN (0,1,2,3,25,26,27)
		--��Ʒ��
		INSERT INTO @TblBestList
		SELECT @Date, RetNum FROM @TblTempResult
			WHERE RetNum IN (0,1,2,3,25,26,27)
		--������������
		UPDATE @TblStableList SET Days = Days + 1, Cnt = Cnt + T.TempCnt FROM
		(SELECT RetNum AS TempRetNum, COUNT(1) AS TempCnt FROM @TblTempResult GROUP BY RetNum) AS T
		WHERE RetNum = T.TempRetNum

		SELECT @BeginDate = DATEADD(DAY, -1, @BeginDate), @EndDate = DATEADD(DAY, -1, @EndDate);
		SET @n = @n - 1;
	END
	SELECT * FROM @TblResultList ORDER BY Idx ASC
	SELECT * FROM @TblNotList ORDER BY Idx ASC
	SELECT * FROM @TblBestList ORDER BY Idx ASC
	SELECT ISNULL(SUM(Big), 0) AS AvgBig,
		   ISNULL(SUM(Small), 0) AS AvgSmall,
		   ISNULL(SUM(Middle), 0) AS AvgMiddle,
		   ISNULL(SUM(Side), 0) AS AvgSide,
		   ISNULL(SUM(Odd), 0) AS AvgOdd,
		   ISNULL(SUM(Dual), 0) AS AvgDual
		FROM @TblResultList
	SELECT TOP 3 * FROM @TblStableList ORDER BY Days DESC, Cnt DESC
	SELECT * FROM @TblWinList

END
GO