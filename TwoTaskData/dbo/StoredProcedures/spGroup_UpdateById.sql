CREATE PROCEDURE [dbo].[spGroup_UpdateById]
	@Id INT, 
    @Name NVARCHAR(30), 
	@OwnerId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.[Group]
	SET [Name] = @Name, OwnerId = @OwnerId
    WHERE Id = @Id AND OwnerId = @OwnerId;
END
