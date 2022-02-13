USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[user_message]    Script Date: 2/13/2022 5:03:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_message](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[sender_id] [bigint] NOT NULL,
	[receiver_id] [bigint] NOT NULL,
	[message] [text] NOT NULL,
	[attachment] [text] NULL,
	[received] [bit] NULL,
	[seen] [bit] NULL,
	[message_encryption_for_sender] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[user_message]  WITH CHECK ADD  CONSTRAINT [FK_Receiver] FOREIGN KEY([receiver_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[user_message] CHECK CONSTRAINT [FK_Receiver]
GO

ALTER TABLE [dbo].[user_message]  WITH CHECK ADD  CONSTRAINT [FK_sender] FOREIGN KEY([sender_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[user_message] CHECK CONSTRAINT [FK_sender]
GO


