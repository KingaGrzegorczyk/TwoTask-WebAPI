CREATE PROCEDURE [dbo].[spTodoTask_UpdateById]
	@Id INT, 
    @ListId INT, 
    @BeginDate DATETIME2, 
    @EndDate DATETIME2, 
    @RegionId INT, 
    @Description NVARCHAR(150), 
    @Title NVARCHAR(50), 
    @Priority INT, 
    @Status NVARCHAR(50), 
    @UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.TodoTask
	SET ListId = @ListId, BeginDate = @BeginDate, EndDate = @EndDate, RegionId = @RegionId, [Description] = @Description, Title = @Title, [Priority] = @Priority, [Status] = @Status, UserId = @UserId
    WHERE Id = @Id;
END
