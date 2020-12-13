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
MERGE [dbo].[Packet] AS T
USING
(
	SELECT *
	FROM (
	VALUES
		(1, NEWID(), 'React', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/React-icon.svg/1280px-React-icon.svg.png'),
		(2, NEWID(), 'Angular', 'https://angular.io/assets/images/logos/angular/angular.png'),
		(3, NEWID(), 'Vue', 'https://3lhowb48prep40031529g5yj-wpengine.netdna-ssl.com/wp-content/uploads/2019/10/logo-vuejs-min.png')
		)
		AS temp ([Id], [Uid], [Name], [LogoUrl])
) AS S
ON T.[Id] = S.[Id]
WHEN MATCHED THEN UPDATE SET
	  T.[Uid]				= S.[Uid],
	  T.[Name]				= S.[Name],
	  T.[LogoUrl]			= S.[LogoUrl]
WHEN NOT MATCHED THEN
INSERT
([Id], [Uid], [Name], [LogoUrl])
VALUES
(S.[Id], S.[Uid], S.[Name], S.[LogoUrl]);
END
