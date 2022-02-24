CREATE PROCEDURE [dbo].[spListsCategory_UpdateById]
	@Id INT, 
    @Name NVARCHAR(50), 
    @CategoryId INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.ListsCategory
	SET [Name] = @Name, CategoryId = @CategoryId, UserId = @UserId
    WHERE Id = @Id AND UserId = @UserId;
END
