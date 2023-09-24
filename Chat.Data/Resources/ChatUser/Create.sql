INSERT INTO [chat].[ChatXUser]
(
    [ChatId]
	,[UserId]
) 
OUTPUT Inserted.Id
VALUES 
(
    @ChatId
    ,@UserId
)
