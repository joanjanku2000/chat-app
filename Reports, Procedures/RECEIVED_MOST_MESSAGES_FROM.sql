USE [chat_applicatin]
GO

/****** Object:  StoredProcedure [dbo].[RECEIVED_MOST_MESSAGES_FROM]    Script Date: 2/13/2022 5:06:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[RECEIVED_MOST_MESSAGES_FROM] @Userid bigint  AS
BEGIN
				select top 5 user_message.sender_id as sender,  count(*) as total_messages
					from dbo.user_message 
					where user_message.receiver_id = @Userid 
					group by user_message.sender_id 
					order by total_messages desc;
END;
GO


