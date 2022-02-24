CREATE PROCEDURE [dbo].[spListsCategory_DeleteById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.ListsCategory
    WHERE Id = @Id AND UserId = @UserId;
END
