CREATE PROCEDURE [dbo].[spDeleteSample]
    @Id INT
AS
BEGIN
    DELETE FROM Samples
    WHERE Id = @Id;
END
