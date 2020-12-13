CREATE TABLE [dbo].[Country]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Uid] UNIQUEIDENTIFIER NOT NULL, 
    [Code] CHAR(2) NOT NULL CONSTRAINT Country_Code_Unique UNIQUE, 
    [Name] NVARCHAR(100) NOT NULL CONSTRAINT Country_Name_Unique UNIQUE, 
    [Nicename] NVARCHAR(80) NOT NULL, 
    [Iso3] CHAR(3) NULL, 
    [Numcode] INT NULL, 
    [Phonecode] INT NOT NULL
)
