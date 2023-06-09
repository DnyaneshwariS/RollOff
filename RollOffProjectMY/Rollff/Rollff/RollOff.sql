USE [master]
GO
/****** Object:  Database [RollOffDB]    Script Date: 23-Feb-23 1:43:07 AM ******/
CREATE DATABASE [RollOffDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RollOffDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RollOffDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RollOffDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RollOffDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RollOffDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RollOffDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RollOffDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RollOffDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RollOffDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RollOffDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RollOffDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RollOffDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RollOffDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RollOffDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RollOffDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RollOffDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RollOffDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RollOffDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RollOffDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RollOffDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RollOffDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RollOffDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RollOffDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RollOffDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RollOffDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RollOffDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RollOffDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RollOffDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RollOffDB] SET RECOVERY FULL 
GO
ALTER DATABASE [RollOffDB] SET  MULTI_USER 
GO
ALTER DATABASE [RollOffDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RollOffDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RollOffDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RollOffDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RollOffDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RollOffDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RollOffDB', N'ON'
GO
ALTER DATABASE [RollOffDB] SET QUERY_STORE = OFF
GO
USE [RollOffDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23-Feb-23 1:43:08 AM ******/
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
/****** Object:  Table [dbo].[AssignedFrom]    Script Date: 23-Feb-23 1:43:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignedFrom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserDetailsId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[RollOffFormId] [int] NOT NULL,
	[FeedbackFormId] [int] NOT NULL,
	[AssignedTo] [int] NOT NULL,
 CONSTRAINT [PK_AssignedFrom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 23-Feb-23 1:43:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[GlobalGroupID] [int] NOT NULL,
	[EmployeeNo] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[LocalGrade] [nvarchar](max) NULL,
	[MainClient] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[JoiningDate] [datetime2](7) NULL,
	[ProjectCode] [int] NULL,
	[ProjectName] [nvarchar](max) NULL,
	[ProjectStartDate] [datetime2](7) NULL,
	[ProjectEndDate] [datetime2](7) NULL,
	[PeopleManager] [nvarchar](max) NULL,
	[Practice] [nvarchar](max) NULL,
	[PSPName] [nvarchar](max) NULL,
	[NewGlobalPractice] [nvarchar](max) NULL,
	[OfficeCity] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[GlobalGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackForm]    Script Date: 23-Feb-23 1:43:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackForm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TechnicalSkill] [nvarchar](500) NOT NULL,
	[Communication] [nvarchar](500) NULL,
	[RoleCompetance] [nvarchar](500) NULL,
	[Remarks] [nvarchar](500) NOT NULL,
	[RelevantExperience] [int] NOT NULL,
 CONSTRAINT [PK_RollOffAssigned] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReasonMaster]    Script Date: 23-Feb-23 1:43:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReasonMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReasonName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Creator] [nvarchar](50) NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_ReasonMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 23-Feb-23 1:43:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Creator] [nvarchar](50) NULL,
	[CrationDate] [datetime] NULL,
 CONSTRAINT [PK_RoleMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RollOffForm]    Script Date: 23-Feb-23 1:43:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RollOffForm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrimarySkill] [nvarchar](500) NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Reason] [nvarchar](500) NOT NULL,
	[OtherReason] [nvarchar](max) NULL,
	[PerformanceIssue] [bit] NOT NULL,
	[Resgined] [bit] NOT NULL,
	[UnderProbation] [bit] NOT NULL,
	[LongLeave] [bit] NOT NULL,
	[LeaveType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RollOffDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferedFrom]    Script Date: 23-Feb-23 1:43:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferedFrom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[AssignedFrom] [int] NOT NULL,
	[IsAactivate] [bit] NOT NULL,
	[IsTransfered] [bit] NOT NULL,
 CONSTRAINT [PK_TransferedFrom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 23-Feb-23 1:43:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ReasonMaster] ADD  CONSTRAINT [DF_ReasonMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ReasonMaster] ADD  CONSTRAINT [DF_ReasonMaster_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_Role_Master_CrationDate]  DEFAULT (getdate()) FOR [CrationDate]
GO
USE [master]
GO
ALTER DATABASE [RollOffDB] SET  READ_WRITE 
GO
