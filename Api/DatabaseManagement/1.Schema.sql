USE [BusinessWorkflowEngineDB]
GO
/****** Object:  Schema [HangFire]    Script Date: 3/27/2023 12:04:39 AM ******/
CREATE SCHEMA [HangFire]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/27/2023 12:04:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/27/2023 12:04:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/27/2023 12:04:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/27/2023 12:04:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/27/2023 12:04:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/27/2023 12:04:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/27/2023 12:04:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[StatusId] [int] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[Otps]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MobileNumber] [nvarchar](15) NOT NULL,
	[VerificationCode] [nvarchar](6) NOT NULL,
	[ExpiredAt] [datetime] NOT NULL,
	[IsVerified] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Otps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Script]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Script](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[DestinationServerId] [int] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[SendTo] [nvarchar](250) NULL,
	[Parameter] [nvarchar](500) NULL,
 CONSTRAINT [PK_Script] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScriptHistory]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScriptHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScriptId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Output] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ScriptHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScriptUserPermission]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScriptUserPermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScriptId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_ScriptUserPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Server]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Server](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[MachineName] [nvarchar](50) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](250) NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[IpAddress] [nvarchar](20) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Server] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatus](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[AggregatedCounter]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[AggregatedCounter](
	[Key] [nvarchar](100) NOT NULL,
	[Value] [bigint] NOT NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_CounterAggregated] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[Counter]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Counter](
	[Key] [nvarchar](100) NOT NULL,
	[Value] [int] NOT NULL,
	[ExpireAt] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[Hash]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Hash](
	[Key] [nvarchar](100) NOT NULL,
	[Field] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[ExpireAt] [datetime2](7) NULL,
 CONSTRAINT [PK_HangFire_Hash] PRIMARY KEY CLUSTERED 
(
	[Key] ASC,
	[Field] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[Job]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Job](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StateId] [bigint] NULL,
	[StateName] [nvarchar](20) NULL,
	[InvocationData] [nvarchar](max) NOT NULL,
	[Arguments] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_Job] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[JobParameter]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[JobParameter](
	[JobId] [bigint] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_HangFire_JobParameter] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[JobQueue]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[JobQueue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[Queue] [nvarchar](50) NOT NULL,
	[FetchedAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_JobQueue] PRIMARY KEY CLUSTERED 
(
	[Queue] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[List]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[List](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_List] PRIMARY KEY CLUSTERED 
(
	[Key] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[Schema]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Schema](
	[Version] [int] NOT NULL,
 CONSTRAINT [PK_HangFire_Schema] PRIMARY KEY CLUSTERED 
(
	[Version] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[Server]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Server](
	[Id] [nvarchar](200) NOT NULL,
	[Data] [nvarchar](max) NULL,
	[LastHeartbeat] [datetime] NOT NULL,
 CONSTRAINT [PK_HangFire_Server] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[Set]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[Set](
	[Key] [nvarchar](100) NOT NULL,
	[Score] [float] NOT NULL,
	[Value] [nvarchar](256) NOT NULL,
	[ExpireAt] [datetime] NULL,
 CONSTRAINT [PK_HangFire_Set] PRIMARY KEY CLUSTERED 
(
	[Key] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [HangFire].[State]    Script Date: 3/27/2023 12:04:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HangFire].[State](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Reason] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Data] [nvarchar](max) NULL,
 CONSTRAINT [PK_HangFire_State] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Script] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ScriptHistory] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Server] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Status_StatusId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_AspNetUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_AspNetUsers_CreatedBy]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_AspNetUsers_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_AspNetUsers_UpdatedBy]
