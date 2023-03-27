
--CREATE TABLE [dbo].[Log](  
--    [Id] [int] IDENTITY(1,1) NOT NULL,  
--    [Message] [nvarchar](max) NULL,  
--    [MessageTemplate] [nvarchar](max) NULL,  
--    [Level] [nvarchar](128) NULL,  
--    [TimeStamp] [datetimeoffset](7) NOT NULL,  
--    [Exception] [nvarchar](max) NULL,  
--    [Properties] [xml] NULL,  
--    [LogEvent] [nvarchar](max) NULL,  
--    [UserName] [nvarchar](200) NULL,  
--    [IP] [varchar](200) NULL,  
-- CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED   
--(  
--    [Id] ASC  
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]  
--) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  


if not exists (select [name] from AspNetRoles where name='Admin')
begin
INSERT INTO [dbo].[AspNetRoles]([Id],[ConcurrencyStamp],[Name],[NormalizedName]) VALUES (1,NEWID(),'Admin','ADMIN');
end

if not exists (select [name] from AspNetRoles where name='User')
begin
INSERT INTO [dbo].[AspNetRoles]([Id],[ConcurrencyStamp],[Name],[NormalizedName]) VALUES (2, NEWID(),'User','USER');
end

if not exists (select [name] from AspNetRoles where name='Partner')
begin
INSERT INTO [dbo].[AspNetRoles]([Id],[ConcurrencyStamp],[Name],[NormalizedName]) VALUES (3, NEWID(),'Partner','PARTNER');
end


SET IDENTITY_INSERT Status ON

if not exists (select [name] from Status where [name]='Active')
begin
INSERT INTO [dbo].[Status]([Id],[Name],[DateCreated],[CreatedBy]) VALUES (1,'Active',GETDATE(),1);
end

if not exists (select [name] from Status where [name]='Pending')
begin
INSERT INTO [dbo].[Status]([Id],[Name],[DateCreated],[CreatedBy]) VALUES (2,'Pending',GETDATE(),1);
end

if not exists (select [name] from Status where [name]='Inactive')
begin
INSERT INTO [dbo].[Status]([Id],[Name],[DateCreated],[CreatedBy]) VALUES (3,'Inactive',GETDATE(),1);
end

if not exists (select [name] from Status where [name]='Blocked')
begin
INSERT INTO [dbo].[Status]([Id],[Name],[DateCreated],[CreatedBy]) VALUES (4,'Blocked',GETDATE(),1);
end

SET IDENTITY_INSERT Status OFF


SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id],[FirstName], [LastName], [StatusId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IsDeleted]) VALUES (1, N'Admin', N'Islam', 1, N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEN+6Pi7txgd+ckECxDngyx1elKNbxJ+QbJeSz5md/ANMXw1mMWkx35g7lffGZoS6PQ==', N'6IRPRU6WDHAAMTVFX3S7ROJCZGJNBWGC', N'f72adeaa-0c2b-4240-887f-f84884d9f99c', NULL, 0, 0, NULL, 1, 0, 0)

SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF

INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES(1,1)