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

:r ..\..\Tables\Packet\Packet.Seed.sql
:r ..\..\Tables\Country\Country.Seed.sql
:r ..\..\Tables\Version\Version.Seed.sql
:r ..\..\Tables\PacketCountry\PacketCountry.Seed.sql