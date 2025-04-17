CREATE PROCEDURE [dbo].[spCreateUser]
	@FirstName NVARCHAR(30),
	@MiddleName NVARCHAR(30),
	@LastName NVARCHAR(30),
	@DOBDate NVARCHAR(20),        
    @DOBTime NVARCHAR(20),   
	@Phone NVARCHAR(20),
	@Street1 NVARCHAR(50),
	@Street2 NVARCHAR(50),
	@City NVARCHAR(30),
	@State NVARCHAR(30),
	@Pincode NVARCHAR(20),
	@UserName NVARCHAR(100),
	@Password NVARCHAR(50)
AS
BEGIN
  -- Validate mandatory fields
    IF ISNULL(@FirstName, '') = '' 
       OR ISNULL(@LastName, '') = ''
       OR ISNULL(@Street1, '') = ''
       OR ISNULL(@City, '') = ''
       OR ISNULL(@State, '') = ''
       OR ISNULL(@UserName, '') = ''
       OR ISNULL(@Password, '') = ''
    BEGIN
        RAISERROR('One or more mandatory fields are missing or empty.', 16, 1);
        RETURN;
    END
    -- Check for duplicate UserName
    IF EXISTS (SELECT 1 FROM [User] WHERE UserName = @UserName)
    BEGIN
        RAISERROR('UserName already exists.', 16, 1);
        RETURN 400;  -- Custom return value for duplicate UserName
    END
    INSERT INTO [User] (FirstName, MiddleName, LastName, DOBDate, DOBTime, Phone, Street1, Street2, City, State, Pincode, UserName, Password)
    VALUES (@FirstName,
	@MiddleName,
	@LastName,
	@DOBDate,        
    @DOBTime,   
	@Phone,
	@Street1,
	@Street2,
	@City,
	@State,
	@Pincode,
	@UserName,
	@Password);

    -- Get the last inserted ID
    DECLARE @NewUserID INT = SCOPE_IDENTITY();

    -- Return the newly inserted row
    SELECT FirstName, MiddleName, LastName, DOBDate, DOBTime, Phone, Street1, Street2, City, State, Pincode, UserName, Password FROM [dbo].[User] WHERE Id = @NewUserID;
END
