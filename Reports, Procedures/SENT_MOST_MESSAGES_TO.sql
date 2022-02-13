USE [chat_applicatin]
GO

/****** Object:  StoredProcedure [dbo].[SENT_MOST_MESSAGES]    Script Date: 2/13/2022 5:06:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SENT_MOST_MESSAGES] @Userid bigint  AS
BEGIN
	select top 5 user_message.receiver_id as receiver,  count(*) as total_messages
	
	from dbo.user_message 
				where user_message.sender_id = @Userid
			group by user_message.receiver_id 
		order by total_messages desc;
END;
GO


