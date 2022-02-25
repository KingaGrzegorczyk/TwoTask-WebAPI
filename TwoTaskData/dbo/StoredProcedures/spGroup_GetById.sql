CREATE PROCEDURE [dbo].[spGroup_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], OwnerId
	FROM [dbo].[Group]
	WHERE Id = @Id;
END
