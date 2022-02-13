USE [chat_applicatin]
GO

/****** Object:  StoredProcedure [dbo].[MESSAGES_OF_GROUP]    Script Date: 2/13/2022 5:05:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MESSAGES_OF_GROUP] @Groupid bigint AS
BEGIN
		select * from group_message where group_message.group_id = @Groupid
END;
GO


