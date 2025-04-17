CREATE PROCEDURE [dbo].[spCreateSample]
    @Name NVARCHAR(100),
    @Description NVARCHAR(255)
AS
BEGIN
    INSERT INTO Samples (Name, Description)
    VALUES (@Name, @Description);

    SELECT SCOPE_IDENTITY();
END
