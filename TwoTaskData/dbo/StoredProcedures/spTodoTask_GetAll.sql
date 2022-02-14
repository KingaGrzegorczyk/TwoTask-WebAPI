CREATE PROCEDURE [dbo].[spTodoTask_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, ListId, BeginDate, EndDate, RegionId, [Description], Title, [Priority], [Status], UserId
	FROM [dbo].[TodoTask]
	ORDER BY Id;
END
