USE [chat_applicatin]
GO

/****** Object:  StoredProcedure [dbo].[GROUPS_MOST_INTERACTED_WITH]    Script Date: 2/13/2022 5:05:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GROUPS_MOST_INTERACTED_WITH] @Userid bigint  AS
BEGIN
				select top 5 group_message.group_id as group_id,  count(*) as total_messages
						from dbo.group_message 
						where group_message.sender_id = @Userid 
						group by group_message.group_id 
						order by total_messages desc;
END;
GO


