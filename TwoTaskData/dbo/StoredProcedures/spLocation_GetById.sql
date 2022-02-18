CREATE PROCEDURE [dbo].[spLocation_GetById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, RegionId, Latitude, Longitude, Radius
	FROM [dbo].[Location]
	WHERE Id = @Id;
END
