USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[user_group]    Script Date: 2/13/2022 5:03:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_group](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[group_id] [bigint] NOT NULL,
	[user_id] [bigint] NOT NULL,
 CONSTRAINT [PK_user_group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[user_group]  WITH CHECK ADD  CONSTRAINT [FK_user_group_groupp] FOREIGN KEY([group_id])
REFERENCES [dbo].[groupp] ([id])
GO

ALTER TABLE [dbo].[user_group] CHECK CONSTRAINT [FK_user_group_groupp]
GO

ALTER TABLE [dbo].[user_group]  WITH CHECK ADD  CONSTRAINT [FK_user_group_userr] FOREIGN KEY([user_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[user_group] CHECK CONSTRAINT [FK_user_group_userr]
GO


