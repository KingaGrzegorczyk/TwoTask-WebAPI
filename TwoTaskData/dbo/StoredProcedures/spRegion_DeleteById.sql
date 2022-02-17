CREATE PROCEDURE [dbo].[spRegion_DeleteById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Region
    WHERE Id = @Id;
END
