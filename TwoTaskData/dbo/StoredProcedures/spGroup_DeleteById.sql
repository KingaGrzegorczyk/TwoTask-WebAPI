CREATE PROCEDURE [dbo].[spGroup_DeleteById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.[Group]
    WHERE Id = @Id AND OwnerId = @UserId;
END

