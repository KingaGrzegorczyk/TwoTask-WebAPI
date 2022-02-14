CREATE PROCEDURE [dbo].[spTodoTask_DeleteById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.TodoTask
    WHERE Id = @Id;
END