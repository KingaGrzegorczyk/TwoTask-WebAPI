CREATE PROCEDURE [dbo].[spRegion_Insert]
	@Id INT, 
    @Name NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Region([Name])
	VALUES (@Name);
END
