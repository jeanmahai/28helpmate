--------------------------------------------------------------------------------------------
--使用此脚本创建表时，请先创建数据库，数据库名：Helpmate
---------------------------------------------------------------------------------------------

USE [Helpmate]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SourceData_28_Beijing]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SourceData_28_Beijing](
	[PeriodNum] [bigint] NOT NULL,
	[RetTime] [datetime] NOT NULL,
	[SiteSysNo] [int] NOT NULL,
	[RetOddNum] [int] NOT NULL,
	[RetNum] [int] NOT NULL,
	[RetMidNum] [nvarchar](40) NOT NULL,
	[CollectRet] [nvarchar](100) NOT NULL,
	[CollectTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_SourceData_28_Beijing] PRIMARY KEY CLUSTERED 
(
	[PeriodNum] ASC,
	[SiteSysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SourceData_28_Canada]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SourceData_28_Canada](
	[PeriodNum] [bigint] NOT NULL,
	[RetTime] [datetime] NOT NULL,
	[SiteSysNo] [int] NOT NULL,
	[RetOddNum] [int] NOT NULL,
	[RetNum] [int] NOT NULL,
	[RetMidNum] [nvarchar](40) NOT NULL,
	[CollectRet] [nvarchar](100) NOT NULL,
	[CollectTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_SourceData_28_Canada] PRIMARY KEY CLUSTERED 
(
	[PeriodNum] ASC,
	[SiteSysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UseSource]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UseSource](
	[SysNo] [int] NOT NULL,
	[SourceName] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_UseSource] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UseGame]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UseGame](
	[SysNo] [int] NOT NULL,
	[GameName] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_UseGame] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OmitStatistics]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OmitStatistics](
	[SysNo] [int] IDENTITY(1,1) NOT NULL,
	[GameSysNo] [int] NOT NULL,
	[SourceSysNo] [int] NOT NULL,
	[SiteSysNo] [int] NOT NULL,
	[RetNum] [int] NOT NULL,
	[OmitCnt] [int] NOT NULL,
	[MaxOmitCnt] [int] NOT NULL,
	[StandardCnt] [int] NOT NULL,
	[NowPeriodNum] [bigint] NOT NULL,
 CONSTRAINT [PK_OmitStatistics] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notices]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Notices](
	[SysNo] [int] IDENTITY(1001,1) NOT NULL,
	[Contents] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[Rank] [int] NOT NULL,
	[InDate] [datetime] NOT NULL CONSTRAINT [DF_Notices_InDate]  DEFAULT (getdate()),
	[PublishUser] [nvarchar](40) NULL,
 CONSTRAINT [PK_Notices] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PayCard]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PayCard](
	[SysNo] [bigint] IDENTITY(10001,1) NOT NULL,
	[PayCardID] [nvarchar](40) NOT NULL,
	[PayCardPwd] [nvarchar](40) NOT NULL,
	[CategorySysNo] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[InDate] [datetime] NOT NULL,
	[BeginTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
 CONSTRAINT [PK_PayCard] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PayCardCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PayCardCategory](
	[SysNo] [int] NOT NULL,
	[CategoryName] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_PayCardCategory] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PayLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PayLog](
	[SysNo] [int] IDENTITY(1,1) NOT NULL,
	[CardSysNo] [bigint] NOT NULL,
	[UserSysNo] [int] NOT NULL,
	[InDate] [datetime] NOT NULL CONSTRAINT [DF_PayLog_InDate]  DEFAULT (getdate()),
	[IP] [nvarchar](32) NULL,
 CONSTRAINT [PK_PayLog] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RemindRefreshTag]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RemindRefreshTag](
	[SysNo] [int] IDENTITY(1,1) NOT NULL,
	[GameSysNo] [int] NOT NULL,
	[SourceSysNo] [int] NOT NULL,
	[SiteSysNo] [int] NOT NULL,
	[NowperiodNum] [bigint] NOT NULL,
 CONSTRAINT [PK_RemindRefreshTag] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[SysNo] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](40) NOT NULL,
	[UserPwd] [nvarchar](40) NOT NULL,
	[UserName] [nvarchar](40) NULL,
	[SecurityQuestion1] [nvarchar](40) NOT NULL,
	[SecurityAnswer1] [nvarchar](40) NOT NULL,
	[SecurityQuestion2] [nvarchar](40) NULL,
	[SecurityAnswer2] [nvarchar](40) NULL,
	[Phone] [nvarchar](40) NULL,
	[QQ] [nvarchar](40) NULL,
	[Status] [int] NOT NULL,
	[RegIP] [nvarchar](40) NULL,
	[RegDate] [datetime] NOT NULL,
	[PayUseBeginTime] [datetime] NOT NULL,
	[PayUseEndTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RemindStatistics]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RemindStatistics](
	[SysNo] [int] IDENTITY(1,1) NOT NULL,
	[UserSysNo] [int] NOT NULL,
	[GameSysNo] [int] NOT NULL,
	[SourceSysNo] [int] NOT NULL,
	[SiteSysNo] [int] NOT NULL,
	[RetNum] [nvarchar](10) NOT NULL,
	[Cnt] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_RemindStatistics] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UseSite]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UseSite](
	[SysNo] [int] NOT NULL,
	[SiteName] [nvarchar](40) NOT NULL,
	[Comment] [nvarchar](40) NULL,
 CONSTRAINT [PK_UseSite] PRIMARY KEY CLUSTERED 
(
	[SysNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResultCategory_28]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ResultCategory_28](
	[RetNum] [int] NOT NULL,
	[BigOrSmall] [nvarchar](50) NOT NULL,
	[MiddleOrSide] [nvarchar](50) NOT NULL,
	[OddOrDual] [nvarchar](50) NOT NULL,
	[MantissaBigOrSmall] [nvarchar](50) NOT NULL,
	[ThreeRemainder] [nvarchar](50) NOT NULL,
	[FourRemainder] [nvarchar](50) NOT NULL,
	[FiveRemainder] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ResultCategory_28] PRIMARY KEY CLUSTERED 
(
	[RetNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RefreshRemind]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RefreshRemind] 
	-- Add the parameters for the stored procedure here
	@GameSysNo INT,
	@SourceSysNo INT,
	@SiteSysNo INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	DECLARE @NowPeriodNum INT, @NowRetNum INT, @Cnt INT;
	DECLARE @NowRetNumBig NVARCHAR(10), @NowRetNumMiddle NVARCHAR(10), @NowRetNumOdd NVARCHAR(10);

	SELECT @NowPeriodNum = 0, @NowRetNum = -1, @Cnt = 0,
			@NowRetNumBig = N'''', @NowRetNumMiddle = N'''', @NowRetNumOdd = N'''';
	
	--开始刷新
	IF(@GameSysNo = 10001)
	BEGIN
		IF(@SourceSysNo = 10001)
		BEGIN
			--当前期
			SELECT @NowPeriodNum = ISNULL(MAX(PeriodNum), 0)
				FROM Helpmate.dbo.SourceData_28_Beijing(NOLOCK)
				WHERE SiteSysNo = @SiteSysNo AND [Status] = 1
			--当前期开奖结果
			SELECT @NowRetNum = A.RetNum,
				@NowRetNumBig = B.BigOrSmall,
				@NowRetNumMiddle = B.MiddleOrSide,
				@NowRetNumOdd = B.OddOrDual
				FROM Helpmate.dbo.SourceData_28_Beijing(NOLOCK) A
				LEFT JOIN dbo.ResultCategory_28(NOLOCK) B
				ON A.RetNum = B.RetNum
				WHERE A.SiteSysNo = @SiteSysNo and A.PeriodNum = @NowPeriodNum
			--当前最大期未刷新，则刷新；已刷新过则不予刷新
			IF(NOT EXISTS(SELECT 1 FROM Helpmate.dbo.RemindRefreshTag(NOLOCK) WHERE GameSysNo = @GameSysNo
				AND SourceSysNo = @SourceSysNo AND SiteSysNo = @SiteSysNo AND NowPeriodNum = @NowPeriodNum))
			BEGIN
				--都置为不提醒
				UPDATE Helpmate.dbo.RemindStatistics SET [Status] = 0
					WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo AND SiteSysNo = @SiteSysNo

				--大/小
				SELECT @Cnt = COUNT(1) FROM
					(SELECT @NowPeriodNum - (ROW_NUMBER() OVER (ORDER BY PeriodNum DESC)) AS TempPeriodNum, PeriodNum
					FROM Helpmate.dbo.SourceData_28_Beijing(NOLOCK)
					WHERE RetNum IN (SELECT RetNum FROM Helpmate.dbo.ResultCategory_28(NOLOCK) WHERE BigOrSmall = @NowRetNumBig)
					AND PeriodNum < @NowPeriodNum AND SiteSysNo = @SiteSysNo) AS T
					WHERE T.TempPeriodNum = T.PeriodNum
				IF(@Cnt > 0)
				BEGIN
					--将订阅该开奖结果连续次数的记录更新为提醒状态,1.提醒，0.不提醒（已提醒过也是0）
					UPDATE Helpmate.dbo.RemindStatistics SET [Status] = 1
						WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo
						AND SiteSysNo = @SiteSysNo AND Cnt = @Cnt + 1
						AND RetNum = @NowRetNumBig
				END
				--中/边
				SELECT @Cnt = COUNT(1) FROM
					(SELECT @NowPeriodNum - (ROW_NUMBER() OVER (ORDER BY PeriodNum DESC)) AS TempPeriodNum, PeriodNum
					FROM Helpmate.dbo.SourceData_28_Beijing(NOLOCK)
					WHERE RetNum IN (SELECT RetNum FROM Helpmate.dbo.ResultCategory_28(NOLOCK) WHERE MiddleOrSide = @NowRetNumMiddle)
					AND PeriodNum < @NowPeriodNum AND SiteSysNo = @SiteSysNo) AS T
					WHERE T.TempPeriodNum = T.PeriodNum
				IF(@Cnt > 0)
				BEGIN
					--将订阅该开奖结果连续次数的记录更新为提醒状态,1.提醒，0.不提醒（已提醒过也是0）
					UPDATE Helpmate.dbo.RemindStatistics SET [Status] = 1
						WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo
						AND SiteSysNo = @SiteSysNo AND Cnt = @Cnt + 1
						AND RetNum = @NowRetNumMiddle
				END
				--单/双
				SELECT @Cnt = COUNT(1) FROM
					(SELECT @NowPeriodNum - (ROW_NUMBER() OVER (ORDER BY PeriodNum DESC)) AS TempPeriodNum, PeriodNum
					FROM Helpmate.dbo.SourceData_28_Beijing(NOLOCK)
					WHERE RetNum IN (SELECT RetNum FROM Helpmate.dbo.ResultCategory_28(NOLOCK) WHERE OddOrDual = @NowRetNumOdd)
					AND PeriodNum < @NowPeriodNum AND SiteSysNo = @SiteSysNo) AS T
					WHERE T.TempPeriodNum = T.PeriodNum
				IF(@Cnt > 0)
				BEGIN
					--将订阅该开奖结果连续次数的记录更新为提醒状态,1.提醒，0.不提醒（已提醒过也是0）
					UPDATE Helpmate.dbo.RemindStatistics SET [Status] = 1
						WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo
						AND SiteSysNo = @SiteSysNo AND Cnt = @Cnt + 1
						AND RetNum = @NowRetNumOdd
				END
				--更新当前期已刷新
				UPDATE [Helpmate].[dbo].[RemindRefreshTag] SET NowPeriodNum = @NowPeriodNum
					WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo AND SiteSysNo = @SiteSysNo
			END
		END
		ELSE IF(@SourceSysNo = 10002)
		BEGIN
			--当前期
			SELECT @NowPeriodNum = ISNULL(MAX(PeriodNum), 0)
				FROM Helpmate.dbo.SourceData_28_Canada(NOLOCK)
				WHERE SiteSysNo = @SiteSysNo AND [Status] = 1
			--当前期开奖结果
			SELECT @NowRetNum = A.RetNum,
				@NowRetNumBig = B.BigOrSmall,
				@NowRetNumMiddle = B.MiddleOrSide,
				@NowRetNumOdd = B.OddOrDual
				FROM Helpmate.dbo.SourceData_28_Canada(NOLOCK) A
				LEFT JOIN dbo.ResultCategory_28(NOLOCK) B
				ON A.RetNum = B.RetNum
				WHERE A.SiteSysNo = @SiteSysNo and A.PeriodNum = @NowPeriodNum
			--当前最大期未刷新，则刷新；已刷新过则不予刷新
			IF(NOT EXISTS(SELECT 1 FROM Helpmate.dbo.RemindRefreshTag(NOLOCK) WHERE GameSysNo = @GameSysNo
				AND SourceSysNo = @SourceSysNo AND SiteSysNo = @SiteSysNo AND NowPeriodNum = @NowPeriodNum))
			BEGIN
				--都置为不提醒
				UPDATE Helpmate.dbo.RemindStatistics SET [Status] = 0
					WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo AND SiteSysNo = @SiteSysNo
				--大/小
				SELECT @Cnt = COUNT(1) FROM
					(SELECT @NowPeriodNum - (ROW_NUMBER() OVER (ORDER BY PeriodNum DESC)) AS TempPeriodNum, PeriodNum
					FROM Helpmate.dbo.SourceData_28_Canada(NOLOCK)
					WHERE RetNum IN (SELECT RetNum FROM Helpmate.dbo.ResultCategory_28(NOLOCK) WHERE BigOrSmall = @NowRetNumBig)
					AND PeriodNum < @NowPeriodNum AND SiteSysNo = @SiteSysNo) AS T
					WHERE T.TempPeriodNum = T.PeriodNum
				IF(@Cnt > 0)
				BEGIN
					--将订阅该开奖结果连续次数的记录更新为提醒状态,1.提醒，0.不提醒（已提醒过也是0）
					UPDATE Helpmate.dbo.RemindStatistics SET [Status] = 1
						WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo
						AND SiteSysNo = @SiteSysNo AND Cnt = @Cnt + 1
						AND RetNum = @NowRetNumBig
				END
				--中/边
				SELECT @Cnt = COUNT(1) FROM
					(SELECT @NowPeriodNum - (ROW_NUMBER() OVER (ORDER BY PeriodNum DESC)) AS TempPeriodNum, PeriodNum
					FROM Helpmate.dbo.SourceData_28_Canada(NOLOCK)
					WHERE RetNum IN (SELECT RetNum FROM Helpmate.dbo.ResultCategory_28(NOLOCK) WHERE MiddleOrSide = @NowRetNumMiddle)
					AND PeriodNum < @NowPeriodNum AND SiteSysNo = @SiteSysNo) AS T
					WHERE T.TempPeriodNum = T.PeriodNum
				IF(@Cnt > 0)
				BEGIN
					--将订阅该开奖结果连续次数的记录更新为提醒状态,1.提醒，0.不提醒（已提醒过也是0）
					UPDATE Helpmate.dbo.RemindStatistics SET [Status] = 1
						WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo
						AND SiteSysNo = @SiteSysNo AND Cnt = @Cnt + 1
						AND RetNum = @NowRetNumMiddle
				END
				--单/双
				SELECT @Cnt = COUNT(1) FROM
					(SELECT @NowPeriodNum - (ROW_NUMBER() OVER (ORDER BY PeriodNum DESC)) AS TempPeriodNum, PeriodNum
					FROM Helpmate.dbo.SourceData_28_Canada(NOLOCK)
					WHERE RetNum IN (SELECT RetNum FROM Helpmate.dbo.ResultCategory_28(NOLOCK) WHERE OddOrDual = @NowRetNumOdd)
					AND PeriodNum < @NowPeriodNum AND SiteSysNo = @SiteSysNo) AS T
					WHERE T.TempPeriodNum = T.PeriodNum
				IF(@Cnt > 0)
				BEGIN
					--将订阅该开奖结果连续次数的记录更新为提醒状态,1.提醒，0.不提醒（已提醒过也是0）
					UPDATE Helpmate.dbo.RemindStatistics SET [Status] = 1
						WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo
						AND SiteSysNo = @SiteSysNo AND Cnt = @Cnt + 1
						AND RetNum = @NowRetNumOdd
				END
				--更新当前期已刷新
				UPDATE [Helpmate].[dbo].[RemindRefreshTag] SET NowPeriodNum = @NowPeriodNum
					WHERE GameSysNo= @GameSysNo AND SourceSysNo = @SourceSysNo AND SiteSysNo = @SiteSysNo
			END
		END
	END
	

	
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RefreshOmitStatistics]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RefreshOmitStatistics]
	-- Add the parameters for the stored procedure here
	@GameSysNo INT,
	@SourceSysNo INT,
	@SiteSysNo INT	

AS

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	DECLARE @NowPeriodNum INT, @MinPeriodNum INT, @Idx INT;

	SELECT @NowPeriodNum = 0, @MinPeriodNum = 0, @Idx = 0;

	IF(@GameSysNo = 10001)
	BEGIN
		IF(@SourceSysNo = 10001)
		BEGIN
			SELECT @NowPeriodNum = ISNULL(MAX(PeriodNum), 0), @MinPeriodNum = ISNULL(MIN(PeriodNum), 0)
				FROM Helpmate.dbo.SourceData_28_Beijing(NOLOCK)
				WHERE SiteSysNo = @SiteSysNo AND [Status] = 1
		END
		ELSE IF(@SourceSysNo = 10002)
		BEGIN
			SELECT @NowPeriodNum = ISNULL(MAX(PeriodNum), 0), @MinPeriodNum = ISNULL(MIN(PeriodNum), 0)
				FROM Helpmate.dbo.SourceData_28_Canada(NOLOCK)
				WHERE SiteSysNo = @SiteSysNo AND [Status] = 1
		END
	END

	--当前最大期未刷新，则刷新；已刷新过则不予刷新
	IF(NOT EXISTS(SELECT 1 FROM Helpmate.dbo.OmitStatistics(NOLOCK) WHERE GameSysNo = @GameSysNo
		AND SourceSysNo = @SourceSysNo AND SiteSysNo = @SiteSysNo AND NowPeriodNum = @NowPeriodNum))
	BEGIN
		DECLARE @TblList TABLE(TempRetNum INT, TempOmitCnt INT);
		IF(@GameSysNo = 10001)
		BEGIN
			IF(@SourceSysNo = 10001)
			BEGIN
				INSERT INTO @TblList
				SELECT RetNum, (@NowPeriodNum - ISNULL(MAX(PeriodNum), @MinPeriodNum)) AS OmitCnt
					FROM Helpmate.dbo.SourceData_28_Beijing(NOLOCK)
					WHERE SiteSysNo = @SiteSysNo AND [Status] = 1
					GROUP BY SiteSysNo, RetNum
					ORDER BY RetNum ASC
			END
			ELSE IF(@SourceSysNo = 10002)
			BEGIN
				INSERT INTO @TblList
				SELECT RetNum, (@NowPeriodNum - ISNULL(MAX(PeriodNum), @MinPeriodNum)) AS OmitCnt
					FROM Helpmate.dbo.SourceData_28_Canada(NOLOCK)
					WHERE SiteSysNo = @SiteSysNo AND [Status] = 1
					GROUP BY SiteSysNo, RetNum
					ORDER BY RetNum ASC
			END
		END
		--最大遗漏期数
		UPDATE Helpmate.dbo.OmitStatistics SET MaxOmitCnt = OmitCnt
		WHERE RetNum IN
		(SELECT TempRetNum FROM @TblList WHERE TempOmitCnt = 0)
		AND GameSysNo = @GameSysNo AND SourceSysNo = @SourceSysNo
		AND SiteSysNo = @SiteSysNo AND MaxOmitCnt < OmitCnt
--		UPDATE Helpmate.dbo.OmitStatistics SET MaxOmitCnt = TempOmitCnt
--			FROM @TblList AS Temp
--			WHERE RetNum = Temp.TempRetNum AND MaxOmitCnt < Temp.TempOmitCnt
--			AND GameSysNo = @GameSysNo AND SourceSysNo = @SourceSysNo
--			AND SiteSysNo = @SiteSysNo AND Temp.TempOmitCnt = 0
		--遗漏期数
		UPDATE Helpmate.dbo.OmitStatistics SET OmitCnt = TempOmitCnt, NowPeriodNum = @NowPeriodNum
			FROM @TblList AS Temp
			WHERE RetNum = Temp.TempRetNum AND GameSysNo = @GameSysNo
			AND SourceSysNo = @SourceSysNo AND SiteSysNo = @SiteSysNo
		--未出现的
		UPDATE Helpmate.dbo.OmitStatistics SET OmitCnt = @NowPeriodNum - @MinPeriodNum,
			MaxOmitCnt = @NowPeriodNum - @MinPeriodNum, NowPeriodNum = @NowPeriodNum
			WHERE NowPeriodNum = 0 AND GameSysNo = @GameSysNo AND SourceSysNo = @SourceSysNo
			AND SiteSysNo = @SiteSysNo
			
	END





' 
END
