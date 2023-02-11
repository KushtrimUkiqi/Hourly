﻿CREATE TABLE [dbo].[UserClaim]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
	[CreatedOn] SMALLDATETIME NOT NULL,
    [DeletedOn] SMALLDATETIME NULL,
	[Type] VARCHAR(50) NOT NULL,
	[Value] VARCHAR(50) NOT NULL,
	[ConcurrencyStamp] VARCHAR(255) NULL,
	[UserId] INT NOT NULL,
	CONSTRAINT [FK_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);

GO
CREATE INDEX [IX_UserClaims_UserId] ON [UserClaim] ([UserId] ASC);

