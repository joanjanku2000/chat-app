USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[user_message]    Script Date: 12/30/2021 12:32:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_message](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[sender_id] [bigint] NOT NULL,
	[receiver_id] [bigint] NOT NULL,
	[message] [text] NOT NULL,
	[attachment] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


alter table dbo.user_message
add received bit;

alter table dbo.user_message
add seen bit;
