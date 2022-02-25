CREATE PROCEDURE [dbo].[spUsersInGroup_Insert]
	@Id INT, 
    @GroupId NVARCHAR(30), 
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
SET NOCOUNT ON;

	INSERT INTO dbo.UsersInGroup(GroupId, UserId)
	VALUES (@GroupId, @UserId);
END
