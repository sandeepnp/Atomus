USE [Atomus]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 26/11/2017 11:16:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Company] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[City] [nvarchar](200) NULL,
	[County] [nvarchar](200) NULL,
	[Postcode] [nvarchar](10) NOT NULL,
	[Phone1] [nvarchar](20) NULL,
	[Phone2] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Website] [nvarchar](500) NULL,
	[Created] [smalldatetime] NOT NULL,
	[Updated] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Updated]  DEFAULT (getdate()) FOR [Updated]
GO


