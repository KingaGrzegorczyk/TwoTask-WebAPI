CREATE PROCEDURE [dbo].[spListsCategory_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId
	FROM [dbo].[ListsCategory]
	WHERE Id = @Id;
END
