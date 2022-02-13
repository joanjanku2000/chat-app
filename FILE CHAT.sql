USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[file_chat_user]    Script Date: 2/13/2022 8:14:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[file_chat_user](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[sender_id] [bigint] NULL,
	[receiver_id] [bigint] NULL,
	[attachment] [varbinary](max) NOT NULL,
	[file_Namee] [varchar](255) NULL,
 CONSTRAINT [PK_file_chat_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[file_chat_user]  WITH CHECK ADD  CONSTRAINT [FK_file_chat_user_userr] FOREIGN KEY([sender_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[file_chat_user] CHECK CONSTRAINT [FK_file_chat_user_userr]
GO

ALTER TABLE [dbo].[file_chat_user]  WITH CHECK ADD  CONSTRAINT [FK_file_chat_user_userr1] FOREIGN KEY([receiver_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[file_chat_user] CHECK CONSTRAINT [FK_file_chat_user_userr1]
GO


