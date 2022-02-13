USE [chat_applicatin]
GO

/****** Object:  Table [dbo].[groupp]    Script Date: 2/13/2022 5:03:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[groupp](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nchar](65) NULL,
	[admin_id] [bigint] NULL,
	[public_communication_key] [varchar](max) NULL,
 CONSTRAINT [PK_groupp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[groupp]  WITH CHECK ADD  CONSTRAINT [FK_groupp_userr] FOREIGN KEY([admin_id])
REFERENCES [dbo].[userr] ([id])
GO

ALTER TABLE [dbo].[groupp] CHECK CONSTRAINT [FK_groupp_userr]
GO


