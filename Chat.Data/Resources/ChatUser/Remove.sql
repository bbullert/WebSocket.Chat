DELETE FROM 
	[chat].[ChatXUser]
WHERE 
	[ChatId] = @ChatId AND 
	[UserId] = @UserId
SELECT @@ROWCOUNT