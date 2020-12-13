CREATE TABLE [dbo].[PacketCountry]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Uid] UNIQUEIDENTIFIER NOT NULL, 
    [PacketFk] INT NOT NULL CONSTRAINT [FK_PacketCountry_Packet] FOREIGN KEY ([PacketFk]) REFERENCES dbo.[Packet]([Id]),
    [CountryFk] INT NOT NULL CONSTRAINT [FK_PacketCountry_Country] FOREIGN KEY ([CountryFk]) REFERENCES dbo.[Country]([Id]), 
    CONSTRAINT [CK_PacketCountry_PacketFk_CountryFk] UNIQUE (PacketFk, CountryFk), 
)
