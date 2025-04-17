CREATE PROCEDURE [dbo].[spGetUser]
@UserName NVARCHAR(30),
@Password NVARCHAR(30)
AS
 IF EXISTS (SELECT 1 FROM [User] WHERE UserName != @UserName)
    BEGIN
        RAISERROR('UserName Not exists.', 16, 1);
        RETURN 400; 
    END
    IF EXISTS (SELECT 1 FROM [User] WHERE Password != @Password)
    BEGIN
        RAISERROR('Password Not exists.', 16, 1);
        RETURN 400;  
    END
BEGIN
    SELECT *
    FROM [User] WHERE UserName = @UserName AND Password = @Password
END
