CREATE PROCEDURE [dbo].[spTodoTasksList_Insert]
	@Id INT, 
    @Name NVARCHAR(50), 
    @CategoryId INT, 
    @IsArchived BIT, 
    @Colour NVARCHAR(25), 
    @Privacy NVARCHAR(20),
    @UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.TodoTasksList([Name], CategoryId, IsArchived, Colour, Privacy, UserId)
	VALUES (@Name, @CategoryId, @IsArchived, @Colour, @Privacy, @UserId);
END