CREATE PROCEDURE [dbo].[spTodoTasksList_GetAll]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId, IsArchived, Colour, Privacy, UserId
	FROM [dbo].[TodoTasksList]
	WHERE UserId = @UserId
	ORDER BY Id;
END

