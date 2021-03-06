USE [master]
GO
/****** Object:  Database [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF]    Script Date: 16.06.2022 13:18:37 ******/
CREATE DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoragerExampleDb', FILENAME = N'C:\Users\Artur\Documents\StoragerExampleDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StoragerExampleDb_log', FILENAME = N'C:\Users\Artur\Documents\StoragerExampleDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET ARITHABORT OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET  ENABLE_BROKER 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET  MULTI_USER 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET QUERY_STORE = OFF
GO
USE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF]
GO
/****** Object:  UserDefinedTableType [dbo].[STOCKS_TEMP]    Script Date: 16.06.2022 13:18:37 ******/
CREATE TYPE [dbo].[STOCKS_TEMP] AS TABLE(
	[Id] [int] NOT NULL,
	[PricePerUnit] [money] NOT NULL,
	[Amount] [int] NOT NULL,
	[CurrentAmount] [int] NOT NULL,
	[Id_Product] [bigint] NOT NULL,
	[Id_StorageRack] [int] NOT NULL,
	UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[ACCOUNTS]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNTS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](320) NULL,
	[Login] [varchar](20) NOT NULL,
	[HashedPassword] [varchar](64) NOT NULL,
	[Id_privilege] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONTRACTORS]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTRACTORS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCUMENT_PZ_STOCKS]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCUMENT_PZ_STOCKS](
	[Id_DocumentPz] [int] NOT NULL,
	[Id_Stock] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCUMENT_TYPES]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCUMENT_TYPES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](30) NOT NULL,
	[ShortName] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCUMENT_WZ_PRODUCTS]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCUMENT_WZ_PRODUCTS](
	[Id_DocumentWz] [int] NOT NULL,
	[Id_Product] [int] NOT NULL,
	[Amount] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCUMENTS_PZ]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCUMENTS_PZ](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNumber] [varchar](50) NOT NULL,
	[DateOfSigning] [datetime] NOT NULL,
	[InvoiceNumber] [varchar](50) NOT NULL,
	[Id_ApprovedBy] [int] NOT NULL,
	[Id_Supplier] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCUMENTS_WZ]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCUMENTS_WZ](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNumber] [varchar](50) NOT NULL,
	[DateOfSigning] [datetime] NOT NULL,
	[InvoiceNumber] [varchar](50) NOT NULL,
	[Id_ApprovedBy] [int] NOT NULL,
	[Id_Recipent] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRIVILEGE]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRIVILEGE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTS]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTS](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](150) NULL,
	[Barcode] [varchar](25) NOT NULL,
	[Id_UnitOfMeasure] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STOCKS]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STOCKS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PricePerUnit] [money] NOT NULL,
	[Amount] [int] NOT NULL,
	[CurrentAmount] [int] NOT NULL,
	[Id_Product] [bigint] NOT NULL,
	[Id_StorageRack] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STORAGE_RACKS]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STORAGE_RACKS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UNITS_OF_MEASURE]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UNITS_OF_MEASURE](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[UnitName] [varchar](20) NOT NULL,
	[ShortName] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ACCOUNTS] ON 

INSERT [dbo].[ACCOUNTS] ([Id], [Email], [Login], [HashedPassword], [Id_privilege]) VALUES (9, N'user1@storager.com', N'user1', N'73fc9d011fe7abc7bdff3f6ab13883b6a3a4bd1d41c7595c34326867b8fea7fd', 3)
INSERT [dbo].[ACCOUNTS] ([Id], [Email], [Login], [HashedPassword], [Id_privilege]) VALUES (15, N'admin@admin.com', N'admin', N'7523c62abdb7628c5a9dad8f97d8d8c5c040ede36535e531a8a3748b6cae7e00', 1)
SET IDENTITY_INSERT [dbo].[ACCOUNTS] OFF
GO
SET IDENTITY_INSERT [dbo].[CONTRACTORS] ON 

