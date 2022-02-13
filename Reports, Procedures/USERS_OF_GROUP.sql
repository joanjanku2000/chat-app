USE [chat_applicatin]
GO

/****** Object:  StoredProcedure [dbo].[USERS_OF_GROUP]    Script Date: 2/13/2022 5:06:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USERS_OF_GROUP] @Groupid bigint AS
BEGIN
		select userr.id as user_id 
		, userr.namee as user_name, userr.last_name as last_name 
		, userr.phone_number as phone_number, userr.online as online 
		, groupp.id as group_id 
		, groupp.name as group_name from user_group 
		inner join userr on userr.id = user_group.user_id
		inner join groupp on user_group.group_id = groupp.id
		where user_group.group_id = @Groupid;
END;
GO


