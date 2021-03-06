USE [CardCostDb]
GO
/****** Object:  Table [dbo].[AccessUser]    Script Date: 8/2/2021 14:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[PasswordHash] [binary](64) NULL,
	[PasswordSalt] [binary](128) NULL,
	[Token] [nvarchar](200) NULL,
 CONSTRAINT [PK_AccessUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CCMatrix]    Script Date: 8/2/2021 14:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CCMatrix](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](10) NULL,
	[Cost] [real] NULL,
 CONSTRAINT [PK_CCMatrix] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IINList]    Script Date: 8/2/2021 14:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IINList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IIN] [nvarchar](6) NULL,
	[Country] [nvarchar](10) NULL,
 CONSTRAINT [PK_IINList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CCMatrix] ON 

INSERT [dbo].[CCMatrix] ([ID], [Country], [Cost]) VALUES (1, N'US', 5)
INSERT [dbo].[CCMatrix] ([ID], [Country], [Cost]) VALUES (2, N'GR', 15)
INSERT [dbo].[CCMatrix] ([ID], [Country], [Cost]) VALUES (3, N'OTHERS', 10)
SET IDENTITY_INSERT [dbo].[CCMatrix] OFF
GO
