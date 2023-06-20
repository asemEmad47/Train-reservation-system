USE [master]
GO
/****** Object:  Database [Train System]    Script Date: 5/23/2023 11:19:25 PM ******/
CREATE DATABASE [Train System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Train System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER2022\MSSQL\DATA\Train System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Train System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER2022\MSSQL\DATA\Train System_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Train System] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Train System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Train System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Train System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Train System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Train System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Train System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Train System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Train System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Train System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Train System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Train System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Train System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Train System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Train System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Train System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Train System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Train System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Train System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Train System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Train System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Train System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Train System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Train System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Train System] SET RECOVERY FULL 
GO
ALTER DATABASE [Train System] SET  MULTI_USER 
GO
ALTER DATABASE [Train System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Train System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Train System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Train System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Train System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Train System] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Train System', N'ON'
GO
ALTER DATABASE [Train System] SET QUERY_STORE = ON
GO
ALTER DATABASE [Train System] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Train System]
GO
/****** Object:  Table [dbo].[ADMIN]    Script Date: 5/23/2023 11:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN](
	[ADMINID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [varchar](100) NOT NULL,
	[EMAIL] [varchar](100) NOT NULL,
	[PASSWORD] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ADMIN] PRIMARY KEY CLUSTERED 
(
	[ADMINID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[EMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BOOKING]    Script Date: 5/23/2023 11:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOOKING](
	[BOOKINGID] [int] IDENTITY(1,1) NOT NULL,
	[CLIENTID] [int] NOT NULL,
	[TRIPID] [int] NOT NULL,
 CONSTRAINT [PK_BOOKING] PRIMARY KEY CLUSTERED 
(
	[BOOKINGID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENT]    Script Date: 5/23/2023 11:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENT](
	[CLIENTID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [varchar](100) NOT NULL,
	[EMAIL] [varchar](100) NOT NULL,
	[PASSWORD] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CLIENT] PRIMARY KEY CLUSTERED 
(
	[CLIENTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[EMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTTRIP]    Script Date: 5/23/2023 11:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTTRIP](
	[CLIENTTRIPID] [int] IDENTITY(1,1) NOT NULL,
	[CLIENTID] [int] NOT NULL,
	[TRIPID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CLIENTTRIPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SEAT]    Script Date: 5/23/2023 11:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEAT](
	[SEATID] [int] IDENTITY(1,1) NOT NULL,
	[TRAINID] [int] NOT NULL,
	[BOOKINGID] [int] NULL,
 CONSTRAINT [PK_SEAT] PRIMARY KEY CLUSTERED 
(
	[SEATID] ASC,
	[TRAINID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SEATID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRAIN]    Script Date: 5/23/2023 11:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRAIN](
	[ADMINID] [int] NOT NULL,
	[NUMOFSEATS] [int] NOT NULL,
	[AVAILABLESEATS] [int] NOT NULL,
	[trainid] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[trainid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRIP]    Script Date: 5/23/2023 11:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRIP](
	[TRIPID] [int] IDENTITY(1,1) NOT NULL,
	[ADMINID] [int] NOT NULL,
	[DESTINATION] [varchar](100) NOT NULL,
	[ORIGIN] [varchar](100) NOT NULL,
	[DATE] [date] NOT NULL,
	[PRICE] [float] NOT NULL,
	[TRAINID] [int] NOT NULL,
	[duration] [float] NOT NULL,
 CONSTRAINT [PK_TRIP] PRIMARY KEY CLUSTERED 
(
	[TRIPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BOOKING]  WITH CHECK ADD  CONSTRAINT [fk_BookingCLIENT] FOREIGN KEY([CLIENTID])
REFERENCES [dbo].[CLIENT] ([CLIENTID])
GO
ALTER TABLE [dbo].[BOOKING] CHECK CONSTRAINT [fk_BookingCLIENT]
GO
ALTER TABLE [dbo].[BOOKING]  WITH CHECK ADD  CONSTRAINT [fk_bookingTRIP1] FOREIGN KEY([TRIPID])
REFERENCES [dbo].[TRIP] ([TRIPID])
GO
ALTER TABLE [dbo].[BOOKING] CHECK CONSTRAINT [fk_bookingTRIP1]
GO
ALTER TABLE [dbo].[CLIENTTRIP]  WITH CHECK ADD FOREIGN KEY([CLIENTID])
REFERENCES [dbo].[CLIENT] ([CLIENTID])
GO
ALTER TABLE [dbo].[CLIENTTRIP]  WITH CHECK ADD FOREIGN KEY([TRIPID])
REFERENCES [dbo].[TRIP] ([TRIPID])
GO
ALTER TABLE [dbo].[SEAT]  WITH CHECK ADD  CONSTRAINT [FK_BOOKINGSEAT] FOREIGN KEY([BOOKINGID])
REFERENCES [dbo].[BOOKING] ([BOOKINGID])
GO
ALTER TABLE [dbo].[SEAT] CHECK CONSTRAINT [FK_BOOKINGSEAT]
GO
ALTER TABLE [dbo].[SEAT]  WITH CHECK ADD  CONSTRAINT [fk_seatTrain] FOREIGN KEY([TRAINID])
REFERENCES [dbo].[TRAIN] ([trainid])
GO
ALTER TABLE [dbo].[SEAT] CHECK CONSTRAINT [fk_seatTrain]
GO
ALTER TABLE [dbo].[TRAIN]  WITH CHECK ADD  CONSTRAINT [FK_admintrain] FOREIGN KEY([ADMINID])
REFERENCES [dbo].[ADMIN] ([ADMINID])
GO
ALTER TABLE [dbo].[TRAIN] CHECK CONSTRAINT [FK_admintrain]
GO
ALTER TABLE [dbo].[TRIP]  WITH CHECK ADD  CONSTRAINT [fk_adminTRIP1] FOREIGN KEY([ADMINID])
REFERENCES [dbo].[ADMIN] ([ADMINID])
GO
ALTER TABLE [dbo].[TRIP] CHECK CONSTRAINT [fk_adminTRIP1]
GO
ALTER TABLE [dbo].[TRIP]  WITH CHECK ADD  CONSTRAINT [FK_TRAINTRIP] FOREIGN KEY([TRAINID])
REFERENCES [dbo].[TRAIN] ([trainid])
GO
ALTER TABLE [dbo].[TRIP] CHECK CONSTRAINT [FK_TRAINTRIP]
GO
ALTER TABLE [dbo].[TRIP]  WITH NOCHECK ADD  CONSTRAINT [upcomingDates] CHECK  (([DATE]>getdate()))
GO
ALTER TABLE [dbo].[TRIP] CHECK CONSTRAINT [upcomingDates]
GO
USE [master]
GO
ALTER DATABASE [Train System] SET  READ_WRITE 
GO
