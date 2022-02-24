CREATE PROCEDURE [dbo].[spRegion_GetAll]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], UserId
	FROM [dbo].[Region]
	WHERE UserId = @UserId
	ORDER BY Id;
END
