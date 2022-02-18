CREATE PROCEDURE [dbo].[spLocation_DeleteById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.[Location]
    WHERE Id = @Id;
END
