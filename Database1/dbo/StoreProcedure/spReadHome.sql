CREATE PROCEDURE [dbo].[spReadHome]
AS
BEGIN
    SELECT Id, Label, Message, Type
    FROM masterHome
END
