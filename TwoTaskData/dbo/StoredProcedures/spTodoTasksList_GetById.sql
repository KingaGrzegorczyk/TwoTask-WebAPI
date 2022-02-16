CREATE PROCEDURE [dbo].[spTodoTasksList_GetById]
	@Id INT 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId, IsArchived, Colour, Privacy
	FROM [dbo].[TodoTasksList]
	WHERE Id = @Id;
END

