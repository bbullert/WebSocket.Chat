SELECT 
    CM.[Id]
    ,CM.[Content]
    ,CM.[CreateDate]
    ,CM.[UserId]
	,UU.[FirstName] + ' ' + UU.[LastName] AS [UserFullName]
    ,UU.[Avatar] AS [UserAvatar]
    ,CM.[ChatId]
FROM [chat].[Message] CM (NOLOCK)
INNER JOIN [user].[User] UU (NOLOCK)
ON UU.[Id] = CM.[UserId]
WHERE CM.[ChatId] = @ChatId
ORDER BY 
	[CreateDate] DESC
OFFSET @Offset ROWS
FETCH NEXT @Count ROWS ONLY
