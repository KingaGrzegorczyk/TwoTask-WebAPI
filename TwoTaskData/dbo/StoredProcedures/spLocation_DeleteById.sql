CREATE PROCEDURE [dbo].[spLocation_DeleteById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.[Location]
    WHERE Id = @Id AND UserId = @UserId;
END
