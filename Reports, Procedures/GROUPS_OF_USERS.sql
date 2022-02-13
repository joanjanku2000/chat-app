USE [chat_applicatin]
GO

/****** Object:  StoredProcedure [dbo].[GROUPS_OF_USER]    Script Date: 2/13/2022 5:05:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GROUPS_OF_USER] @Userid bigint AS
BEGIN
		select  distinct (groupp.id) , max(groupp.name) , max(groupp.admin_id) , max(user_group.id), max(user_group.group_id) , max(user_group.user_id) , max( groupp.public_communication_key)
				from groupp 
					left join user_group on user_group.group_id = groupp.id 
				where (admin_id = @Userid ) or (user_group.user_id = @Userid) 
					group  by groupp.id ;
END;
GO


