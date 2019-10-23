SET IDENTITY_INSERT [dbo].[Tenant] ON
INSERT INTO [dbo].[Tenant] ([Id], [Name], [ContactNumber]) VALUES (1, N'Hans Watson', N'021345567233')
INSERT INTO [dbo].[Tenant] ([Id], [Name], [ContactNumber]) VALUES (2, N'Greg Wilkinson', N'02134777345')
SET IDENTITY_INSERT [dbo].[Tenant] OFF
