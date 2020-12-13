/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

BEGIN
MERGE [dbo].[PacketCountry] AS T
USING
(
	SELECT *
	FROM (
	VALUES
		(1, NEWID(), 1, 126),
		(2, NEWID(), 1, 2),
		(3, NEWID(), 1, 3),
		(4, NEWID(), 2, 126),
		(5, NEWID(), 2, 5),
		(6, NEWID(), 2, 6),
		(7, NEWID(), 3, 126),
		(8, NEWID(), 3, 8),
		(9, NEWID(), 3, 9)
		)
		AS temp ([Id], [Uid], [PacketFk], [CountryFk])
) AS S
ON T.[Id] = S.[Id]
WHEN MATCHED THEN UPDATE SET
	  T.[Uid]				= S.[Uid],
	  T.[PacketFk]			= S.[PacketFk],
	  T.[CountryFk]			= S.[CountryFk]
WHEN NOT MATCHED THEN
INSERT
([Id], [Uid], [PacketFk], [CountryFk])
VALUES
(S.[Id], S.[Uid], S.[PacketFk], S.[CountryFk]);
END
