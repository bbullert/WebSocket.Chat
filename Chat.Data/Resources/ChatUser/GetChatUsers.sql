SELECT 
    UU.[Id]
    ,UU.[FirstName]
    ,UU.[LastName]
    ,UU.[Avatar]
FROM [user].[User] UU (NOLOCK)
INNER JOIN [chat].[ChatXUser] CCU (NOLOCK)
ON UU.[Id] = CCU.[UserId]
WHERE CCU.[ChatId] = @ChatId