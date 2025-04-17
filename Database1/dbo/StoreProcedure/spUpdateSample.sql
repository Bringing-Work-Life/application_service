CREATE PROCEDURE [dbo].[spUpdateSample]
    @Id INT,
    @Name NVARCHAR(100),
    @Description NVARCHAR(255)
AS
BEGIN
    UPDATE Samples
    SET Name = @Name, Description = @Description
    WHERE Id = @Id;
END
