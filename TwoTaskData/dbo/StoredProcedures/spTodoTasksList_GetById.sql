CREATE PROCEDURE [dbo].[spTodoTasksList_GetById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId, IsArchived, Colour, Privacy, UserId
	FROM [dbo].[TodoTasksList]
	WHERE Id = @Id AND UserId = @UserId;
END

