USE [master]
GO
/****** Object:  Database [EgolfDBnew]    Script Date: 04/03/2024 11:46:42 ******/
CREATE DATABASE [EgolfDBnew]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EgolfDBnew', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EgolfDBnew.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EgolfDBnew_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EgolfDBnew_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EgolfDBnew] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EgolfDBnew].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EgolfDBnew] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EgolfDBnew] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EgolfDBnew] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EgolfDBnew] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EgolfDBnew] SET ARITHABORT OFF 
GO
ALTER DATABASE [EgolfDBnew] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EgolfDBnew] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EgolfDBnew] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EgolfDBnew] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EgolfDBnew] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EgolfDBnew] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EgolfDBnew] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EgolfDBnew] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EgolfDBnew] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EgolfDBnew] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EgolfDBnew] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EgolfDBnew] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EgolfDBnew] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EgolfDBnew] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EgolfDBnew] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EgolfDBnew] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EgolfDBnew] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EgolfDBnew] SET RECOVERY FULL 
GO
ALTER DATABASE [EgolfDBnew] SET  MULTI_USER 
GO
ALTER DATABASE [EgolfDBnew] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EgolfDBnew] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EgolfDBnew] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EgolfDBnew] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EgolfDBnew] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EgolfDBnew] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EgolfDBnew', N'ON'
GO
ALTER DATABASE [EgolfDBnew] SET QUERY_STORE = OFF
GO
USE [EgolfDBnew]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04/03/2024 11:46:47 ******/
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
/****** Object:  Table [dbo].[Caddies]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caddies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Picture] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Fname] [nvarchar](max) NOT NULL,
	[Lname] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Caddies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaddyTees]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaddyTees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[caddyId] [int] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[teeTime] [nvarchar](max) NULL,
	[caddyName] [nvarchar](max) NULL,
	[caddyEmail] [nvarchar](max) NULL,
	[caddyPhone] [nvarchar](max) NULL,
	[caddyGender] [nvarchar](max) NULL,
	[playerId] [nvarchar](max) NULL,
 CONSTRAINT [PK_CaddyTees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfHoles] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fees]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Amount] [nvarchar](max) NULL,
	[Frequency] [nvarchar](max) NULL,
 CONSTRAINT [PK_Fees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameSchedules]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameSchedules](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](60) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[GameTypeId] [bigint] NOT NULL,
 CONSTRAINT [PK_GameSchedules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameTypes]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameTypes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_GameTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holes]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Par] [int] NOT NULL,
	[Yardage] [int] NOT NULL,
	[Handicap] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[HoleNumber] [int] NOT NULL,
 CONSTRAINT [PK_Holes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holetbls]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holetbls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoleNumber] [int] NULL,
	[Par] [int] NULL,
	[Yardage] [int] NULL,
	[Handicap] [int] NULL,
 CONSTRAINT [PK_Holesid] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lawLogins]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lawLogins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_lawLogins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lawtrustdocument]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lawtrustdocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Document] [nvarchar](max) NULL,
	[Author] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[PublishedIn] [datetime2](7) NULL,
	[AddedIn] [datetime2](7) NULL,
	[CoverPicture] [nvarchar](max) NULL,
 CONSTRAINT [PK_lawtrustdocument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lawtrustHandBookCategory]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lawtrustHandBookCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[AddedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_lawtrustHandBookCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lawtrustlogins]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lawtrustlogins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
	[Date] [datetime2](7) NULL,
 CONSTRAINT [PK_LawtrustLogins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lawtrustotp]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lawtrustotp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Otp] [nvarchar](max) NULL,
 CONSTRAINT [PK_lawtrustotp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lawtrusts]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lawtrusts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Lawtrusts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Fname] [nvarchar](max) NULL,
	[Lname] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[PlayerHandicap] [nvarchar](max) NULL,
	[Ggaid] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Picture] [nvarchar](max) NULL,
	[MembershipId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PendingMembers]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PendingMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [nvarchar](max) NULL,
	[Lname] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
 CONSTRAINT [PK_PendingMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tees]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tees](
	[Id] [int] NULL,
	[memberId] [int] NOT NULL,
	[playerType] [varchar](100) NULL,
	[playerEmail] [varchar](100) NULL,
	[teeTime] [varchar](100) NULL,
	[caddyId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeeSlots]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeeSlots](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[memberId] [int] NULL,
	[memberCode] [nvarchar](max) NULL,
	[playerType] [nvarchar](max) NULL,
	[playerEmail] [nvarchar](max) NULL,
	[teeTime] [nvarchar](max) NULL,
	[playerName] [nvarchar](max) NULL,
	[availabilityStatus] [nvarchar](max) NULL,
	[caddyId] [int] NULL,
 CONSTRAINT [PK_TeeSlots] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 04/03/2024 11:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[price] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[ProductTag] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_GameSchedules_GameTypeId]    Script Date: 04/03/2024 11:46:47 ******/
CREATE NONCLUSTERED INDEX [IX_GameSchedules_GameTypeId] ON [dbo].[GameSchedules]
(
	[GameTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Holes_CourseId]    Script Date: 04/03/2024 11:46:47 ******/
CREATE NONCLUSTERED INDEX [IX_Holes_CourseId] ON [dbo].[Holes]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Courses] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Holes] ADD  DEFAULT ((0)) FOR [HoleNumber]
GO
ALTER TABLE [dbo].[GameSchedules]  WITH CHECK ADD  CONSTRAINT [FK_GameSchedules_GameTypes_GameTypeId] FOREIGN KEY([GameTypeId])
REFERENCES [dbo].[GameTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GameSchedules] CHECK CONSTRAINT [FK_GameSchedules_GameTypes_GameTypeId]
GO
ALTER TABLE [dbo].[Holes]  WITH CHECK ADD  CONSTRAINT [FK_Holes_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Holes] CHECK CONSTRAINT [FK_Holes_Courses_CourseId]
GO
USE [master]
GO
ALTER DATABASE [EgolfDBnew] SET  READ_WRITE 
GO