INSERT [dbo].[CONTRACTORS] ([Id], [Name], [Email], [Address]) VALUES (1, N'Uniwerstal', N'uniwerstal@gmail.com', N'Białystok, Szkolna')
INSERT [dbo].[CONTRACTORS] ([Id], [Name], [Email], [Address]) VALUES (2, N'Sorfay', N'es.nowak@onet.pl', N'Gdzieś, Daleko')
SET IDENTITY_INSERT [dbo].[CONTRACTORS] OFF
GO
INSERT [dbo].[DOCUMENT_PZ_STOCKS] ([Id_DocumentPz], [Id_Stock]) VALUES (12, 71)
INSERT [dbo].[DOCUMENT_PZ_STOCKS] ([Id_DocumentPz], [Id_Stock]) VALUES (12, 72)
INSERT [dbo].[DOCUMENT_PZ_STOCKS] ([Id_DocumentPz], [Id_Stock]) VALUES (13, 73)
INSERT [dbo].[DOCUMENT_PZ_STOCKS] ([Id_DocumentPz], [Id_Stock]) VALUES (13, 74)
INSERT [dbo].[DOCUMENT_PZ_STOCKS] ([Id_DocumentPz], [Id_Stock]) VALUES (15, 76)
INSERT [dbo].[DOCUMENT_PZ_STOCKS] ([Id_DocumentPz], [Id_Stock]) VALUES (15, 77)
GO
SET IDENTITY_INSERT [dbo].[DOCUMENT_TYPES] ON 

INSERT [dbo].[DOCUMENT_TYPES] ([Id], [FullName], [ShortName]) VALUES (1, N'Przyjecie zewnetrzne', N'PZ')
INSERT [dbo].[DOCUMENT_TYPES] ([Id], [FullName], [ShortName]) VALUES (3, N'Wydanie na zewnatrz', N'WZ')
SET IDENTITY_INSERT [dbo].[DOCUMENT_TYPES] OFF
GO
INSERT [dbo].[DOCUMENT_WZ_PRODUCTS] ([Id_DocumentWz], [Id_Product], [Amount]) VALUES (22, 36, 123)
GO
SET IDENTITY_INSERT [dbo].[DOCUMENTS_PZ] ON 

INSERT [dbo].[DOCUMENTS_PZ] ([Id], [DocumentNumber], [DateOfSigning], [InvoiceNumber], [Id_ApprovedBy], [Id_Supplier]) VALUES (12, N'PZ12', CAST(N'2022-06-04T16:29:49.660' AS DateTime), N'2323', 15, 1)
INSERT [dbo].[DOCUMENTS_PZ] ([Id], [DocumentNumber], [DateOfSigning], [InvoiceNumber], [Id_ApprovedBy], [Id_Supplier]) VALUES (13, N'PZ13', CAST(N'2022-06-05T14:19:38.770' AS DateTime), N'1212', 15, 1)
INSERT [dbo].[DOCUMENTS_PZ] ([Id], [DocumentNumber], [DateOfSigning], [InvoiceNumber], [Id_ApprovedBy], [Id_Supplier]) VALUES (14, N'PZ14', CAST(N'2022-06-05T14:23:29.310' AS DateTime), N'12', 15, 2)
INSERT [dbo].[DOCUMENTS_PZ] ([Id], [DocumentNumber], [DateOfSigning], [InvoiceNumber], [Id_ApprovedBy], [Id_Supplier]) VALUES (15, N'PZ15', CAST(N'2022-06-05T14:23:35.883' AS DateTime), N'12', 15, 2)
SET IDENTITY_INSERT [dbo].[DOCUMENTS_PZ] OFF
GO
SET IDENTITY_INSERT [dbo].[DOCUMENTS_WZ] ON 

INSERT [dbo].[DOCUMENTS_WZ] ([Id], [DocumentNumber], [DateOfSigning], [InvoiceNumber], [Id_ApprovedBy], [Id_Recipent]) VALUES (22, N'WZ22', CAST(N'2022-06-15T20:54:18.457' AS DateTime), N'12324', 15, 1)
SET IDENTITY_INSERT [dbo].[DOCUMENTS_WZ] OFF
GO
SET IDENTITY_INSERT [dbo].[PRIVILEGE] ON 

INSERT [dbo].[PRIVILEGE] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[PRIVILEGE] ([Id], [Name]) VALUES (2, N'Mod')
INSERT [dbo].[PRIVILEGE] ([Id], [Name]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[PRIVILEGE] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTS] ON 

