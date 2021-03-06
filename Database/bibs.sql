USE [master]
GO
/****** Object:  Database [Bibs]    Script Date: 11/13/2014 1:44:22 PM ******/
CREATE DATABASE [Bibs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bibs', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Bibs.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bibs_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Bibs_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bibs] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bibs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bibs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bibs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bibs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bibs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bibs] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bibs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bibs] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Bibs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bibs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bibs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bibs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bibs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bibs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bibs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bibs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bibs] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Bibs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bibs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bibs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bibs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bibs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bibs] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bibs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bibs] SET RECOVERY FULL 
GO
ALTER DATABASE [Bibs] SET  MULTI_USER 
GO
ALTER DATABASE [Bibs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bibs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bibs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bibs] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Bibs]
GO
/****** Object:  StoredProcedure [dbo].[Xmltoconvert]    Script Date: 11/13/2014 1:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Xmltoconvert]
		
  --@bib nvarchar(max),
	@bibid nvarchar(max),
	@bookid nvarchar(max),
	@publisher nvarchar(max),
    
    @Title    nvarchar(max),   
    @Year nvarchar(max),
	@Price nvarchar(max)
   
    
AS
BEGIN
	
 
 insert into Bibs.dbo.book(bibid,bookid,publisher,title,years,price)
 values(@bibid ,@bookid ,@publisher,@Title,@Year,@Price )

	
END

GO
/****** Object:  StoredProcedure [dbo].[Xmltoconvert1]    Script Date: 11/13/2014 1:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Xmltoconvert1]
		
  
	@bibid nvarchar(max),
	@paperid nvarchar(max),
	@publisher nvarchar(max),
   
    @Title    nvarchar(max),   
    @Year nvarchar(max),
    @Price nvarchar(max)
    
AS
BEGIN
	
 
insert into dbo.paper  (bibid,paperid,publisher,title, years,price)
values( @bibid ,@paperid ,@publisher,@Title,@Year,@Price )


   
	
END

GO
/****** Object:  StoredProcedure [dbo].[Xmltoconvert2]    Script Date: 11/13/2014 1:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Xmltoconvert2]
		
  
	
	 @Bookid  nvarchar(max),
    @Author nvarchar(max),
    @Firstname nvarchar(max),
    @Lastname nvarchar(max),
   
   
    @Street nvarchar(max),
    @Zip nvarchar(max),
    @Name nvarchar(max)
    
AS
BEGIN
	
 
  insert into Bibs.dbo.author(bookid,author,firstname,lastname,street,zip,name)values(@Bookid,@Author,@Firstname,@Lastname,@Street,@Zip,@Name )

	
END

GO
/****** Object:  Table [dbo].[author]    Script Date: 11/13/2014 1:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[author](
	[bookid] [varchar](50) NULL,
	[author] [varchar](50) NULL,
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[street] [varchar](50) NULL,
	[zip] [varchar](50) NULL,
	[name] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[book]    Script Date: 11/13/2014 1:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[book](
	[bibid] [varchar](50) NULL,
	[bookid] [varchar](50) NULL,
	[publisher] [varchar](50) NULL,
	[title] [varchar](50) NULL,
	[years] [varchar](50) NULL,
	[price] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[paper]    Script Date: 11/13/2014 1:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[paper](
	[bibid] [varchar](50) NULL,
	[paperid] [varchar](50) NULL,
	[publisher] [varchar](50) NULL,
	[title] [varchar](50) NULL,
	[years] [varchar](50) NULL,
	[price] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Bibs] SET  READ_WRITE 
GO
