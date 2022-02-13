USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[group_message]    Script Date: 2/13/2022 5:02:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[group_message](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[sender_id] [bigint] NOT NULL,
	[group_id] [bigint] NOT NULL,
	[message] [text] NOT NULL,
 CONSTRAINT [PK_group_message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[group_message]  WITH CHECK ADD  CONSTRAINT [FK_group_message_groupp] FOREIGN KEY([group_id])
REFERENCES [dbo].[groupp] ([id])
GO

ALTER TABLE [dbo].[group_message] CHECK CONSTRAINT [FK_group_message_groupp]
GO

ALTER TABLE [dbo].[group_message]  WITH CHECK ADD  CONSTRAINT [FK_group_message_userr] FOREIGN KEY([sender_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[group_message] CHECK CONSTRAINT [FK_group_message_userr]
GO


