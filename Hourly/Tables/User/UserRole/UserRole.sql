﻿CREATE TABLE [dbo].[UserRole]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
	[CreatedOn] SMALLDATETIME NOT NULL DEFAULT(GETDATE()),
    [DeletedOn] SMALLDATETIME NULL,
	[RoleId] INT NOT NULL,
	[UserId] INT NOT NULL,
    CONSTRAINT [FK_Role_Role_ID] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION,
	CONSTRAINT [FK_User_Role_ID] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
)