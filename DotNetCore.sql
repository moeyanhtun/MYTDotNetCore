USE [master]
GO
/****** Object:  Database [MYTDotNetCore]    Script Date: 4/23/2024 3:29:49 PM ******/
CREATE DATABASE [MYTDotNetCore] ON  PRIMARY 
( NAME = N'MYTDotNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQL\MSSQL\DATA\MYTDotNetCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MYTDotNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQL\MSSQL\DATA\MYTDotNetCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MYTDotNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MYTDotNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MYTDotNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MYTDotNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MYTDotNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MYTDotNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MYTDotNetCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MYTDotNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [MYTDotNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MYTDotNetCore] SET DB_CHAINING OFF 
GO
USE [MYTDotNetCore]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 4/23/2024 3:29:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'This is Title', N'This is Author', N'This is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'This is Title', N'This is Author', N'This is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'This is Title', N'This is Author', N'This is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'This is Title', N'This is Author', N'This is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'This is Title', N'This is Author', N'This is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'This is Title', N'This is Author', N'This is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'This is Title', N'This is Author', N'This is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'This is Title', N'This is Author', N'This is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'this is title', N'this is Author', N'this is Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'Update Title', N'Update Author', N'Update Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (12, N'this is title', N'this is Author', N'this is Content')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
USE [master]
GO
ALTER DATABASE [MYTDotNetCore] SET  READ_WRITE 
GO

