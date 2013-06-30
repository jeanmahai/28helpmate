USE [Helpmate]
GO
/****** 对象:  Table [dbo].[ResultCategory_28]    脚本日期: 06/30/2013 14:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultCategory_28](
	[RetNum] [int] NOT NULL,
	[BigOrSmall] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[MiddleOrSide] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[OddOrDual] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[MantissaBigOrSmall] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ThreeRemainder] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[FourRemainder] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[FiveRemainder] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT [PK_ResultCategory_28] PRIMARY KEY CLUSTERED 
(
	[RetNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



--Init data
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('0','小','边','双','小','0','0','0')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('1','小','边','单','小','1','1','1')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('2','小','边','双','小','2','2','2')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('3','小','边','单','小','0','3','3')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('4','小','边','双','小','1','0','4')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('5','小','边','单','大','2','1','0')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('6','小','边','双','大','0','2','1')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('7','小','边','单','大','1','3','2')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('8','小','边','双','大','2','0','3')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('9','小','边','单','大','0','1','4')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('10','小','中','双','小','1','2','0')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('11','小','中','单','小','2','3','1')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('12','小','中','双','小','0','0','2')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('13','小','中','单','小','1','1','3')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('14','大','中','双','小','2','2','4')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('15','大','中','单','大','0','3','0')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('16','大','中','双','大','1','0','1')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('17','大','中','单','大','2','1','2')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('18','大','边','双','大','0','2','3')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('19','大','边','单','大','1','3','4')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('20','大','边','双','小','2','0','0')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('21','大','边','单','小','0','1','1')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('22','大','边','双','小','1','2','2')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('23','大','边','单','小','2','3','3')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('24','大','边','双','小','0','0','4')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('25','大','边','单','大','1','1','0')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('26','大','边','双','大','2','2','1')
Insert Into [ResultCategory_28] ([RetNum],[BigOrSmall],[MiddleOrSide],[OddOrDual],[MantissaBigOrSmall],[ThreeRemainder],[FourRemainder],[FiveRemainder]) Values('27','大','边','单','大','0','3','2')
