CREATE PROCEDURE [dbo].[spListsCategory_Insert]
	@Id INT, 
    @Name NVARCHAR(50), 
    @CategoryId INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.ListsCategory([Name], CategoryId, UserId)
	VALUES (@Name, @CategoryId, @UserId);
END