INSERT [dbo].[PRODUCTS] ([Id], [Name], [Description], [Barcode], [Id_UnitOfMeasure]) VALUES (34, N'Wylewka betonowa Weber B50 25 ', N'Do mniejszych lub wiekszych prac betoniarskich swietnie sprawdzi sie bardzo wytrzymala wylewka betonowa Weber B50. Mieszanke charakteryzuja doskonale ', N'392194', 1)
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Description], [Barcode], [Id_UnitOfMeasure]) VALUES (35, N'Drabina 4 stopniowa MacAlliste', N'Drabina 4 stopniowa MacAllister jest produktem, którego mozesz potrzebowac w domu i ogrodzie. Wykonana zostala z dobrego stopu aluminium, co wplywa na', N'532369', 3)
INSERT [dbo].[PRODUCTS] ([Id], [Name], [Description], [Barcode], [Id_UnitOfMeasure]) VALUES (36, N'Farba Dulux Sciany i Sufity ne', N'Farba Dulux Sciany i Sufity neutralna biel wyróznia sie gesta i kremowa receptura, co znacznie ulatwia malowanie. Zaleta tego produktu jest doskonala ', N'813922', 2)
SET IDENTITY_INSERT [dbo].[PRODUCTS] OFF
GO
SET IDENTITY_INSERT [dbo].[STOCKS] ON 

INSERT [dbo].[STOCKS] ([Id], [PricePerUnit], [Amount], [CurrentAmount], [Id_Product], [Id_StorageRack]) VALUES (71, 44.0000, 213, 90, 36, 2)
INSERT [dbo].[STOCKS] ([Id], [PricePerUnit], [Amount], [CurrentAmount], [Id_Product], [Id_StorageRack]) VALUES (72, 54.0000, 123, 123, 35, 5)
INSERT [dbo].[STOCKS] ([Id], [PricePerUnit], [Amount], [CurrentAmount], [Id_Product], [Id_StorageRack]) VALUES (73, 44.0000, 23, 23, 35, 2)
INSERT [dbo].[STOCKS] ([Id], [PricePerUnit], [Amount], [CurrentAmount], [Id_Product], [Id_StorageRack]) VALUES (74, 45.0000, 12, 12, 34, 1)
INSERT [dbo].[STOCKS] ([Id], [PricePerUnit], [Amount], [CurrentAmount], [Id_Product], [Id_StorageRack]) VALUES (75, 43.4800, 34, 34, 34, 3)
INSERT [dbo].[STOCKS] ([Id], [PricePerUnit], [Amount], [CurrentAmount], [Id_Product], [Id_StorageRack]) VALUES (76, 43.4800, 34, 34, 34, 3)
INSERT [dbo].[STOCKS] ([Id], [PricePerUnit], [Amount], [CurrentAmount], [Id_Product], [Id_StorageRack]) VALUES (77, 0.3400, 123, 123, 35, 5)
SET IDENTITY_INSERT [dbo].[STOCKS] OFF
GO
SET IDENTITY_INSERT [dbo].[STORAGE_RACKS] ON 

INSERT [dbo].[STORAGE_RACKS] ([Id], [Code]) VALUES (4, N'123')
INSERT [dbo].[STORAGE_RACKS] ([Id], [Code]) VALUES (1, N'1A')
INSERT [dbo].[STORAGE_RACKS] ([Id], [Code]) VALUES (3, N'34B')
INSERT [dbo].[STORAGE_RACKS] ([Id], [Code]) VALUES (2, N'5F')
INSERT [dbo].[STORAGE_RACKS] ([Id], [Code]) VALUES (5, N'7A')
INSERT [dbo].[STORAGE_RACKS] ([Id], [Code]) VALUES (8, N'asd3423')
INSERT [dbo].[STORAGE_RACKS] ([Id], [Code]) VALUES (6, N'df#')
INSERT [dbo].[STORAGE_RACKS] ([Id], [Code]) VALUES (7, N'sdfsdf34')
SET IDENTITY_INSERT [dbo].[STORAGE_RACKS] OFF
GO
SET IDENTITY_INSERT [dbo].[UNITS_OF_MEASURE] ON 

