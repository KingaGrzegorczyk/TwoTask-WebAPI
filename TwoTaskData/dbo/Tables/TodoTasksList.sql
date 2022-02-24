CREATE TABLE [dbo].[TodoTasksList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CategoryId] INT NULL , 
    [IsArchived] BIT NOT NULL DEFAULT 0, 
    [Colour] NVARCHAR(25) NOT NULL DEFAULT 'Gray', 
    [Privacy] NVARCHAR(20) NOT NULL DEFAULT 'Private', 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [GroupId] INT NULL, 
    CONSTRAINT [FK_TodoTaskList_ToUser] FOREIGN KEY (UserId) REFERENCES [User](Id),
    CONSTRAINT [FK_TodoTasksList_ToListsCategory] FOREIGN KEY (CategoryId) REFERENCES ListsCategory(Id), 
    CONSTRAINT [FK_TodoTasksList_ToGroup] FOREIGN KEY (GroupId) REFERENCES [Group](Id)
)
