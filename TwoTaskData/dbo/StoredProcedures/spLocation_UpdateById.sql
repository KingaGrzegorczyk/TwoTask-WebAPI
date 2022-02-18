CREATE PROCEDURE [dbo].[spLocation_UpdateById]
	@Id INT, 
    @RegionId INT, 
    @Latitude DECIMAL, 
    @Longitude DECIMAL, 
    @Radius INT 
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[Location]
	SET RegionId = @RegionId, Latitude = @Latitude, Longitude = @Longitude, Radius = @Radius
    WHERE Id = @Id;
END
