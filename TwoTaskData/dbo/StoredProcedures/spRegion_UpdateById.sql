CREATE PROCEDURE [dbo].[spRegion_UpdateById]
	@Id INT, 
    @Name NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.Region
	SET [Name] = @Name
    WHERE Id = @Id;
END