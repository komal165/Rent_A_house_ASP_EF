SET IDENTITY_INSERT [dbo].[Contract] ON
INSERT INTO [dbo].[Contract] ([Id], [HouseId], [TenantId], [RentPerWeek]) VALUES (1, 1, 2, CAST(700.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Contract] ([Id], [HouseId], [TenantId], [RentPerWeek]) VALUES (2, 2, 1, CAST(500.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Contract] OFF
