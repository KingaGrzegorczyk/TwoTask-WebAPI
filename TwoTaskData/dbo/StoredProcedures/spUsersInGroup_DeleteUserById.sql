CREATE PROCEDURE [dbo].[spUsersInGroup_DeleteUserById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.UsersInGroup
    WHERE Id = @Id;
END
