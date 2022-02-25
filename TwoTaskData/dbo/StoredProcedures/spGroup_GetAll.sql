CREATE PROCEDURE [dbo].[spGroup_GetAll]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, [Name], OwnerId
	FROM [dbo].[Group]
	WHERE OwnerId = @UserId
	ORDER BY Id;
END
