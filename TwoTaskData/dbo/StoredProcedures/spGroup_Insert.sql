CREATE PROCEDURE [dbo].[spGroup_Insert]
	@Id INT, 
    @Name NVARCHAR(30), 
	@OwnerId UNIQUEIDENTIFIER
AS
BEGIN
SET NOCOUNT ON;

	INSERT INTO dbo.[Group]([Name], OwnerId)
	VALUES (@Name, @OwnerId);
END
