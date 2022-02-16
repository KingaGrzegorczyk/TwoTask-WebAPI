CREATE TABLE [dbo].[TodoTasksList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CategoryId] INT NOT NULL DEFAULT 0, 
    [IsArchived] BIT NOT NULL DEFAULT 0, 
    [Colour] NVARCHAR(25) NOT NULL DEFAULT 'Gray', 
    [Privacy] NVARCHAR(20) NOT NULL DEFAULT 'Private', 
    CONSTRAINT [FK_TodoTasksList_ToListsCategory] FOREIGN KEY (CategoryId) REFERENCES ListsCategory(Id)
)
