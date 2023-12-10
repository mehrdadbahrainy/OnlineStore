CREATE TABLE [dbo].[User]
(
	[Id]                INT                 NOT NULL    IDENTITY(1000,1), 
    [Username]          NVARCHAR(50)        NOT NULL, 
    [Password]          NVARCHAR(50)        NOT NULL, 
    [PasswordSalt]      NVARCHAR(50)        NOT NULL, 
    [FirstName]         NVARCHAR(30)        NOT NULL, 
    [LastName]          NVARCHAR(30)        NULL, 
    [Email]             NVARCHAR(50)        NOT NULL, 
    [BirthDate]         DATETIME2           NULL, 
    [IsActive]          BIT                 NOT NULL    CONSTRAINT  [DF_User_IsActive] DEFAULT ((0)), 
    [EntryDate]         DATETIME2           NOT NULL    CONSTRAINT  [DF_User_EntryDate]	DEFAULT	(SYSUTCDATETIME()), 
    [IsDeleted]         BIT                 NOT NULL    CONSTRAINT  [DF_User_IsDeleted] DEFAULT ((0)), 

    CONSTRAINT  [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),    
)
