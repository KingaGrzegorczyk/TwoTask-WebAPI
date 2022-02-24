CREATE TABLE [dbo].[UsersInGroup]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GroupId] INT NOT NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_UsersInGroup_ToGroup] FOREIGN KEY (GroupId) REFERENCES [Group]([Id]),
    CONSTRAINT [FK_UsersInGroup_ToUser] FOREIGN KEY (UserId) REFERENCES [User]([Id])
)
