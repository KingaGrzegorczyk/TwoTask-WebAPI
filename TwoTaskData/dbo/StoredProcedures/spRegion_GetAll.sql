CREATE PROCEDURE [dbo].[spRegion_GetAll]
	AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name]
	FROM [dbo].[Region]
	ORDER BY Id;
END
