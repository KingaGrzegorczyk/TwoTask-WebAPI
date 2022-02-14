﻿CREATE PROCEDURE [dbo].[spTodoTask_GetById]
	@Id int 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, ListId, BeginDate, EndDate, RegionId, [Description], Title, [Priority], [Status], UserId
	FROM [dbo].[TodoTask]
	WHERE Id = @Id;
END