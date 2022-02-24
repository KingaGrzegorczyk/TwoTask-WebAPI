CREATE PROCEDURE [dbo].[spTodoTasksList_DeleteById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.TodoTasksList
    WHERE Id = @Id AND UserId = @UserId;
END

