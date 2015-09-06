USE [master]
GO
/****** Object:  Database [ItcastMvcCMS]    Script Date: 04/23/2015 14:05:11 ******/
CREATE DATABASE [ItcastMvcCMS] ON  PRIMARY 
( NAME = N'ItcastDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ItcastDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ItcastDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ItcastDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ItcastMvcCMS] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ItcastMvcCMS].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [ItcastMvcCMS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET ARITHABORT OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ItcastMvcCMS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ItcastMvcCMS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ItcastMvcCMS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET  DISABLE_BROKER
GO
ALTER DATABASE [ItcastMvcCMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ItcastMvcCMS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ItcastMvcCMS] SET  READ_WRITE
GO
ALTER DATABASE [ItcastMvcCMS] SET RECOVERY FULL
GO
ALTER DATABASE [ItcastMvcCMS] SET  MULTI_USER
GO
ALTER DATABASE [ItcastMvcCMS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ItcastMvcCMS] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ItcastMvcCMS', N'ON'
GO
USE [ItcastMvcCMS]
GO
/****** Object:  Table [dbo].[T_UserInfo]    Script Date: 04/23/2015 14:05:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](32) NOT NULL,
	[UserPwd] [nvarchar](32) NOT NULL,
	[UserMail] [nvarchar](32) NOT NULL,
	[RegTime] [datetime] NOT NULL,
 CONSTRAINT [PK_T_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_UserInfo] ON
INSERT [dbo].[T_UserInfo] ([Id], [UserName], [UserPwd], [UserMail], [RegTime]) VALUES (1, N'Itcast', N'123', N'Itcast@126.com', CAST(0x0000A3DF00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[T_UserInfo] OFF
/****** Object:  Table [dbo].[T_News]    Script Date: 04/23/2015 14:05:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](32) NOT NULL,
	[Msg] [nvarchar](max) NOT NULL,
	[SubDateTime] [datetime] NOT NULL,
	[Author] [nvarchar](32) NOT NULL,
	[ImagePath] [nchar](100) NOT NULL,
 CONSTRAINT [PK_T_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_News] ON
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (1, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。一)房地产调控初显成效，房地产销售量减价稳。受房地产调控政策影响，商品房销售中，二、三套商品房的银行按揭贷款首付比例及利率均被提高，所调查的房地产开发公司的售楼处不再有排队购房的现象，有购房意愿的客户也处于观望状态。一是商品房销量同比减少。从销售套数来看，2010年二季度销售商品房 159套，同比减少57套，下降26.4%。从销售面积来看，二季度销售17709平方米，同比减少9389平方米，下降34.6%。二是商品房销售价格涨幅缩小。二季度，商品房平均成交价为3621.3元/平方米，比一季度增加37.3元/平方米，上涨1%；同比增加34元/平方米，上涨0.9%。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (2, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (3, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (4, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (5, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (6, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (7, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (8, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (9, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (10, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (11, N'新政百日后山西临汾房地产业情况调查', N'为了有效遏制房地产市场泡沫问题，今年4月份以来，国务院、国家相关部委先后出台了一系列房地产调控政策，尤其是4月17日国务院发布《关于坚决遏制部分城市房价过快上涨的通知》(以下简称新"国十条")至今已满100天，为了解宏观调控政策对山西省临汾市这种二、三线城市房地产业的影响，近期，临汾银监分局对临汾市部分房地产企业和临汾银行业金融机构进行了专题调查。', CAST(0x0000A3DE00000000 AS DateTime), N'Itcast', N'/Image/default.jpg                                                                                  ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (21, N'最新小时', N'<span style="white-space:nowrap;"><strong>最新</strong>小时<span style="white-space:nowrap;">最新小时<span style="white-space:nowrap;">最新小时<span style="white-space:nowrap;">最新小时<span style="white-space:nowrap;">最新小时<span style="white-space:nowrap;">最新小时</span></span></span></span></span></span>', CAST(0x0000A3DF0169A283 AS DateTime), N'Itcast', N'/FileUploadImage/2014/11/10/cc390b20-1a8b-4c8e-9a8b-8f5bfcbff20a.jpg                                ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (22, N'消息', N'<p>
	最新<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息</span></span></span></span></span></span></span></span></span></span></span></span></span></span></span>
</p>
<p>
	<span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<img src="/Upload/KinderEditorImages/image/20141110/20141110221459_6859.jpg" width="300" height="400" title="美女" alt="美女" /><span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息</span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span>
</p>
<p>
	<span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;"><span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息<span style="white-space:nowrap;">消息</span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span></span>
</p>', CAST(0x0000A3DF016EB083 AS DateTime), N'Itcast', N'/FileUploadImage/2014/11/10/aa508e6b-bf6d-462f-8c25-a88ab83bc33b.jpg                                ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (26, N'好消息', N'<span style="white-space:nowrap;">好消息<span style="white-space:nowrap;">好消息<span style="white-space:nowrap;">好消息<span style="white-space:nowrap;">好消息<span style="white-space:nowrap;">好消息<span style="white-space:nowrap;">好消息<span style="white-space:nowrap;">好消息<span style="white-space:nowrap;">好消息<span style="white-space:nowrap;">好消息</span></span></span></span></span></span></span></span></span>', CAST(0x0000A3DF01763BF6 AS DateTime), N'Admin', N'/FileUploadImage/2014/11/10/32771c4e-4b85-42a0-af6a-a6b605601683.jpg                                ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (34, N'好消息', N'回家哈哈哈', CAST(0x0000A3DF017AF7C1 AS DateTime), N'admin', N'/FileUploadImage/2014/11/10/18dddb7c-ba73-43e8-b80b-c379c5b49737.jpg                                ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (35, N'传智播客', N'传智播客.Net就是牛啊啊啊!!', CAST(0x0000A3E10000E808 AS DateTime), N'itcast', N'/FileUploadImage/2014/11/12/79553409-f959-441f-9769-b498a52f7c6b.jpg                                ')
INSERT [dbo].[T_News] ([Id], [Title], [Msg], [SubDateTime], [Author], [ImagePath]) VALUES (36, N'.Net讲师', N'老王<img src="/Upload/KinderEditorImages/image/20141113/20141113225440_3593.jpg" width="300" height="400" title="老王" alt="老王" />哈哈哈 哈哈哈哈哈!!', CAST(0x0000A3E201799993 AS DateTime), N'老王', N'/FileUploadImage/2014/11/13/c21d23ed-7dcf-483f-9d4d-014f1377b552.jpg                                ')
SET IDENTITY_INSERT [dbo].[T_News] OFF
/****** Object:  Table [dbo].[T_NewComments]    Script Date: 04/23/2015 14:05:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_NewComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NewId] [int] NOT NULL,
	[Msg] [nvarchar](max) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_T_NewComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_NewComments] ON
INSERT [dbo].[T_NewComments] ([Id], [NewId], [Msg], [CreateDateTime]) VALUES (1, 22, N'美女啊啊啊!!', CAST(0x0000A3E2016B62D9 AS DateTime))
INSERT [dbo].[T_NewComments] ([Id], [NewId], [Msg], [CreateDateTime]) VALUES (2, 22, N'是啊，很漂亮啊啊啊啊啊啊啊', CAST(0x0000A3E20170C40C AS DateTime))
INSERT [dbo].[T_NewComments] ([Id], [NewId], [Msg], [CreateDateTime]) VALUES (3, 22, N'哈哈哈哈哈哈哈哈', CAST(0x0000A3E201711389 AS DateTime))
INSERT [dbo].[T_NewComments] ([Id], [NewId], [Msg], [CreateDateTime]) VALUES (7, 22, N'哈哈哈哈哈哈哈哈', CAST(0x0000A3E20172E465 AS DateTime))
INSERT [dbo].[T_NewComments] ([Id], [NewId], [Msg], [CreateDateTime]) VALUES (8, 34, N'哈哈哈', CAST(0x0000A3E201783988 AS DateTime))
INSERT [dbo].[T_NewComments] ([Id], [NewId], [Msg], [CreateDateTime]) VALUES (9, 22, N'哈哈哈撒旦恢复快来撒可否加萨发生非健康啦飞洒房间阿飞静安寺发发生离开房间案例发房间卡fasfasfasjdflsakfsd卡发简历萨克福建阿里是否  卡萨丁放假撒发送发举案说法暗示付款垃圾是否asfjla卡萨剪短发拉斯发生法律卡死发送发发件！！', CAST(0x0000A3E201789D28 AS DateTime))
INSERT [dbo].[T_NewComments] ([Id], [NewId], [Msg], [CreateDateTime]) VALUES (10, 36, N'帅啊啊!!', CAST(0x0000A3E20179CAA4 AS DateTime))
INSERT [dbo].[T_NewComments] ([Id], [NewId], [Msg], [CreateDateTime]) VALUES (11, 35, N'sdjsdjfksa', CAST(0x0000A3E400BDB40C AS DateTime))
SET IDENTITY_INSERT [dbo].[T_NewComments] OFF
