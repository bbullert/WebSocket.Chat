SELECT 
	[Id]
	,[ChatId]
	,[UserId]
FROM 
	[chat].[ChatXUser]
WHERE 
	[ChatId] = @ChatId AND 
	[UserId] = @UserId