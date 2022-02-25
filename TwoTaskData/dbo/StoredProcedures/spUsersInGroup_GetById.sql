CREATE PROCEDURE [dbo].[spUsersInGroup_GetById]
	@GroupId INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, GroupId, UserId
	FROM [dbo].[UsersInGroup]
	WHERE GroupId = @GroupId AND UserId = @UserId;
END
