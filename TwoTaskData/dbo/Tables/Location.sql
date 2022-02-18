CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RegionId] INT NOT NULL, 
    [Latitude] DECIMAL NOT NULL, 
    [Longitude] DECIMAL NOT NULL, 
    [Radius] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Location_ToRegion] FOREIGN KEY (RegionId) REFERENCES Region(Id)
)
