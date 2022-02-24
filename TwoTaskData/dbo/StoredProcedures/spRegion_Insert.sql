CREATE PROCEDURE [dbo].[spRegion_Insert]
	@Id INT, 
    @Name NVARCHAR(50),
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Region([Name], UserId)
	VALUES (@Name, @UserId);
END
