CREATE TABLE [dbo].[UserSecret] (
  [Id] INT PRIMARY KEY NOT NULL,
  [CreatedOn] SMALLDATETIME NOT NULL,
  [DeletedOn] SMALLDATETIME NULL,
  [Name] VARCHAR(50) NOT NULL,
  [Secret] VARCHAR(255) NOT NULL,
  [UserId] INT NOT NULL,
  [ConcurrencyStamp] VARCHAR(255) NULL, 
  CONSTRAINT [FK_UserSecret] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_UserSecret_UserId] ON [dbo].[UserSecret] ([UserId])
