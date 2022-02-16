CREATE PROCEDURE [dbo].[spListsCategory_UpdateById]
	@Id INT, 
    @Name NVARCHAR(50), 
    @CategoryId INT 
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.ListsCategory
	SET [Name] = @Name, CategoryId = @CategoryId
    WHERE Id = @Id;
END
