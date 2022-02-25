CREATE PROCEDURE [dbo].[spUsersInGroup_GetAll]
	@GroupId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, GroupId, UserId
	FROM [dbo].[UsersInGroup]
	WHERE GroupId = @GroupId
	ORDER BY Id;
END
