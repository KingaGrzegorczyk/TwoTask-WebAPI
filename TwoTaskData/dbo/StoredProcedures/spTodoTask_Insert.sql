CREATE PROCEDURE [dbo].[spTodoTask_Insert]
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

	INSERT INTO dbo.TodoTask(ListId, BeginDate, EndDate, RegionId, [Description], Title, [Priority], [Status], UserId)
	VALUES (@ListId, @BeginDate, @EndDate, @RegionId, @Description, @Title, @Priority, @Status, @UserId);
END