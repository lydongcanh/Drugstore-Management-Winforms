USE [master]
GO
/****** Object:  Database [LTHSKFinalDb]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE DATABASE [LTHSKFinalDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LTHSKFinalDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LTHSKFinalDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LTHSKFinalDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LTHSKFinalDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Vietnamese_CI_AS
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LTHSKFinalDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LTHSKFinalDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LTHSKFinalDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LTHSKFinalDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LTHSKFinalDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LTHSKFinalDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LTHSKFinalDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LTHSKFinalDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LTHSKFinalDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LTHSKFinalDb] SET  MULTI_USER 
GO
ALTER DATABASE [LTHSKFinalDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LTHSKFinalDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LTHSKFinalDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LTHSKFinalDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LTHSKFinalDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LTHSKFinalDb] SET QUERY_STORE = OFF
GO
USE [LTHSKFinalDb]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[FullName] [nvarchar](50) COLLATE Vietnamese_CI_AS NOT NULL,
	[PhoneNumber] [nvarchar](10) COLLATE Vietnamese_CI_AS NOT NULL,
	[Gender] [nvarchar](10) COLLATE Vietnamese_CI_AS NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Username] [nvarchar](50) COLLATE Vietnamese_CI_AS NOT NULL,
	[Password] [nvarchar](50) COLLATE Vietnamese_CI_AS NOT NULL,
	[Type] [nvarchar](15) COLLATE Vietnamese_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicineDetails]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicineDetails](
	[Id] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [real] NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[MedicineId] [nvarchar](128) COLLATE Vietnamese_CI_AS NULL,
	[MedicineSupplierId] [nvarchar](128) COLLATE Vietnamese_CI_AS NULL,
 CONSTRAINT [PK_dbo.MedicineDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicines]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[Id] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[Name] [nvarchar](50) COLLATE Vietnamese_CI_AS NOT NULL,
	[SellPrice] [real] NOT NULL,
 CONSTRAINT [PK_dbo.Medicines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicineSuppliers]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicineSuppliers](
	[Id] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[Name] [nvarchar](50) COLLATE Vietnamese_CI_AS NOT NULL,
	[PhoneNumber] [nvarchar](10) COLLATE Vietnamese_CI_AS NOT NULL,
 CONSTRAINT [PK_dbo.MedicineSuppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientPrescriptionMedicines]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientPrescriptionMedicines](
	[MedicineId] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[PatientPrescriptionId] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[OneDayQuantity] [int] NOT NULL,
	[Description] [nvarchar](100) COLLATE Vietnamese_CI_AS NULL,
 CONSTRAINT [PK_dbo.PatientPrescriptionMedicines] PRIMARY KEY CLUSTERED 
(
	[MedicineId] ASC,
	[PatientPrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientPrescriptions]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientPrescriptions](
	[Id] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[DiseaseName] [nvarchar](50) COLLATE Vietnamese_CI_AS NOT NULL,
	[PatientId] [nvarchar](128) COLLATE Vietnamese_CI_AS NULL,
 CONSTRAINT [PK_dbo.PatientPrescriptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[FullName] [nvarchar](50) COLLATE Vietnamese_CI_AS NOT NULL,
	[PhoneNumber] [nvarchar](10) COLLATE Vietnamese_CI_AS NOT NULL,
	[Gender] [nvarchar](10) COLLATE Vietnamese_CI_AS NOT NULL,
	[BirthDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellReceiptDetails]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellReceiptDetails](
	[Id] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[Quantity] [int] NOT NULL,
	[SellReceiptId] [nvarchar](128) COLLATE Vietnamese_CI_AS NULL,
	[MedicineId] [nvarchar](128) COLLATE Vietnamese_CI_AS NULL,
 CONSTRAINT [PK_dbo.SellReceiptDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellReceipts]    Script Date: 6/20/20 5:21:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellReceipts](
	[Id] [nvarchar](128) COLLATE Vietnamese_CI_AS NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[PatientId] [nvarchar](128) COLLATE Vietnamese_CI_AS NULL,
	[EmployeeId] [nvarchar](128) COLLATE Vietnamese_CI_AS NULL,
 CONSTRAINT [PK_dbo.SellReceipts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employees] ([Id], [FullName], [PhoneNumber], [Gender], [BirthDate], [Username], [Password], [Type]) VALUES (N'NV1', N'Lý Đông Cảnh', N'0123456781', N'Nam', CAST(N'1998-02-26T00:00:00.000' AS DateTime), N'lydongcanh@gmail.com', N'abcd1234', N'Quản lý')
INSERT [dbo].[Employees] ([Id], [FullName], [PhoneNumber], [Gender], [BirthDate], [Username], [Password], [Type]) VALUES (N'NV2', N'Trần Thị B', N'0123412345', N'Nữ', CAST(N'1999-06-12T05:11:37.000' AS DateTime), N'tranthib@gmail.com', N'abcd1234', N'Nhân viên')
GO
INSERT [dbo].[MedicineDetails] ([Id], [Quantity], [UnitPrice], [AddedDate], [ExpirationDate], [MedicineId], [MedicineSupplierId]) VALUES (N'CTT1', 30, 4000, CAST(N'2020-06-20T01:11:24.823' AS DateTime), CAST(N'2020-07-20T01:11:24.000' AS DateTime), N'T1', N'NCC1')
INSERT [dbo].[MedicineDetails] ([Id], [Quantity], [UnitPrice], [AddedDate], [ExpirationDate], [MedicineId], [MedicineSupplierId]) VALUES (N'CTT2', 85, 3800, CAST(N'2020-06-20T01:11:42.327' AS DateTime), CAST(N'2020-06-27T01:11:42.000' AS DateTime), N'T1', N'NCC2')
INSERT [dbo].[MedicineDetails] ([Id], [Quantity], [UnitPrice], [AddedDate], [ExpirationDate], [MedicineId], [MedicineSupplierId]) VALUES (N'CTT3', 75, 10000, CAST(N'2020-06-20T01:21:57.613' AS DateTime), CAST(N'2020-06-28T01:21:57.000' AS DateTime), N'T2', N'NCC1')
INSERT [dbo].[MedicineDetails] ([Id], [Quantity], [UnitPrice], [AddedDate], [ExpirationDate], [MedicineId], [MedicineSupplierId]) VALUES (N'CTT4', 80, 9500, CAST(N'2020-06-20T01:22:11.740' AS DateTime), CAST(N'2020-06-28T01:22:11.000' AS DateTime), N'T2', N'NCC1')
GO
INSERT [dbo].[Medicines] ([Id], [Name], [SellPrice]) VALUES (N'T1', N'Thuốc A', 5500)
INSERT [dbo].[Medicines] ([Id], [Name], [SellPrice]) VALUES (N'T2', N'Thuốc B', 11500)
GO
INSERT [dbo].[MedicineSuppliers] ([Id], [Name], [PhoneNumber]) VALUES (N'NCC1', N'Nhà cung cấp A', N'0123444555')
INSERT [dbo].[MedicineSuppliers] ([Id], [Name], [PhoneNumber]) VALUES (N'NCC2', N'Nhà cung cấp B', N'0123466666')
GO
INSERT [dbo].[Patients] ([Id], [FullName], [PhoneNumber], [Gender], [BirthDate]) VALUES (N'BN1', N'Bệnh nhân A', N'0123456789', N'Nam', CAST(N'1990-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Patients] ([Id], [FullName], [PhoneNumber], [Gender], [BirthDate]) VALUES (N'BN2', N'Bệnh nhân B', N'0123456788', N'Nam', CAST(N'1991-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Patients] ([Id], [FullName], [PhoneNumber], [Gender], [BirthDate]) VALUES (N'BN3', N'Bệnh nhân C', N'0123456780', N'Nữ', CAST(N'1992-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Patients] ([Id], [FullName], [PhoneNumber], [Gender], [BirthDate]) VALUES (N'BN4', N'Bệnh nhân D', N'0123456777', N'Nam', CAST(N'2003-11-19T22:55:56.000' AS DateTime))
INSERT [dbo].[Patients] ([Id], [FullName], [PhoneNumber], [Gender], [BirthDate]) VALUES (N'BN5', N'Bệnh nhân E', N'0123456765', N'Nữ', CAST(N'2009-05-19T22:56:39.000' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MedicineId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_MedicineId] ON [dbo].[MedicineDetails]
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MedicineSupplierId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_MedicineSupplierId] ON [dbo].[MedicineDetails]
(
	[MedicineSupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MedicineId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_MedicineId] ON [dbo].[PatientPrescriptionMedicines]
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PatientPrescriptionId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_PatientPrescriptionId] ON [dbo].[PatientPrescriptionMedicines]
(
	[PatientPrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PatientId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[PatientPrescriptions]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_MedicineId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_MedicineId] ON [dbo].[SellReceiptDetails]
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SellReceiptId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_SellReceiptId] ON [dbo].[SellReceiptDetails]
(
	[SellReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_EmployeeId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeId] ON [dbo].[SellReceipts]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PatientId]    Script Date: 6/20/20 5:21:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[SellReceipts]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MedicineDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedicineDetails_dbo.Medicines_MedicineId] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicines] ([Id])
GO
ALTER TABLE [dbo].[MedicineDetails] CHECK CONSTRAINT [FK_dbo.MedicineDetails_dbo.Medicines_MedicineId]
GO
ALTER TABLE [dbo].[MedicineDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedicineDetails_dbo.MedicineSuppliers_MedicineSupplierId] FOREIGN KEY([MedicineSupplierId])
REFERENCES [dbo].[MedicineSuppliers] ([Id])
GO
ALTER TABLE [dbo].[MedicineDetails] CHECK CONSTRAINT [FK_dbo.MedicineDetails_dbo.MedicineSuppliers_MedicineSupplierId]
GO
ALTER TABLE [dbo].[PatientPrescriptionMedicines]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PatientPrescriptionMedicines_dbo.Medicines_MedicineId] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicines] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientPrescriptionMedicines] CHECK CONSTRAINT [FK_dbo.PatientPrescriptionMedicines_dbo.Medicines_MedicineId]
GO
ALTER TABLE [dbo].[PatientPrescriptionMedicines]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PatientPrescriptionMedicines_dbo.PatientPrescriptions_PatientPrescriptionId] FOREIGN KEY([PatientPrescriptionId])
REFERENCES [dbo].[PatientPrescriptions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientPrescriptionMedicines] CHECK CONSTRAINT [FK_dbo.PatientPrescriptionMedicines_dbo.PatientPrescriptions_PatientPrescriptionId]
GO
ALTER TABLE [dbo].[PatientPrescriptions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PatientPrescriptions_dbo.Patients_Patient_Id] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[PatientPrescriptions] CHECK CONSTRAINT [FK_dbo.PatientPrescriptions_dbo.Patients_Patient_Id]
GO
ALTER TABLE [dbo].[SellReceiptDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SellReceiptDetails_dbo.Medicines_MedicineId] FOREIGN KEY([MedicineId])
REFERENCES [dbo].[Medicines] ([Id])
GO
ALTER TABLE [dbo].[SellReceiptDetails] CHECK CONSTRAINT [FK_dbo.SellReceiptDetails_dbo.Medicines_MedicineId]
GO
ALTER TABLE [dbo].[SellReceiptDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SellReceiptDetails_dbo.SellReceipts_SellReceiptId] FOREIGN KEY([SellReceiptId])
REFERENCES [dbo].[SellReceipts] ([Id])
GO
ALTER TABLE [dbo].[SellReceiptDetails] CHECK CONSTRAINT [FK_dbo.SellReceiptDetails_dbo.SellReceipts_SellReceiptId]
GO
ALTER TABLE [dbo].[SellReceipts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SellReceipts_dbo.Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[SellReceipts] CHECK CONSTRAINT [FK_dbo.SellReceipts_dbo.Employees_EmployeeId]
GO
ALTER TABLE [dbo].[SellReceipts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SellReceipts_dbo.Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[SellReceipts] CHECK CONSTRAINT [FK_dbo.SellReceipts_dbo.Patients_PatientId]
GO
USE [master]
GO
ALTER DATABASE [LTHSKFinalDb] SET  READ_WRITE 
GO
