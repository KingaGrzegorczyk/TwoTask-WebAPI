CREATE PROCEDURE [dbo].[spLocation_GetAll]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, RegionId, Latitude, Longitude, Radius, UserId
	FROM [dbo].[Location]
	WHERE UserId = @UserId
	ORDER BY Id;
END
