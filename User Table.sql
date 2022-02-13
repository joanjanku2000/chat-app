USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[userr]    Script Date: 2/13/2022 5:03:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[userr](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[namee] [nchar](100) NULL,
	[last_name] [nchar](100) NULL,
	[phone_number] [nchar](20) NOT NULL,
	[passwordd] [nchar](255) NULL,
	[online] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