GO
ALTER TABLE [dbo].[Script]  WITH CHECK ADD  CONSTRAINT [FK_Script_AspNetUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Script] CHECK CONSTRAINT [FK_Script_AspNetUsers_CreatedBy]
GO
ALTER TABLE [dbo].[Script]  WITH CHECK ADD  CONSTRAINT [FK_Script_AspNetUsers_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Script] CHECK CONSTRAINT [FK_Script_AspNetUsers_UpdatedBy]
GO
ALTER TABLE [dbo].[Script]  WITH CHECK ADD  CONSTRAINT [FK_Script_Server_DestinationServerId] FOREIGN KEY([DestinationServerId])
REFERENCES [dbo].[Server] ([Id])
GO
ALTER TABLE [dbo].[Script] CHECK CONSTRAINT [FK_Script_Server_DestinationServerId]
GO
ALTER TABLE [dbo].[ScriptHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScriptHistory_AspNetUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ScriptHistory] CHECK CONSTRAINT [FK_ScriptHistory_AspNetUsers_CreatedBy]
GO
ALTER TABLE [dbo].[ScriptHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScriptHistory_AspNetUsers_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ScriptHistory] CHECK CONSTRAINT [FK_ScriptHistory_AspNetUsers_UpdatedBy]
GO
ALTER TABLE [dbo].[ScriptHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScriptHistory_Script_ScriptId] FOREIGN KEY([ScriptId])
REFERENCES [dbo].[Script] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScriptHistory] CHECK CONSTRAINT [FK_ScriptHistory_Script_ScriptId]
GO
ALTER TABLE [dbo].[ScriptUserPermission]  WITH CHECK ADD  CONSTRAINT [FK_ScriptUserPermission_AspNetUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScriptUserPermission] CHECK CONSTRAINT [FK_ScriptUserPermission_AspNetUsers_CreatedBy]
GO
ALTER TABLE [dbo].[ScriptUserPermission]  WITH CHECK ADD  CONSTRAINT [FK_ScriptUserPermission_AspNetUsers_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ScriptUserPermission] CHECK CONSTRAINT [FK_ScriptUserPermission_AspNetUsers_UpdatedBy]
GO
ALTER TABLE [dbo].[ScriptUserPermission]  WITH CHECK ADD  CONSTRAINT [FK_ScriptUserPermission_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ScriptUserPermission] CHECK CONSTRAINT [FK_ScriptUserPermission_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ScriptUserPermission]  WITH CHECK ADD  CONSTRAINT [FK_ScriptUserPermission_Permission_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
GO
ALTER TABLE [dbo].[ScriptUserPermission] CHECK CONSTRAINT [FK_ScriptUserPermission_Permission_PermissionId]
GO
ALTER TABLE [dbo].[ScriptUserPermission]  WITH CHECK ADD  CONSTRAINT [FK_ScriptUserPermission_Script_ScriptId] FOREIGN KEY([ScriptId])
REFERENCES [dbo].[Script] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScriptUserPermission] CHECK CONSTRAINT [FK_ScriptUserPermission_Script_ScriptId]
GO
ALTER TABLE [dbo].[Server]  WITH CHECK ADD  CONSTRAINT [FK_Server_AspNetUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Server] CHECK CONSTRAINT [FK_Server_AspNetUsers_CreatedBy]
GO
ALTER TABLE [dbo].[Server]  WITH CHECK ADD  CONSTRAINT [FK_Server_AspNetUsers_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Server] CHECK CONSTRAINT [FK_Server_AspNetUsers_UpdatedBy]
GO
ALTER TABLE [dbo].[UserStatus]  WITH CHECK ADD  CONSTRAINT [FK_UserStatus_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserStatus] CHECK CONSTRAINT [FK_UserStatus_AspNetUsers_UserId]
GO
ALTER TABLE [HangFire].[JobParameter]  WITH CHECK ADD  CONSTRAINT [FK_HangFire_JobParameter_Job] FOREIGN KEY([JobId])
REFERENCES [HangFire].[Job] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [HangFire].[JobParameter] CHECK CONSTRAINT [FK_HangFire_JobParameter_Job]
GO
ALTER TABLE [HangFire].[State]  WITH CHECK ADD  CONSTRAINT [FK_HangFire_State_Job] FOREIGN KEY([JobId])
REFERENCES [HangFire].[Job] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [HangFire].[State] CHECK CONSTRAINT [FK_HangFire_State_Job]
GO
