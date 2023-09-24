INSERT INTO [user].[User]
(
    [FirstName]
    ,[LastName]
    ,[Avatar]
) 
OUTPUT Inserted.Id
VALUES 
(
    @FirstName
    ,@LastName
    ,@Avatar
)
