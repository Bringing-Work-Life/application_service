CREATE PROCEDURE [dbo].[spReadSample]
    @Id INT
AS
BEGIN
    SELECT Id, Name, Description
    FROM Samples
    WHERE Id = @Id;
END
