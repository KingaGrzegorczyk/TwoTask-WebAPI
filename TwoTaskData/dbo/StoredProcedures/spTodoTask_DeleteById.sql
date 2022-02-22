﻿CREATE PROCEDURE [dbo].[spTodoTask_DeleteById]
	@Id INT,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.TodoTask
    WHERE Id = @Id AND UserId = @UserId;
END