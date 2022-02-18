CREATE PROCEDURE [dbo].[spLocation_Insert]
	@Id INT, 
    @RegionId INT, 
    @Latitude DECIMAL, 
    @Longitude DECIMAL, 
    @Radius INT 
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[Location](RegionId, Latitude, Longitude, Radius)
	VALUES (@RegionId, @Latitude, @Longitude, @Radius);
END
