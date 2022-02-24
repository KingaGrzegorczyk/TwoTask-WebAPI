CREATE PROCEDURE [dbo].[spListsCategory_GetAll]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId, UserId
	FROM [dbo].[ListsCategory]
	WHERE UserId = @UserId
	ORDER BY Id;
END
