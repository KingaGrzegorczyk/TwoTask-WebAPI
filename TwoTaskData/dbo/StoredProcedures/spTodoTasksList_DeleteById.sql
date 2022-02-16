CREATE PROCEDURE [dbo].[spTodoTasksList_DeleteById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.TodoTasksList
    WHERE Id = @Id;
END

