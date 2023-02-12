SET IDENTITY_INSERT [Employee] ON;

INSERT INTO [Employee] ([Id], [Uid], [CreatedOn], [DeletedOn], [FirstName], [LastName] , [Email], [PhoneNumber], [UserId], [TenantId]) VALUES
(1, '9cec2d65-b14e-4b00-95e6-1917d98d89c4', N'2022-01-01 12:00:00', NULL, 'Kushtrim', 'Ukikj', 'kushtrimukiqi@gmail.com', '+389 77 777 777', 5, 1),
(2, '9cec2d65-b14e-4b00-95e6-1917d98d89c3', N'2022-01-01 12:00:00', NULL, 'Lirim', 'Hamiti', 'lirimhamiti@gmail.com', '+389 71 777 777', 5, 1),
(3, '9cec2d65-b14e-4b00-95e6-1917d98d89c2', N'2022-01-01 12:00:00', NULL, 'John', 'Doe', 'johndoe@gmail.com', '+389 70 707 777', 5, 1),
(4, '9cec2d65-b14e-4b00-95e6-1917d98d89c1', N'2022-01-01 12:00:00', NULL, 'Sarah', 'Simpson', 'sarahsimpson@gmail.com', '+389 72 717 777', 5, 1),
(5, '9cec2d65-b14e-4b00-95e6-1917d98d89c6', N'2022-01-01 12:00:00', NULL, 'Jamal', 'Musiala', 'jamalmusiala@gmail.com', '+389 71 727 777', 5, 1),
(6, '9cec2d65-b14e-4b00-95e6-1917d98d89c7', N'2022-01-01 12:00:00', NULL, 'Ted', 'Mosbey', 'tedmosbey@gmail.com', '+389 75 737 777', 5, 1)

SET IDENTITY_INSERT [Employee] OFF;
