USE [master]
GO
/****** Object:  Database [Nautic_DB]    Script Date: 12/21/2018 11:34:58 AM ******/
CREATE DATABASE [Nautic_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nautic_DB', FILENAME = N'd:\AppData\MSSQL11.MSSQLSERVER\MSSQL\DATA\Nautic_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Nautic_DB_log', FILENAME = N'd:\AppData\MSSQL11.MSSQLSERVER\MSSQL\DATA\Nautic_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Nautic_DB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nautic_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nautic_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nautic_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nautic_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nautic_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nautic_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nautic_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nautic_DB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Nautic_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nautic_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nautic_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nautic_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nautic_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nautic_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nautic_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nautic_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nautic_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Nautic_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nautic_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nautic_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nautic_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nautic_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nautic_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nautic_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nautic_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Nautic_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Nautic_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nautic_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nautic_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nautic_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Nautic_DB]
GO
/****** Object:  Table [dbo].[AllocateClassRoom]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AllocateClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NOT NULL,
	[Day] [varchar](4) NULL,
	[FromTime] [varchar](20) NULL,
	[ToTime] [varchar](20) NULL,
	[Flag] [int] NULL,
 CONSTRAINT [PK_AllocateClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseEnroll]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseEnroll](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
	[CourseId] [int] NOT NULL,
	[CourseGrade] [varchar](50) NOT NULL,
	[Flag] [int] NOT NULL,
 CONSTRAINT [PK_CourseEnroll] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveClassRoom]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_SaveClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveCourse]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[Assigned] [varchar](10) NOT NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_SaveCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveDepartment]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SaveDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveStudent]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [varchar](700) NOT NULL,
	[RegistrationNo] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_SaveStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveTeacher]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[ContactNumber] [varchar](100) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TotalCredit] [decimal](18, 2) NOT NULL,
	[RemainingCredit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SaveTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Semester] [int] NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ClassRoomAllocationAndClassSchedule]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ClassRoomAllocationAndClassSchedule]
AS
SELECT        c.Code, c.Name AS CourseName, b.Name AS RoomName, a.Day, a.FromTime, a.ToTime, a.DepartmentId, a.Flag
FROM            dbo.AllocateClassRoom AS a INNER JOIN
                         dbo.SaveClassRoom AS b ON a.RoomId = b.Id INNER JOIN
                         dbo.SaveCourse AS c ON a.CourseId = c.Id



GO
/****** Object:  View [dbo].[StudentCourseAssign]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentCourseAssign]
AS
SELECT        d.ID AS DepartmentID, s.ID, s.RegistrationNo, s.Name, s.Email, d.Name AS DepartmentName
FROM            dbo.SaveStudent AS s INNER JOIN
                         dbo.SaveDepartment AS d ON s.DepartmentId = d.ID




GO
/****** Object:  View [dbo].[StudentCourseWiseView]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentCourseWiseView]
AS
SELECT        s.StudentId, s.CourseGrade, c.Code, c.Name, s.Flag
FROM            dbo.CourseEnroll AS s LEFT OUTER JOIN
                         dbo.SaveCourse AS c ON s.CourseId = c.Id



GO
/****** Object:  View [dbo].[StudentResultView]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentResultView]
AS
SELECT        s.StudentId, s.Name, s.Email, s.DepartmentName, s.CourseId, c.Name AS CourseName, s.Flag
FROM            dbo.CourseEnroll AS s LEFT OUTER JOIN
                         dbo.SaveCourse AS c ON s.CourseId = c.Id



GO
/****** Object:  View [dbo].[ViewCourseStatics]    Script Date: 12/21/2018 11:34:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewCourseStatics]
AS
SELECT c.Code,c.Name,c.DepartmentID,s.Semester,c.Assigned,c.TeacherID from SaveCourse as c
inner join Semesters as s
on c.SemesterID=s.ID







GO
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] ON 

INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [FromTime], [ToTime], [Flag]) VALUES (1, 1, 25, 5, N'FRI', N'10:00 AM', N'11:00 AM', 1)
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [FromTime], [ToTime], [Flag]) VALUES (2, 3, 22, 10, N'FRI', N'10:00 AM', N'11:00 AM', 1)
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [FromTime], [ToTime], [Flag]) VALUES (3, 4, 11, 15, N'FRI', N'10:00 AM', N'11:00 AM', 1)
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [FromTime], [ToTime], [Flag]) VALUES (4, 1, 25, 5, N'THU', N'10:00 AM', N'11:00 AM', 1)
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [FromTime], [ToTime], [Flag]) VALUES (5, 1, 25, 5, N'WED', N'10:00 AM', N'11:00 AM', 1)
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] OFF
SET IDENTITY_INSERT [dbo].[CourseEnroll] ON 

INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (1, 1, N'Mahir', N'mahir@gmail.com', CAST(0x183F0B00 AS Date), N'Computer Science & Engineering', 1, N'A', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (2, 1, N'Mahir', N'mahir@gmail.com', CAST(0x183F0B00 AS Date), N'Computer Science & Engineering', 2, N'A+', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (3, 1, N'Mahir', N'mahir@gmail.com', CAST(0x183F0B00 AS Date), N'Computer Science & Engineering', 3, N'A', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (4, 2, N'Rifat', N'rifat@gmail.com', CAST(0x183F0B00 AS Date), N'Computer Science & Engineering', 1, N'Not graded yet', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (5, 2, N'Rifat', N'rifat@gmail.com', CAST(0x183F0B00 AS Date), N'Computer Science & Engineering', 2, N'Not graded yet', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (6, 2, N'Rifat', N'rifat@gmail.com', CAST(0x183F0B00 AS Date), N'Computer Science & Engineering', 3, N'Not graded yet', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (7, 5, N'Jahed', N'jahed@gmail.com', CAST(0x183F0B00 AS Date), N'Physics', 6, N'A+', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (8, 5, N'Jahed', N'jahed@gmail.com', CAST(0x183F0B00 AS Date), N'Physics', 7, N'Not graded yet', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (9, 5, N'Jahed', N'jahed@gmail.com', CAST(0x183F0B00 AS Date), N'Physics', 8, N'Not graded yet', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (10, 9, N'Abid', N'abid@gmail.com', CAST(0x183F0B00 AS Date), N'Mathemathics', 9, N'A+', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (11, 10, N'Kalim', N'kalim@gmail.com', CAST(0x183F0B00 AS Date), N'Mathemathics', 10, N'A+', 1)
INSERT [dbo].[CourseEnroll] ([Id], [StudentId], [Name], [Email], [Date], [DepartmentName], [CourseId], [CourseGrade], [Flag]) VALUES (12, 12, N'Shanto', N'shanto@gmail.com', CAST(0x183F0B00 AS Date), N'Mathemathics', 9, N'Not graded yet', 1)
SET IDENTITY_INSERT [dbo].[CourseEnroll] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (1, N'Professor')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (2, N'Assistant Professor')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (3, N'Lecturer')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (4, N'Assistant Lecturer')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[SaveClassRoom] ON 

INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (1, N'R-101', 1)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (2, N'R-102', 1)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (3, N'R-103', 1)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (4, N'R-104', 1)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (5, N'R-105', 1)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (6, N'R-301', 3)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (7, N'R-302', 3)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (8, N'R-303', 3)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (9, N'R-304', 3)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (10, N'R-305', 3)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (11, N'R-401', 4)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (12, N'R-402', 4)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (13, N'R-403', 4)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (14, N'R-404', 4)
INSERT [dbo].[SaveClassRoom] ([Id], [Name], [DepartmentId]) VALUES (15, N'R-405', 4)
SET IDENTITY_INSERT [dbo].[SaveClassRoom] OFF
SET IDENTITY_INSERT [dbo].[SaveCourse] ON 

INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (1, N'CSE-101', N'C Programming', CAST(3.00 AS Decimal(18, 2)), N'It is a computer programming language', 1, 8, N'true', 1)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (2, N'CSE-102', N'C++', CAST(5.00 AS Decimal(18, 2)), N'It is a object oriented programming language', 1, 8, N'true', 2)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (3, N'CSE-103', N'Java', CAST(5.00 AS Decimal(18, 2)), N'It is also object oriented language.', 1, 8, N'true', 3)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (4, N'CSE-104', N'Operating System', CAST(5.00 AS Decimal(18, 2)), N'OS related subject.', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (5, N'CSE-105', N'Compiler', CAST(5.00 AS Decimal(18, 2)), N'Its build programming language', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (6, N'PHY-101', N'Electric Potential', CAST(5.00 AS Decimal(18, 2)), N'The idea of electic potential is related to work done.', 3, 8, N'true', 4)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (7, N'PHY-102', N'Capacitence', CAST(5.00 AS Decimal(18, 2)), N'Two conductors of arbitary shape', 3, 8, N'true', 5)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (8, N'PHY-103', N'Magnetic Field', CAST(5.00 AS Decimal(18, 2)), N'Forces between two moving charges.', 3, 8, N'true', 6)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (9, N'MATH-101', N'Algebra', CAST(5.00 AS Decimal(18, 2)), N'The charge', 4, 8, N'true', 7)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (10, N'MATH-102', N'Numerical Method', CAST(5.00 AS Decimal(18, 2)), N'Numerical calculation', 4, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (11, N'MATH-103', N'Theory of Computing', CAST(5.00 AS Decimal(18, 2)), N'Turing Machine', 4, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (12, N'CSE-201', N'Computer Graphics', CAST(5.00 AS Decimal(18, 2)), N'Design', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (13, N'CSE-202', N'Image Processing', CAST(5.00 AS Decimal(18, 2)), N'Image Design', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (14, N'CSE-203', N'Computer Architecture', CAST(5.00 AS Decimal(18, 2)), N'Architectural study', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (15, N'CSE-204', N'Data Structure', CAST(5.00 AS Decimal(18, 2)), N'Algorithm', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (16, N'CSE-205', N'Algorithm', CAST(5.00 AS Decimal(18, 2)), N'Algorithmic Study', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (19, N'PHY-201', N'Magnetic Effects', CAST(5.00 AS Decimal(18, 2)), N'The Biot-Savart Law', 3, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (20, N'PHY-202', N'D.C.Circuit', CAST(5.00 AS Decimal(18, 2)), N'calculation of current in a single loop', 3, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (21, N'PHY-203', N'Gauss Law', CAST(5.00 AS Decimal(18, 2)), N'Flux of electricalfield', 3, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (22, N'PHY-204', N'Magnetism', CAST(5.00 AS Decimal(18, 2)), N'Magnetization', 3, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (23, N'CSE-301', N'Database', CAST(5.00 AS Decimal(18, 2)), N'Database', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (24, N'CSE-302', N'System Analysis', CAST(5.00 AS Decimal(18, 2)), N'Agile Method', 1, 8, N'False', NULL)
INSERT [dbo].[SaveCourse] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId], [Assigned], [TeacherId]) VALUES (25, N'CSE-303', N'Network', CAST(5.00 AS Decimal(18, 2)), N'Networl', 1, 8, N'False', NULL)
SET IDENTITY_INSERT [dbo].[SaveCourse] OFF
SET IDENTITY_INSERT [dbo].[SaveDepartment] ON 

INSERT [dbo].[SaveDepartment] ([Id], [Code], [Name]) VALUES (1, N'CSE', N'Computer Science & Engineering')
INSERT [dbo].[SaveDepartment] ([Id], [Code], [Name]) VALUES (3, N'PHY', N'Physics')
INSERT [dbo].[SaveDepartment] ([Id], [Code], [Name]) VALUES (4, N'MATH', N'Mathemathics')
SET IDENTITY_INSERT [dbo].[SaveDepartment] OFF
SET IDENTITY_INSERT [dbo].[SaveStudent] ON 

INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (1, N'Mahir', N'mahir@gmail.com', N'01234', CAST(0x183F0B00 AS Date), N'Kotowali', N'CSE-2018-001', 1)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (2, N'Rifat', N'rifat@gmail.com', N'012345', CAST(0x183F0B00 AS Date), N'Rupsha', N'CSE-2018-002', 1)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (3, N'Tanim', N'tanim@gmail.com', N'51545', CAST(0x183F0B00 AS Date), N'Dewanhat', N'CSE-2018-003', 1)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (4, N'Azam', N'azam@gmail.com', N'515454', CAST(0x183F0B00 AS Date), N'Chawkbazar', N'CSE-2018-004', 1)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (5, N'Jahed', N'jahed@gmail.com', N'5154548', CAST(0x183F0B00 AS Date), N'Chawkbazar', N'PHY-2018-001', 3)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (6, N'Avishek', N'avishek@gmail.com', N'5185148', CAST(0x183F0B00 AS Date), N'Chawkbazar', N'PHY-2018-002', 3)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (7, N'Shahadat', N'sh@gmail.com', N'841561', CAST(0x183F0B00 AS Date), N'Agrabad', N'PHY-2018-003', 3)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (8, N'Hasnat', N'hasnat@gmail.com', N'746441', CAST(0x183F0B00 AS Date), N'Kotowali', N'PHY-2018-004', 3)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (9, N'Abid', N'abid@gmail.com', N'77777', CAST(0x183F0B00 AS Date), N'New Market', N'MATH-2018-001', 4)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (10, N'Kalim', N'kalim@gmail.com', N'11111', CAST(0x183F0B00 AS Date), N'AK.kHAN', N'MATH-2018-002', 4)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (11, N'Sadek', N'sadek@gmail.com', N'66666', CAST(0x183F0B00 AS Date), N'DC.Hill', N'MATH-2018-003', 4)
INSERT [dbo].[SaveStudent] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [RegistrationNo], [DepartmentId]) VALUES (12, N'Shanto', N'shanto@gmail.com', N'146541235', CAST(0x183F0B00 AS Date), N'AK.khan', N'MATH-2018-004', 4)
SET IDENTITY_INSERT [dbo].[SaveStudent] OFF
SET IDENTITY_INSERT [dbo].[SaveTeacher] ON 

INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (1, N'Abdul Kadar Masum', N'Agrabad', N'masum@gmail.com', N'12345', 1, 1, CAST(10.00 AS Decimal(18, 2)), CAST(7.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (2, N'Jamil Al-Asad', N'Chawkbazar', N'jamil@gmail.com', N'54321', 2, 1, CAST(7.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (3, N'Khaliluzzaman', N'Kotowali', N'khalil@gmail.com', N'01234', 1, 1, CAST(8.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (4, N'Moazzem Hossain', N'Kotowali', N'moazzem@gmail.com', N'12345', 1, 3, CAST(9.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (5, N'Arif Hasnayeen', N'Agrabad', N'arif@gmail.com', N'54321', 1, 3, CAST(8.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (6, N'Mahmudur Rahman', N'Chawkbazar', N'rahman@gmail.com', N'01234', 2, 3, CAST(7.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (7, N'Manjur Alam', N'Chawkbazar', N'alam@gmail.com', N'01234', 2, 4, CAST(9.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (8, N'Rashedul Islam', N'Agrabad', N'rashed@gmail.com', N'12345', 2, 4, CAST(7.00 AS Decimal(18, 2)), CAST(7.00 AS Decimal(18, 2)))
INSERT [dbo].[SaveTeacher] ([Id], [Name], [Address], [Email], [ContactNumber], [DesignationId], [DepartmentId], [TotalCredit], [RemainingCredit]) VALUES (9, N'Ahmed Imteaj', N'Kotowali', N'Imteaz@gmail.com', N'54321', 2, 4, CAST(8.00 AS Decimal(18, 2)), CAST(8.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SaveTeacher] OFF
SET IDENTITY_INSERT [dbo].[Semesters] ON 

INSERT [dbo].[Semesters] ([Id], [Semester]) VALUES (1, 1)
INSERT [dbo].[Semesters] ([Id], [Semester]) VALUES (2, 2)
INSERT [dbo].[Semesters] ([Id], [Semester]) VALUES (3, 3)
INSERT [dbo].[Semesters] ([Id], [Semester]) VALUES (4, 4)
INSERT [dbo].[Semesters] ([Id], [Semester]) VALUES (5, 5)
INSERT [dbo].[Semesters] ([Id], [Semester]) VALUES (6, 6)
INSERT [dbo].[Semesters] ([Id], [Semester]) VALUES (7, 7)
INSERT [dbo].[Semesters] ([Id], [Semester]) VALUES (8, 8)
SET IDENTITY_INSERT [dbo].[Semesters] OFF
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_SaveClassRoom] FOREIGN KEY([RoomId])
REFERENCES [dbo].[SaveClassRoom] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_SaveClassRoom]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_SaveCourse] FOREIGN KEY([CourseId])
REFERENCES [dbo].[SaveCourse] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_SaveCourse]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_SaveDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[SaveDepartment] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_SaveDepartment]
GO
ALTER TABLE [dbo].[SaveClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_SaveClassRoom_SaveDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[SaveDepartment] ([Id])
GO
ALTER TABLE [dbo].[SaveClassRoom] CHECK CONSTRAINT [FK_SaveClassRoom_SaveDepartment]
GO
ALTER TABLE [dbo].[SaveCourse]  WITH CHECK ADD  CONSTRAINT [FK_SaveCourse_SaveDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[SaveDepartment] ([Id])
GO
ALTER TABLE [dbo].[SaveCourse] CHECK CONSTRAINT [FK_SaveCourse_SaveDepartment]
GO
ALTER TABLE [dbo].[SaveCourse]  WITH CHECK ADD  CONSTRAINT [FK_SaveCourse_Semesters] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[SaveCourse] CHECK CONSTRAINT [FK_SaveCourse_Semesters]
GO
ALTER TABLE [dbo].[SaveStudent]  WITH CHECK ADD  CONSTRAINT [FK_SaveStudent_SaveStudent] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[SaveDepartment] ([Id])
GO
ALTER TABLE [dbo].[SaveStudent] CHECK CONSTRAINT [FK_SaveStudent_SaveStudent]
GO
ALTER TABLE [dbo].[SaveTeacher]  WITH CHECK ADD  CONSTRAINT [FK_SaveTeacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[SaveTeacher] CHECK CONSTRAINT [FK_SaveTeacher_Designation]
GO
ALTER TABLE [dbo].[SaveTeacher]  WITH CHECK ADD  CONSTRAINT [FK_SaveTeacher_SaveTeacher] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[SaveDepartment] ([Id])
GO
ALTER TABLE [dbo].[SaveTeacher] CHECK CONSTRAINT [FK_SaveTeacher_SaveTeacher]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 119
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 120
               Left = 246
               Bottom = 250
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClassRoomAllocationAndClassSchedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClassRoomAllocationAndClassSchedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 119
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseAssign'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseAssign'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 136
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseWiseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseWiseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 136
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentResultView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentResultView'
GO
USE [master]
GO
ALTER DATABASE [Nautic_DB] SET  READ_WRITE 
GO
