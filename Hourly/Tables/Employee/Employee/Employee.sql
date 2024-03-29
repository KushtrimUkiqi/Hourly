﻿CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Uid] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
    [CreatedOn] SMALLDATETIME NOT NULL,
    [DeletedOn] SMALLDATETIME NULL,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] NVARCHAR(50) NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    [UserId] INT NULL, 
    [TenantId] INT NOT NULL
)
