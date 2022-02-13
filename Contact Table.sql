USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[contact_new]    Script Date: 2/13/2022 5:02:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[contact_new](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NULL,
	[contact_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[contact_new]  WITH CHECK ADD  CONSTRAINT [FK_Table_ToTable] FOREIGN KEY([user_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[contact_new] CHECK CONSTRAINT [FK_Table_ToTable]
GO

ALTER TABLE [dbo].[contact_new]  WITH CHECK ADD  CONSTRAINT [FK_Table_ToTable_1] FOREIGN KEY([contact_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[contact_new] CHECK CONSTRAINT [FK_Table_ToTable_1]
GO


