CREATE PROCEDURE [dbo].[spListsCategory_Insert]
	@Id INT, 
    @Name NVARCHAR(50), 
    @CategoryId INT 
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.ListsCategory([Name], CategoryId)
	VALUES (@Name, @CategoryId);
END
