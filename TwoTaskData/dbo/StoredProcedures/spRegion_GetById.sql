CREATE PROCEDURE [dbo].[spRegion_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name]
	FROM [dbo].[Region]
	WHERE Id = @Id;
END
