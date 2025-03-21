USE [ProjectManager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/18/2025 10:26:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/18/2025 10:26:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[TeacherID] [int] NULL,
	[StudentID] [nvarchar](12) NULL,
	[TypeAccount] [int] NULL,
	[Status] [int] NULL,
	[DateIssued] [date] NULL,
	[CreatedDate] [date] NULL,
	[CreatedUser] [nvarchar](50) NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/18/2025 10:26:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [nvarchar](12) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ClassName] [nvarchar](8) NULL,
	[Dob] [date] NULL,
	[Sex] [int] NULL,
	[EmailAddress] [nvarchar](150) NULL,
	[PhoneNumber] [nvarchar](11) NULL,
	[Address] [nvarchar](350) NULL,
	[Description] [nvarchar](350) NULL,
	[ImageUrl] [nvarchar](350) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 3/18/2025 10:26:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](250) NULL,
	[Dob] [date] NULL,
	[Sex] [int] NULL,
	[PhoneNumber] [nvarchar](11) NULL,
	[Department] [nvarchar](250) NULL,
	[ImageUrl] [nvarchar](350) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 3/18/2025 10:26:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[col1] [nvarchar](150) NULL,
	[col2] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 3/18/2025 10:26:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TopicName] [nvarchar](350) NULL,
	[Description] [nvarchar](max) NULL,
	[StudentID] [nvarchar](50) NULL,
	[TeacherID] [int] NULL,
	[Status] [int] NULL,
	[Year] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Account] ([Name], [Password], [TeacherID], [StudentID], [TypeAccount], [Status], [DateIssued], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (N'sinhvien3', N'123456', NULL, N'72DCTT20034', 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([Name], [Password], [TeacherID], [StudentID], [TypeAccount], [Status], [DateIssued], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (N'sinhvien4', N'123456', NULL, N'72DCTT20001', 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([Name], [Password], [TeacherID], [StudentID], [TypeAccount], [Status], [DateIssued], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (N'test', N'tungduong2003', 1, N'72DCTT20043', 1, 1, NULL, NULL, NULL, CAST(N'2025-03-18' AS Date), N'72DCTT20043')
INSERT [dbo].[Account] ([Name], [Password], [TeacherID], [StudentID], [TypeAccount], [Status], [DateIssued], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (N'test 2', N'123456', NULL, N'72DCTT20044', 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([Name], [Password], [TeacherID], [StudentID], [TypeAccount], [Status], [DateIssued], [CreatedDate], [CreatedUser], [ModifiedDate], [ModifiedUser]) VALUES (N'trungkien', N'123456', NULL, N'72DCTT20033', 1, 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student] ([StudentID], [Name], [ClassName], [Dob], [Sex], [EmailAddress], [PhoneNumber], [Address], [Description], [ImageUrl]) VALUES (N'72DCTT20001', N'tuyet lan', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Student] ([StudentID], [Name], [ClassName], [Dob], [Sex], [EmailAddress], [PhoneNumber], [Address], [Description], [ImageUrl]) VALUES (N'72DCTT20033', N'trung kien', N'72DCTT21', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Student] ([StudentID], [Name], [ClassName], [Dob], [Sex], [EmailAddress], [PhoneNumber], [Address], [Description], [ImageUrl]) VALUES (N'72DCTT20034', N'duongbach', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Student] ([StudentID], [Name], [ClassName], [Dob], [Sex], [EmailAddress], [PhoneNumber], [Address], [Description], [ImageUrl]) VALUES (N'72DCTT20043', N'tungduong', N'72DCTT21', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Student] ([StudentID], [Name], [ClassName], [Dob], [Sex], [EmailAddress], [PhoneNumber], [Address], [Description], [ImageUrl]) VALUES (N'72DCTT20044', N'tuanphong', N'72dctt23', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([ID], [Name], [EmailAddress], [Dob], [Sex], [PhoneNumber], [Department], [ImageUrl]) VALUES (1, N'giao vien 1', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Teacher] ([ID], [Name], [EmailAddress], [Dob], [Sex], [PhoneNumber], [Department], [ImageUrl]) VALUES (2, N'giao vien 2', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([ID], [TopicName], [Description], [StudentID], [TeacherID], [Status], [Year], [CreatedDate], [ModifiedDate]) VALUES (1, N'De tai 1', N'a', NULL, NULL, 2, NULL, NULL, CAST(N'2025-03-18T01:02:10.317' AS DateTime))
INSERT [dbo].[Topic] ([ID], [TopicName], [Description], [StudentID], [TeacherID], [Status], [Year], [CreatedDate], [ModifiedDate]) VALUES (2, N'De tai 2', N'b', N'72DCTT20044', NULL, 1, NULL, NULL, CAST(N'2025-03-17T23:59:40.693' AS DateTime))
INSERT [dbo].[Topic] ([ID], [TopicName], [Description], [StudentID], [TeacherID], [Status], [Year], [CreatedDate], [ModifiedDate]) VALUES (3, N'De tai 3', N'v', N'72DCTT20034', NULL, 1, NULL, NULL, CAST(N'2025-03-17T23:23:26.690' AS DateTime))
INSERT [dbo].[Topic] ([ID], [TopicName], [Description], [StudentID], [TeacherID], [Status], [Year], [CreatedDate], [ModifiedDate]) VALUES (4, N'De tai 4', N'd', N'72DCTT20001', 101, 0, NULL, CAST(N'2024-03-01T00:00:00.000' AS DateTime), CAST(N'2024-03-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Topic] ([ID], [TopicName], [Description], [StudentID], [TeacherID], [Status], [Year], [CreatedDate], [ModifiedDate]) VALUES (5, N'De tai 5', N'e', N'72DCTT20043', 1, 0, NULL, CAST(N'2024-03-05T00:00:00.000' AS DateTime), CAST(N'2025-03-18T01:02:10.320' AS DateTime))
INSERT [dbo].[Topic] ([ID], [TopicName], [Description], [StudentID], [TeacherID], [Status], [Year], [CreatedDate], [ModifiedDate]) VALUES (6, N'De tai 6', N'f', NULL, NULL, 2, NULL, CAST(N'2024-03-07T00:00:00.000' AS DateTime), CAST(N'2025-03-18T00:28:43.183' AS DateTime))
SET IDENTITY_INSERT [dbo].[Topic] OFF
GO
