SET IDENTITY_INSERT [dbo].[HouseOwner] ON
INSERT INTO [dbo].[HouseOwner] ([Id], [Name], [ContactNumber]) VALUES (1, N'John Smith', N'02134567890')
INSERT INTO [dbo].[HouseOwner] ([Id], [Name], [ContactNumber]) VALUES (2, N'Gareth Davis', N'02134567899')
INSERT INTO [dbo].[HouseOwner] ([Id], [Name], [ContactNumber]) VALUES (3, N'Jim Francis', N'02187649992')
SET IDENTITY_INSERT [dbo].[HouseOwner] OFF
SET IDENTITY_INSERT [dbo].[House] ON
INSERT INTO [dbo].[House] ([Id], [HouseOwnerId], [HouseAddress]) VALUES (1, 1, N'230B , Queen Street , Auckland')
INSERT INTO [dbo].[House] ([Id], [HouseOwnerId], [HouseAddress]) VALUES (2, 2, N'450B, Greath South Road, Aucklamd')
INSERT INTO [dbo].[House] ([Id], [HouseOwnerId], [HouseAddress]) VALUES (3, 3, N'345G , Mt Albert , Auckland')
SET IDENTITY_INSERT [dbo].[House] OFF
SET IDENTITY_INSERT [dbo].[Tenant] ON
INSERT INTO [dbo].[Tenant] ([Id], [Name], [ContactNumber]) VALUES (1, N'Hans Watson', N'021345567233')
INSERT INTO [dbo].[Tenant] ([Id], [Name], [ContactNumber]) VALUES (2, N'Greg Wilkinson', N'02134777345')
SET IDENTITY_INSERT [dbo].[Tenant] OFF
SET IDENTITY_INSERT [dbo].[Contract] ON
INSERT INTO [dbo].[Contract] ([Id], [HouseId], [TenantId], [RentPerWeek]) VALUES (1, 1, 2, CAST(700.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Contract] ([Id], [HouseId], [TenantId], [RentPerWeek]) VALUES (2, 2, 1, CAST(500.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Contract] OFF

