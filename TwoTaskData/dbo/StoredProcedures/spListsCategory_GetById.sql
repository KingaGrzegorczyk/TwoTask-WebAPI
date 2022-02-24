CREATE PROCEDURE [dbo].[spListsCategory_GetById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId, UserId
	FROM [dbo].[ListsCategory]
	WHERE Id = @Id AND UserId = @UserId;
END
