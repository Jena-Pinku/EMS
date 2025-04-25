USE [master]
GO

/****** Object:  Database [EMS]    Script Date: 25-04-2025 08:40:39 ******/
CREATE DATABASE [EMS]


USE [EMS]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 25-04-2025 08:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Gender] [char](1) NULL,
	[DOB] [date] NULL,
	[EmailId] [varchar](30) NULL,
	[ContactNo] [varchar](10) NULL,
	[Address] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([EmpId], [FirstName], [LastName], [Gender], [DOB], [EmailId], [ContactNo], [Address]) VALUES (1, N'PINKU', N'JENA', N'M', CAST(N'1996-01-03' AS Date), N'pankajjena1994@gmail.com', N'8100094048', N'Sodepore,Kolkata')
GO
INSERT [dbo].[Employees] ([EmpId], [FirstName], [LastName], [Gender], [DOB], [EmailId], [ContactNo], [Address]) VALUES (2, N'RAJEEV', N'KUMAR', N'M', CAST(N'1994-07-12' AS Date), N'rajeev.kumar@gmail.com', N'8100094049', N'Salt Lake, Kolkata')
GO
INSERT [dbo].[Employees] ([EmpId], [FirstName], [LastName], [Gender], [DOB], [EmailId], [ContactNo], [Address]) VALUES (3, N'PRIYA', N'SINGH', N'F', CAST(N'1995-05-23' AS Date), N'priya.singh@gmail.com', N'8100094050', N'Howrah, Kolkata')
GO
INSERT [dbo].[Employees] ([EmpId], [FirstName], [LastName], [Gender], [DOB], [EmailId], [ContactNo], [Address]) VALUES (4, N'ANITA', N'GUPTA', N'F', CAST(N'1993-11-04' AS Date), N'anita.gupta@gmail.com', N'8100094051', N'Dum Dum, Kolkata')
GO
INSERT [dbo].[Employees] ([EmpId], [FirstName], [LastName], [Gender], [DOB], [EmailId], [ContactNo], [Address]) VALUES (5, N'SUSHANT', N'MITRA', N'M', CAST(N'1992-09-15' AS Date), N'sushant.mitra@gmail.com', N'8100094052', N'Bally, Kolkata')
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
