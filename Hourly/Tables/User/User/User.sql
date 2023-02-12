﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
	[CreatedOn] SMALLDATETIME NOT NULL,
    [DeletedOn] SMALLDATETIME NULL,
	[Subject] VARCHAR(255) NOT NULL,
	[UserName]  VARCHAR(255) NULL,
	[Password]  VARCHAR(255) NULL,
	[Active] BIT NOT NULL,
	[ConcurrencyStamp]  VARCHAR(255) NULL,
	[Email]  VARCHAR(255) NULL,
	[TenantUid] UNIQUEIDENTIFIER NOT NULL,
	[SecurityCode]  VARCHAR(255) NULL,
	[SecurityCodeExpirationDate] DATE DEFAULT ('0001-01-01 00:00:00') NOT NULL
);

GO
CREATE UNIQUE INDEX [Users_IX_Users_Subject] ON [dbo].[User] ([Subject] ASC);
