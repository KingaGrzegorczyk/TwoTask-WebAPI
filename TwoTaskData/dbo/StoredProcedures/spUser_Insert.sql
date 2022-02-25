CREATE PROCEDURE [dbo].[spUser_Insert]
	@Id UNIQUEIDENTIFIER, 
    @UserName NVARCHAR(20), 
    @Email NVARCHAR(30), 
    @Password VARBINARY(64),
	@PasswordSalt VARBINARY(128)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[User](Id, UserName, Email, [Password], PasswordSalt)
	VALUES (@Id, @UserName, @Email, @Password, @PasswordSalt);
END
