USE [master]
GO
/****** Object:  Database [ABCMoneyTransfer]    Script Date: 11/25/2024 9:27:04 AM ******/
CREATE DATABASE [ABCMoneyTransfer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ABCMoneyTransfer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ABCMoneyTransfer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ABCMoneyTransfer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ABCMoneyTransfer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ABCMoneyTransfer] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ABCMoneyTransfer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ABCMoneyTransfer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET ARITHABORT OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ABCMoneyTransfer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ABCMoneyTransfer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ABCMoneyTransfer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ABCMoneyTransfer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET RECOVERY FULL 
GO
ALTER DATABASE [ABCMoneyTransfer] SET  MULTI_USER 
GO
ALTER DATABASE [ABCMoneyTransfer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ABCMoneyTransfer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ABCMoneyTransfer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ABCMoneyTransfer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ABCMoneyTransfer] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ABCMoneyTransfer] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ABCMoneyTransfer', N'ON'
GO
ALTER DATABASE [ABCMoneyTransfer] SET QUERY_STORE = ON
GO
ALTER DATABASE [ABCMoneyTransfer] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ABCMoneyTransfer]
GO
/****** Object:  Table [dbo].[pay_payment]    Script Date: 11/25/2024 9:27:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pay_payment](
	[TransferId] [int] IDENTITY(1,1) NOT NULL,
	[SFirstName] [nchar](10) NULL,
	[SMiddleName] [nchar](10) NULL,
	[SLastName] [nchar](10) NULL,
	[SCountry] [nchar](10) NULL,
	[SAddress] [nchar](10) NULL,
	[RFirstName] [nchar](100) NULL,
	[RMiddleName] [nchar](100) NULL,
	[RLastName] [nchar](100) NULL,
	[RCountry] [nchar](100) NULL,
	[RAddress] [nchar](100) NULL,
	[BankName] [nchar](100) NULL,
	[AccountNumber] [int] NULL,
	[TransferAmount] [decimal](18, 2) NULL,
	[ExchangeRate] [decimal](18, 2) NULL,
	[PayoutAmount] [decimal](18, 2) NULL,
	[PaymentDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sc_user]    Script Date: 11/25/2024 9:27:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sc_user](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](100) NULL,
	[MiddleName] [nchar](100) NULL,
	[LastName] [nchar](100) NULL,
	[Address] [nchar](100) NULL,
	[Email] [nchar](100) NULL,
	[Password] [nchar](100) NULL,
	[Salt] [nchar](100) NULL,
	[EnteredDate] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[pay_payment] ON 

INSERT [dbo].[pay_payment] ([TransferId], [SFirstName], [SMiddleName], [SLastName], [SCountry], [SAddress], [RFirstName], [RMiddleName], [RLastName], [RCountry], [RAddress], [BankName], [AccountNumber], [TransferAmount], [ExchangeRate], [PayoutAmount], [PaymentDate]) VALUES (1, N'Bipesh    ', NULL, N'Maharjan  ', N'Nepal     ', N'Teku      ', N'Bipesh                                                                                              ', NULL, N'Maharjan                                                                                            ', N'Nepal                                                                                               ', N'Teku                                                                                                ', N'asdas                                                                                               ', 134123, CAST(123.00 AS Decimal(18, 2)), CAST(28.39 AS Decimal(18, 2)), CAST(3491.97 AS Decimal(18, 2)), CAST(N'2024-11-25T02:09:58.583' AS DateTime))
INSERT [dbo].[pay_payment] ([TransferId], [SFirstName], [SMiddleName], [SLastName], [SCountry], [SAddress], [RFirstName], [RMiddleName], [RLastName], [RCountry], [RAddress], [BankName], [AccountNumber], [TransferAmount], [ExchangeRate], [PayoutAmount], [PaymentDate]) VALUES (2, N'Bipesh    ', NULL, N'Maharjan  ', N'Nepal     ', N'Teku      ', N'Sushma                                                                                              ', NULL, N'Shrestha                                                                                            ', N'Nepal                                                                                               ', N'Wonde                                                                                               ', N'siddhartha bank                                                                                     ', 32423423, CAST(23423.00 AS Decimal(18, 2)), CAST(28.39 AS Decimal(18, 2)), CAST(664978.97 AS Decimal(18, 2)), CAST(N'2024-11-25T04:04:00.157' AS DateTime))
SET IDENTITY_INSERT [dbo].[pay_payment] OFF
GO
SET IDENTITY_INSERT [dbo].[sc_user] ON 

INSERT [dbo].[sc_user] ([UserId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Password], [Salt], [EnteredDate]) VALUES (1, N'Bipesh                                                                                              ', N'man                                                                                                 ', N'Maharjan                                                                                            ', N'Teku                                                                                                ', N'Bipesh@gmail.com                                                                                    ', N'AQAAAAIAAYagAAAAEOUSOX7GqkDmxg63Okbltg1el6ob3IBiYzFGUNtMdZsqjerY/K+o5gFgn/nryxHQ0Q==                ', NULL, CAST(N'2024-11-24T23:05:12.983' AS DateTime))
INSERT [dbo].[sc_user] ([UserId], [FirstName], [MiddleName], [LastName], [Address], [Email], [Password], [Salt], [EnteredDate]) VALUES (2, N'Sushma                                                                                              ', N'.                                                                                                   ', N'Shrestha                                                                                            ', N'Wonde                                                                                               ', N'Sushma@gmail.com                                                                                    ', N'AQAAAAIAAYagAAAAEAZylgX1zVF0eAj5LtF9AKo4GbrTuU6VWbiTzGGTCF9LRK4jDpRa4aOfr4kLOC+0gg==                ', NULL, CAST(N'2024-11-25T04:02:40.123' AS DateTime))
SET IDENTITY_INSERT [dbo].[sc_user] OFF
GO
USE [master]
GO
ALTER DATABASE [ABCMoneyTransfer] SET  READ_WRITE 
GO
