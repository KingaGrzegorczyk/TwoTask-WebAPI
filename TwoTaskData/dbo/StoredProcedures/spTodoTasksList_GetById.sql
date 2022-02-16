CREATE PROCEDURE [dbo].[spTodoTasksList_GetById]
	@Id int 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId, IsArchived, Colour, Privacy
	FROM [dbo].[TodoTasksList]
	WHERE Id = @Id;
END

