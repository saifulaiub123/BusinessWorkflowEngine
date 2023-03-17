
CREATE TABLE [dbo].[Log](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [Message] [nvarchar](max) NULL,  
    [MessageTemplate] [nvarchar](max) NULL,  
    [Level] [nvarchar](128) NULL,  
    [TimeStamp] [datetimeoffset](7) NOT NULL,  
    [Exception] [nvarchar](max) NULL,  
    [Properties] [xml] NULL,  
    [LogEvent] [nvarchar](max) NULL,  
    [UserName] [nvarchar](200) NULL,  
    [IP] [varchar](200) NULL,  
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]  
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  


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