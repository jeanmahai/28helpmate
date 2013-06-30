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
	[Status] [int] NOT NULL,
	[RegIP] [nvarchar](40) NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[RechargeUseBeginTime] [datetime] NOT NULL,
	[RechargeUseEndTime] [datetime] NOT NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UseSite]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UseSite](
	[SysNo] [int] NOT NULL,
	[SiteName] [nvarchar](40) NOT NULL,
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
