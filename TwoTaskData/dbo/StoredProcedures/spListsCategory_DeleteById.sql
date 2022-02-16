CREATE PROCEDURE [dbo].[spListsCategory_DeleteById]
		@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.ListsCategory
    WHERE Id = @Id;
END
