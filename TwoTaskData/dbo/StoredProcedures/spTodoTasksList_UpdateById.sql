CREATE PROCEDURE [dbo].[spTodoTasksList_UpdateById]
	@Id INT,
    @Name NVARCHAR(50), 
    @CategoryId INT, 
    @IsArchived BIT, 
    @Colour NVARCHAR(25), 
    @Privacy NVARCHAR(20) 
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.TodoTasksList
	SET [Name] = @Name, CategoryId = @CategoryId, IsArchived = @IsArchived, Colour = @Colour, Privacy = @Privacy
    WHERE Id = @Id;
END