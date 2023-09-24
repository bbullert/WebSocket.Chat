INSERT INTO [chat].[Message]
(
    [Content]
    ,[CreateDate]
    ,[UserId]
    ,[ChatId]
) 
OUTPUT Inserted.Id
VALUES 
(
    @Content
    ,@CreateDate
    ,@UserId
    ,@ChatId
)
