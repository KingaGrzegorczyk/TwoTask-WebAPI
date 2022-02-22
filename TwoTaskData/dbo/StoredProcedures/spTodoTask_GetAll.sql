CREATE PROCEDURE [dbo].[spTodoTask_GetAll]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, ListId, BeginDate, EndDate, RegionId, [Description], Title, [Priority], [Status], UserId
	FROM [dbo].[TodoTask]
	WHERE UserId = @UserId
	ORDER BY Id;
END
