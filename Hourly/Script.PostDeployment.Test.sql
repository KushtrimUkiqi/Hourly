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

IF ('$(LoadTestingData)' = 'Y')
BEGIN
	:r .\Tables\User\User\Test.User.Seed.sql
	:r .\Tables\User\UserClaim\Test.UserClaim.Seed.sql
	:r .\Tables\User\UserLogin\Test.UserLogin.Seed.sql
	:r .\Tables\User\UserSecret\Test.UserSecret.Seed.sql
	:r .\Tables\User\Role\Test.Role.Seed.sql
	:r .\Tables\User\Permission\Test.Permission.Seed.sql
	:r .\Tables\User\UserRole\Test.UserRole.Seed.sql

	:r .\Tables\Tenant\Tenant\Test.Tenant.Seed.sql

	:r .\Tables\Employee\Employee\Test.Employee.Seed.sql
END
