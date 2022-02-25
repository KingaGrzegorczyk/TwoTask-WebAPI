CREATE PROCEDURE [dbo].[spUser_GetByName]
	@UserName NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, UserName, Email, [Password], PasswordSalt
	FROM [dbo].[User]
	WHERE UserName = @UserName;
END
