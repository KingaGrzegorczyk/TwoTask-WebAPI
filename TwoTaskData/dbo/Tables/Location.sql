CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RegionId] INT NOT NULL, 
    [Latitude] DECIMAL NOT NULL, 
    [Longitude] DECIMAL NOT NULL, 
    [Radius] INT NOT NULL DEFAULT 1, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Location_ToUser] FOREIGN KEY (UserId) REFERENCES [User](Id),
    CONSTRAINT [FK_Location_ToRegion] FOREIGN KEY (RegionId) REFERENCES Region(Id)
)
