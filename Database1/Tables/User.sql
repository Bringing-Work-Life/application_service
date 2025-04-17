CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[MiddleName] NVARCHAR(30),
	[LastName] NVARCHAR(30) NOT NULL,
	[DOBDate] NVARCHAR(20) NOT NULL,         -- Store the date part
    [DOBTime] NVARCHAR(20) NOT NULL,      -- Store the time part with precision
	[Phone] NVARCHAR(20) NOT NULL,
	[Street1] NVARCHAR(50) NOT NULL,
	[Street2] NVARCHAR(50),
	[City] NVARCHAR(30) NOT NULL,
	[State] NVARCHAR(30) NOT NULL,
	[Pincode] NVARCHAR(20) NOT NULL,
	[UserName] NVARCHAR(100) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
)
