﻿CREATE TABLE [dbo].[Tenant]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
    [CreatedOn] SMALLDATETIME NOT NULL,
    [DeletedOn] SMALLDATETIME NULL,
    [Name] VARCHAR(255) NULL,
    [Address] VARCHAR(255) NULL,
    [WebSite] VARCHAR(255) NULL
);
