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
MERGE [dbo].[Version] AS T
USING
(
	SELECT *
	FROM (
	VALUES
		(1, NEWID(), '1.0.0', GETUTCDATE(), 1, 1),
		(2, NEWID(), '1.0.1', GETUTCDATE(), 2, 1),
		(3, NEWID(), '1.0.2', GETUTCDATE(), 3, 1),
		(4, NEWID(), '1.0.3', GETUTCDATE(), 4, 1),
		(5, NEWID(), '1.1.0', GETUTCDATE(), 5, 1),
		(6, NEWID(), '1.2.0', GETUTCDATE(), 6, 1),
		(7, NEWID(), '2.0.0', '2021-08-06 11:17:39.210', 7, 1),

		(8, NEWID(), '1.0.0', GETUTCDATE(), 1, 2),
		(9, NEWID(), '1.0.1', GETUTCDATE(), 2, 2),
		(10, NEWID(), '1.0.2', GETUTCDATE(), 3, 2),
		(11, NEWID(), '1.0.3', GETUTCDATE(), 4, 2),
		(12, NEWID(), '1.1.0', GETUTCDATE(), 5, 2),
		(13, NEWID(), '1.2.0', GETUTCDATE(), 6, 2),
		(14, NEWID(), '2.0.0', '2021-08-06 11:17:39.210', 7, 2),

		(15, NEWID(), '1.0.0', GETUTCDATE(), 1, 3),
		(16, NEWID(), '1.0.1', GETUTCDATE(), 2, 3),
		(17, NEWID(), '1.0.2', GETUTCDATE(), 3, 3),
		(18, NEWID(), '1.0.3', GETUTCDATE(), 4, 3),
		(19, NEWID(), '1.1.0', GETUTCDATE(), 5, 3),
		(20, NEWID(), '1.2.0', GETUTCDATE(), 6, 3),
		(21, NEWID(), '2.0.0', GETUTCDATE(), 7, 3)
		)
		AS temp ([Id], [Uid], [VersionCode], [VersionPublish], [VersionNumber], [PacketFk])
) AS S
ON T.[Id] = S.[Id]
WHEN MATCHED THEN UPDATE SET
	  T.[Uid]				= S.[Uid],
	  T.[VersionCode]		= S.[VersionCode],
	  T.[VersionPublish]	= S.[VersionPublish],
	  T.[VersionNumber]		= S.[VersionNumber],
	  T.[PacketFk]			= S.[PacketFk]
WHEN NOT MATCHED THEN
INSERT
([Id], [Uid], [VersionCode], [VersionPublish], [VersionNumber], [PacketFk])
VALUES
(S.[Id], S.[Uid], S.[VersionCode], S.[VersionPublish], S.[VersionNumber], S.[PacketFk]);
END
