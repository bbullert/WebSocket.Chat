SELECT 
    UC.[Id]
    ,UC.[Name]
FROM [chat].[Chat] UC (NOLOCK)
INNER JOIN [chat].[ChatXUser] CCU (NOLOCK)
ON UC.[Id] = CCU.[ChatId]
WHERE CCU.[UserId] = @UserId