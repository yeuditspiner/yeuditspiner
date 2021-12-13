USE [master]
GO
/****** Object:  Database [YeuditTablePlaceMent]    Script Date: 25/10/2021 13:32:11 ******/
CREATE DATABASE [YeuditTablePlaceMent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YeuditTablePlaceMent', FILENAME = N'D:\MSSQL\Data\YeuditTablePlaceMent.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'YeuditTablePlaceMent_log', FILENAME = N'D:\MSSQL\Data\YeuditTablePlaceMent_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [YeuditTablePlaceMent] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YeuditTablePlaceMent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YeuditTablePlaceMent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET ARITHABORT OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET  DISABLE_BROKER 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET RECOVERY FULL 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET  MULTI_USER 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YeuditTablePlaceMent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [YeuditTablePlaceMent] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'YeuditTablePlaceMent', N'ON'
GO
ALTER DATABASE [YeuditTablePlaceMent] SET QUERY_STORE = OFF
GO
USE [YeuditTablePlaceMent]
GO
/****** Object:  Table [dbo].[ClassTbl]    Script Date: 25/10/2021 13:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTbl](
	[ClassID] [int] NOT NULL,
	[ClassNmae] [nchar](10) NULL,
 CONSTRAINT [PK_ClassTbl] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTbl]    Script Date: 25/10/2021 13:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTbl](
	[StudentID] [int] NOT NULL,
	[LastName] [nchar](20) NULL,
	[FirstName] [nchar](20) NULL,
	[Chatter] [int] NULL,
	[AdviceableLine] [int] NULL,
	[Coulnm] [int] NULL,
	[Line] [int] NULL,
	[ClassID] [int] NULL,
 CONSTRAINT [PK_StudentTbl] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypicalTbl]    Script Date: 25/10/2021 13:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypicalTbl](
	[TypicalID] [int] NOT NULL,
	[DetailTypical] [nchar](100) NULL,
 CONSTRAINT [PK_TypicalTbl] PRIMARY KEY CLUSTERED 
(
	[TypicalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypicalToStudentTbl]    Script Date: 25/10/2021 13:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypicalToStudentTbl](
	[StudentID] [int] NOT NULL,
	[TypicalID] [int] NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [IX_TypicalToStudentTbl] UNIQUE NONCLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_TypicalToStudentTbl_1] UNIQUE NONCLUSTERED 
(
	[TypicalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StudentTbl]  WITH CHECK ADD  CONSTRAINT [FK_StudentTbl_ClassTbl] FOREIGN KEY([ClassID])
REFERENCES [dbo].[ClassTbl] ([ClassID])
GO
ALTER TABLE [dbo].[StudentTbl] CHECK CONSTRAINT [FK_StudentTbl_ClassTbl]
GO
ALTER TABLE [dbo].[StudentTbl]  WITH CHECK ADD  CONSTRAINT [FK_StudentTbl_TypicalToStudentTbl] FOREIGN KEY([StudentID])
REFERENCES [dbo].[TypicalToStudentTbl] ([StudentID])
GO
ALTER TABLE [dbo].[StudentTbl] CHECK CONSTRAINT [FK_StudentTbl_TypicalToStudentTbl]
GO
ALTER TABLE [dbo].[TypicalToStudentTbl]  WITH CHECK ADD  CONSTRAINT [FK_TypicalToStudentTbl_TypicalTbl] FOREIGN KEY([TypicalID])
REFERENCES [dbo].[TypicalTbl] ([TypicalID])
GO
ALTER TABLE [dbo].[TypicalToStudentTbl] CHECK CONSTRAINT [FK_TypicalToStudentTbl_TypicalTbl]
GO
USE [master]
GO
ALTER DATABASE [YeuditTablePlaceMent] SET  READ_WRITE 
GO
