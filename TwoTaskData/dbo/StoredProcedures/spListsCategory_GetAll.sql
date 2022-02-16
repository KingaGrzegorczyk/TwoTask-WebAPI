CREATE PROCEDURE [dbo].[spListsCategory_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], CategoryId
	FROM [dbo].[ListsCategory]
	ORDER BY Id;
END
