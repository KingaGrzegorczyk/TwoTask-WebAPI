CREATE PROCEDURE [dbo].[spRegion_GetById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], UserId
	FROM [dbo].[Region]
	WHERE Id = @Id AND UserId = @UserId;
END
