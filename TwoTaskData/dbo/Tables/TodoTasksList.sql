CREATE TABLE [dbo].[TodoTasksList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [CategoryId] INT NOT NULL DEFAULT 0, 
    [IsArchived] BIT NOT NULL DEFAULT 0, 
    [Colour] NVARCHAR(25) NOT NULL DEFAULT 'Gray', 
    [Privacy] NVARCHAR(20) NOT NULL DEFAULT 'Private'
)
