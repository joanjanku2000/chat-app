USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[user]    Script Date: 12/30/2021 12:31:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NULL,
	[last_name] [nchar](100) NULL,
	[phone_number] [nchar](20) NOT NULL
) ON [PRIMARY]
GO