INSERT [dbo].[UNITS_OF_MEASURE] ([Id], [UnitName], [ShortName]) VALUES (1, N'Kilograms', N'kg')
INSERT [dbo].[UNITS_OF_MEASURE] ([Id], [UnitName], [ShortName]) VALUES (2, N'Liters', N'l')
INSERT [dbo].[UNITS_OF_MEASURE] ([Id], [UnitName], [ShortName]) VALUES (3, N'SingleItem', N'item')
INSERT [dbo].[UNITS_OF_MEASURE] ([Id], [UnitName], [ShortName]) VALUES (4, N'Meters', N'm')
SET IDENTITY_INSERT [dbo].[UNITS_OF_MEASURE] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ACCOUNTS__5E55825B74435909]    Script Date: 16.06.2022 13:18:37 ******/
ALTER TABLE [dbo].[ACCOUNTS] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ACCOUNTS__A9D1053446256258]    Script Date: 16.06.2022 13:18:37 ******/
ALTER TABLE [dbo].[ACCOUNTS] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PRODUCTS__737584F6F4AE73CB]    Script Date: 16.06.2022 13:18:37 ******/
ALTER TABLE [dbo].[PRODUCTS] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__STORAGE___A25C5AA726E62F47]    Script Date: 16.06.2022 13:18:37 ******/
ALTER TABLE [dbo].[STORAGE_RACKS] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DOCUMENT_PZ_STOCKS]  WITH CHECK ADD FOREIGN KEY([Id_DocumentPz])
REFERENCES [dbo].[DOCUMENTS_PZ] ([Id])
GO
ALTER TABLE [dbo].[DOCUMENT_PZ_STOCKS]  WITH CHECK ADD FOREIGN KEY([Id_Stock])
REFERENCES [dbo].[STOCKS] ([Id])
GO
ALTER TABLE [dbo].[DOCUMENTS_PZ]  WITH CHECK ADD FOREIGN KEY([Id_ApprovedBy])
REFERENCES [dbo].[ACCOUNTS] ([Id])
GO
ALTER TABLE [dbo].[DOCUMENTS_PZ]  WITH CHECK ADD FOREIGN KEY([Id_Supplier])
REFERENCES [dbo].[CONTRACTORS] ([Id])
GO
ALTER TABLE [dbo].[DOCUMENTS_WZ]  WITH CHECK ADD FOREIGN KEY([Id_ApprovedBy])
REFERENCES [dbo].[ACCOUNTS] ([Id])
GO
ALTER TABLE [dbo].[DOCUMENTS_WZ]  WITH CHECK ADD FOREIGN KEY([Id_Recipent])
REFERENCES [dbo].[CONTRACTORS] ([Id])
GO
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD FOREIGN KEY([Id_UnitOfMeasure])
REFERENCES [dbo].[UNITS_OF_MEASURE] ([Id])
GO
ALTER TABLE [dbo].[STOCKS]  WITH CHECK ADD FOREIGN KEY([Id_Product])
REFERENCES [dbo].[PRODUCTS] ([Id])
GO
ALTER TABLE [dbo].[STOCKS]  WITH CHECK ADD FOREIGN KEY([Id_StorageRack])
REFERENCES [dbo].[STORAGE_RACKS] ([Id])
GO
ALTER TABLE [dbo].[STOCKS]  WITH CHECK ADD  CONSTRAINT [CHK_amount_correctness] CHECK  (([CurrentAmount]<=[Amount]))
GO
ALTER TABLE [dbo].[STOCKS] CHECK CONSTRAINT [CHK_amount_correctness]
GO
/****** Object:  StoredProcedure [dbo].[spCountProductAmountLeft]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCountProductAmountLeft]
	@id_product int
AS
	DECLARE @result int = 0;

	SET @result = (SELECT COUNT(CurrentAmount) FROM STOCKS WHERE Id_Product = @id_product);

RETURN @result
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAllDocumentsData]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteAllDocumentsData]

AS
	DELETE FROM [DOCUMENT_PZ_STOCKS];
	DELETE FROM [DOCUMENTS_PZ];

	DELETE FROM [DOCUMENT_WZ_PRODUCTS];
	DELETE FROM [DOCUMENTS_WZ];
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAllProductsData]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteAllProductsData]
AS
	DELETE FROM PRODUCTS
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAllStocksData]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteAllStocksData]
AS
	DELETE FROM STOCKS;
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertContractor]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertContractor]
	@name NVARCHAR(50),
	@email NVARCHAR(50),
	@address NVARCHAR(50)
AS
	INSERT INTO CONTRACTORS(Name, Email, Address)
	VALUES(@name, @email, @address)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertDocument]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDocument]
	@id_document INT OUTPUT,
	@supplier VARCHAR(50),
	@invoice_number VARCHAR(50),
	@date_of_signing DATETIME,
	@id_document_type INT
AS
	INSERT INTO [DOCUMENTS](
		Supplier,
		DateOfSigning,
		InvoiceNumber,
		Id_DocumentType
	) 
	VALUES(
		@supplier,
		@date_of_signing,
		@invoice_number,
		@id_document_type
	);


	SET @id_document = IDENT_CURRENT('DOCUMENTS');
	

RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertDocumentPz]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDocumentPz]
	@id_document INT OUTPUT,
	@invoice_number VARCHAR(50),
	@date_of_signing DATETIME,
	@id_approved_by INT,
	@id_supplier INT
AS
	INSERT INTO [DOCUMENTS_PZ](
		DocumentNumber,
		DateOfSigning,
		InvoiceNumber,
		Id_ApprovedBy,
		Id_Supplier
	) 
	VALUES(
		'NONE',
		@date_of_signing,
		@invoice_number,
		@id_approved_by,
		@id_supplier
	);


	SET @id_document = IDENT_CURRENT('DOCUMENTS_PZ');
	
	UPDATE [DOCUMENTS_PZ]
	SET DocumentNumber = CONCAT('PZ', CONVERT(VARCHAR(48), @id_document))
	WHERE Id = @id_document;

RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertDocumentPzStocks]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDocumentPzStocks]
	@id_document int,
	@id_stock int
AS
	INSERT INTO DOCUMENT_PZ_STOCKS(Id_DocumentPz, Id_Stock)
	VALUES(@id_document, @id_stock);
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertDocumentStocks]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDocumentStocks]
	@id_document int,
	@id_stock int
AS
	INSERT INTO DOCUMENT_STOCKS(Id_Document, Id_Stock)
	VALUES(@id_document, @id_stock);
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertDocumentWz]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDocumentWz]
	@id_document INT OUTPUT,
	@invoice_number VARCHAR(50),
	@date_of_signing DATETIME,
	@id_approved_by INT,
	@id_recipent INT
AS
	INSERT INTO [DOCUMENTS_WZ](
		DocumentNumber,
		DateOfSigning,
		InvoiceNumber,
		Id_ApprovedBy,
		Id_Recipent
	) 
	VALUES(
		'NONE',
		@date_of_signing,
		@invoice_number,
		@id_approved_by,
		@id_recipent
	);


	SET @id_document = IDENT_CURRENT('DOCUMENTS_WZ');
	
	UPDATE [DOCUMENTS_WZ]
	SET DocumentNumber = CONCAT('WZ', CONVERT(VARCHAR(48), @id_document))
	WHERE Id = @id_document;

RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertDocumentWzProduct]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertDocumentWzProduct]
	@id_document int,
	@id_product int,
	@amount int
AS
	DECLARE @amount_left int;
	SET @amount_left = (SELECT COUNT(CurrentAmount) FROM STOCKS WHERE Id_Product = @id_product);

	INSERT INTO DOCUMENT_WZ_PRODUCTS(Id_DocumentWz, Id_Product, Amount)
	VALUES(@id_document, @id_product, @amount);
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertProduct]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertProduct]
	@name VARCHAR(30),
	@description VARCHAR(150),
	@barcode VARCHAR(25),
	@id_unit_of_measure TINYINT
AS
	INSERT INTO PRODUCTS(Name, Description, Barcode, Id_UnitOfMeasure)
	VALUES(@name, @description, @barcode, @id_unit_of_measure)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertStock]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertStock]
	@id_stock INT OUTPUT,
	@price_per_unit MONEY,
	@amount INT,
	@current_amount INT,
	@id_product INT,
	@id_storage_rack INT
AS
	INSERT INTO STOCKS(
		PricePerUnit,
		Amount, 
		CurrentAmount,
		Id_Product,
		Id_StorageRack
	)
	VALUES(
		@price_per_unit,
		@amount,
		@current_amount,
		@id_product,
		@id_storage_rack
	)

	SET @id_stock = IDENT_CURRENT('STOCKS');
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[spInsertStorageRack]    Script Date: 16.06.2022 13:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertStorageRack]
	@code VARCHAR(10)
AS
	INSERT INTO STORAGE_RACKS(Code) VALUES (@code)
RETURN 0
GO
USE [master]
GO
ALTER DATABASE [C:\USERS\ARTUR\DOCUMENTS\STORAGEREXAMPLEDB.MDF] SET  READ_WRITE 
GO
