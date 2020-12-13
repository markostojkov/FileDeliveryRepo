CREATE TABLE [dbo].[Version]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Uid] UNIQUEIDENTIFIER NOT NULL, 
    [VersionCode] NVARCHAR(50) NOT NULL, 
    [VersionPublish] SMALLDATETIME NOT NULL, 
    [VersionNumber] INT NOT NULL, 
    [PacketFk] INT NOT NULL CONSTRAINT [FK_Version_Packet] FOREIGN KEY ([PacketFk]) REFERENCES dbo.[Packet]([Id]), 
    CONSTRAINT [CK_Version_VersionNumber_PacketFk] UNIQUE (VersionNumber, PacketFk)
)
