SELECT COUNT(1)
FROM 
	[chat].[ChatXUser]
WHERE 
	[ChatId] = @ChatId AND 
	[UserId] = @UserId