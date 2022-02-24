CREATE PROCEDURE [dbo].[spRegion_DeleteById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Region
    WHERE Id = @Id AND UserId = @UserId;
END
