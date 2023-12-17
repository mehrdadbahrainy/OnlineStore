CREATE TABLE [dbo].[Role]
(
	[Id]                INT             NOT NULL IDENTITY(1000, 1), 
    [Name]              NVARCHAR(50)    NOT NULL, 
    [EnName]            VARCHAR(50)     NOT NULL,
    [EntryDate]         DATETIME2(7)    NOT NULL    CONSTRAINT  [DF_Role_EntryDate]	DEFAULT	(SYSUTCDATETIME()), 
    [IsDeleted]         BIT             NOT NULL    CONSTRAINT  [DF_Role_IsDeleted] DEFAULT ((0)),

    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([Id] ASC),
)
