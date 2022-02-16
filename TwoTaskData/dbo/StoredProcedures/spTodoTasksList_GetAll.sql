CREATE PROCEDURE [dbo].[spTodoTasksList_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId, IsArchived, Colour, Privacy
	FROM [dbo].[TodoTasksList]
	ORDER BY Id;
END

