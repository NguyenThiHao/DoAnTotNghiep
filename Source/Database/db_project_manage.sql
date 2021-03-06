USE [master]
GO
/****** Object:  Database [db_project_manage]    Script Date: 11/9/2017 9:23:23 PM ******/
CREATE DATABASE [db_project_manage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_project_manage', FILENAME = N'e:\Study\SQL server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_project_manage.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_project_manage_log', FILENAME = N'e:\Study\SQL server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_project_manage_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_project_manage] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_project_manage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_project_manage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_project_manage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_project_manage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_project_manage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_project_manage] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_project_manage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_project_manage] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [db_project_manage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_project_manage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_project_manage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_project_manage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_project_manage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_project_manage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_project_manage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_project_manage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_project_manage] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_project_manage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_project_manage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_project_manage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_project_manage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_project_manage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_project_manage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_project_manage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_project_manage] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_project_manage] SET  MULTI_USER 
GO
ALTER DATABASE [db_project_manage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_project_manage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_project_manage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_project_manage] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [db_project_manage]
GO
/****** Object:  Table [dbo].[AuthorityType]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorityType](
	[id_authority_type] [int] IDENTITY(1,1) NOT NULL,
	[name_authority_type] [nvarchar](100) NOT NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_AuthorityType] PRIMARY KEY CLUSTERED 
(
	[id_authority_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id_category] [int] IDENTITY(1,1) NOT NULL,
	[name_category] [nvarchar](50) NOT NULL,
	[status] [bit] NOT NULL,
	[link] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DevelopGroup]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevelopGroup](
	[id_develop_group] [int] IDENTITY(1,1) NOT NULL,
	[name_group] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[id_authority] [int] NOT NULL,
 CONSTRAINT [PK_DevelopGroup] PRIMARY KEY CLUSTERED 
(
	[id_develop_group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phase]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phase](
	[id_phase] [int] IDENTITY(1,1) NOT NULL,
	[phase_name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[pre_phase] [int] NOT NULL,
	[id_project] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[id_status_phase] [int] NOT NULL,
 CONSTRAINT [PK_Phase] PRIMARY KEY CLUSTERED 
(
	[id_phase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[id_project] [int] IDENTITY(1,1) NOT NULL,
	[project_name] [nvarchar](100) NOT NULL,
	[leader] [int] NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[id_status_project] [int] NOT NULL,
	[type_project] [nvarchar](100) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[id_project] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusType]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusType](
	[id_status_type] [int] IDENTITY(1,1) NOT NULL,
	[name_status_type] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_StatusType] PRIMARY KEY CLUSTERED 
(
	[id_status_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Task]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Task](
	[id_task] [int] IDENTITY(1,1) NOT NULL,
	[task_name] [nvarchar](50) NOT NULL,
	[summary_task] [nvarchar](200) NOT NULL,
	[id_project] [int] NOT NULL,
	[id_phase] [int] NOT NULL,
	[plan_start_date] [date] NOT NULL,
	[plan_end_date] [date] NOT NULL,
	[estimate_time] [int] NOT NULL,
	[real_start_date] [date] NOT NULL,
	[real_end_date] [date] NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[id_task_type] [int] NOT NULL,
	[assignee_to] [int] NOT NULL,
	[id_status_task] [int] NOT NULL,
	[id_authority] [int] NOT NULL,
	[pre_task] [int] NULL,
	[link] [nvarchar](200) NOT NULL,
	[reporter] [int] NOT NULL,
	[priority] [varchar](10) NOT NULL,
	[task_level] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[id_task] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaskType]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskType](
	[id_task_type] [int] IDENTITY(1,1) NOT NULL,
	[name_task_type] [nvarchar](50) NOT NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_TaskType] PRIMARY KEY CLUSTERED 
(
	[id_task_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Timesheet]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timesheet](
	[id_timesheet] [int] IDENTITY(1,1) NOT NULL,
	[id_task] [int] NOT NULL,
	[reporter] [int] NOT NULL,
	[time] [int] NOT NULL,
	[description] [nvarchar](200) NOT NULL,
	[id_work_type] [int] NULL,
 CONSTRAINT [PK_Timesheet] PRIMARY KEY CLUSTERED 
(
	[id_timesheet] ASC,
	[id_task] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeOfWork]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfWork](
	[id_work_type] [int] IDENTITY(1,1) NOT NULL,
	[name_work_type] [nvarchar](100) NOT NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_TypeOfWork] PRIMARY KEY CLUSTERED 
(
	[id_work_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 11/9/2017 9:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[account] [varchar](15) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[user_name] [nvarchar](50) NOT NULL,
	[id_develop_group] [int] NOT NULL,
	[id_authority] [int] NOT NULL,
	[mail] [nvarchar](100) NULL,
	[id_status_user] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AuthorityType] ON 

INSERT [dbo].[AuthorityType] ([id_authority_type], [name_authority_type], [description]) VALUES (1, N'Admintrator', N'Quyền truy cập cao nhất dành cho người quản trị, có thể quản trị hệ thống')
INSERT [dbo].[AuthorityType] ([id_authority_type], [name_authority_type], [description]) VALUES (2, N'Project Manager', N'Quyền truy cập của người quản lý dự án, có quyền tạo mới một dự án và phân quyền cho các thành viên trong dự án')
INSERT [dbo].[AuthorityType] ([id_authority_type], [name_authority_type], [description]) VALUES (3, N'Team Lead', N'Quyền truy cập của trưởng nhóm, có thể tạo một công việc và chỉ định cho các thành viên trong nhóm')
INSERT [dbo].[AuthorityType] ([id_authority_type], [name_authority_type], [description]) VALUES (4, N'Member', N'Quyền truy cập của thành viên trong dự án, có thể khai báo công việc')
SET IDENTITY_INSERT [dbo].[AuthorityType] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id_category], [name_category], [status], [link]) VALUES (1, N'Home', 1, N'Home')
INSERT [dbo].[Category] ([id_category], [name_category], [status], [link]) VALUES (2, N'Project', 1, N'Project')
INSERT [dbo].[Category] ([id_category], [name_category], [status], [link]) VALUES (3, N'Phase', 1, N'Phase')
INSERT [dbo].[Category] ([id_category], [name_category], [status], [link]) VALUES (4, N'Task', 1, N'Phase')
INSERT [dbo].[Category] ([id_category], [name_category], [status], [link]) VALUES (5, N'Timesheet', 1, N'Timesheet')
INSERT [dbo].[Category] ([id_category], [name_category], [status], [link]) VALUES (6, N'Report', 1, N'Report')
INSERT [dbo].[Category] ([id_category], [name_category], [status], [link]) VALUES (7, N'Grantt Chart', 1, N'Grantt Chart')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[DevelopGroup] ON 

INSERT [dbo].[DevelopGroup] ([id_develop_group], [name_group], [description], [id_authority]) VALUES (2, N'Đội thiết kế', N'Đội thiết kế của dự án', 1)
INSERT [dbo].[DevelopGroup] ([id_develop_group], [name_group], [description], [id_authority]) VALUES (3, N'Đội phát triển', N'Đội code', 1)
INSERT [dbo].[DevelopGroup] ([id_develop_group], [name_group], [description], [id_authority]) VALUES (4, N'Đội kiểm thử', N'Kiểm tra chất lượng của sản phẩm', 1)
SET IDENTITY_INSERT [dbo].[DevelopGroup] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id_user], [account], [password], [user_name], [id_develop_group], [id_authority], [mail], [id_status_user]) VALUES (1, N'haont', N'123', N'hao', 1, 1, N'hao@gmail.com', N'1')
INSERT [dbo].[User] ([id_user], [account], [password], [user_name], [id_develop_group], [id_authority], [mail], [id_status_user]) VALUES (2, N'admin', N'admin', N'admin', 1, 1, N'admin@gmail.com', N'1')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Phase]  WITH CHECK ADD  CONSTRAINT [FK_Phase_Project] FOREIGN KEY([id_project])
REFERENCES [dbo].[Project] ([id_project])
GO
ALTER TABLE [dbo].[Phase] CHECK CONSTRAINT [FK_Phase_Project]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Phase] FOREIGN KEY([id_phase])
REFERENCES [dbo].[Phase] ([id_phase])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Phase]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([id_project])
REFERENCES [dbo].[Project] ([id_project])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_StatusType] FOREIGN KEY([id_status_task])
REFERENCES [dbo].[StatusType] ([id_status_type])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_StatusType]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskType] FOREIGN KEY([id_task_type])
REFERENCES [dbo].[TaskType] ([id_task_type])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_TaskType]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User] FOREIGN KEY([assignee_to])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User1] FOREIGN KEY([reporter])
REFERENCES [dbo].[User] ([id_user])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User1]
GO
ALTER TABLE [dbo].[Timesheet]  WITH CHECK ADD  CONSTRAINT [FK_Timesheet_Task] FOREIGN KEY([id_task])
REFERENCES [dbo].[Task] ([id_task])
GO
ALTER TABLE [dbo].[Timesheet] CHECK CONSTRAINT [FK_Timesheet_Task]
GO
ALTER TABLE [dbo].[Timesheet]  WITH CHECK ADD  CONSTRAINT [FK_Timesheet_TypeOfWork] FOREIGN KEY([id_work_type])
REFERENCES [dbo].[TypeOfWork] ([id_work_type])
GO
ALTER TABLE [dbo].[Timesheet] CHECK CONSTRAINT [FK_Timesheet_TypeOfWork]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_AuthorityType] FOREIGN KEY([id_authority])
REFERENCES [dbo].[AuthorityType] ([id_authority_type])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_AuthorityType]
GO
USE [master]
GO
ALTER DATABASE [db_project_manage] SET  READ_WRITE 
GO
