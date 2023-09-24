INSERT INTO [chat].[Chat]
(
    [Name]
) 
OUTPUT Inserted.Id
VALUES 
(
    @Name
)
