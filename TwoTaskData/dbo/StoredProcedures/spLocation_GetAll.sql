CREATE PROCEDURE [dbo].[spLocation_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, RegionId, Latitude, Longitude, Radius
	FROM [dbo].[Location]
	ORDER BY Id;
END
