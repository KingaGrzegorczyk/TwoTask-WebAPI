CREATE PROCEDURE [dbo].[spLocation_GetById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, RegionId, Latitude, Longitude, Radius, UserId
	FROM [dbo].[Location]
	WHERE Id = @Id AND UserID = @UserId;
END
