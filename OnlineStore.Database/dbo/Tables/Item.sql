CREATE TABLE [dbo].[Item]
(
	[Id]                INT             NOT NULL IDENTITY(1000,1), 
    [Name]              NVARCHAR(50)    NOT NULL, 
    [CategoryId]        INT             NOT NULL, 
    [Description]       NVARCHAR(MAX)   NULL, 
    [Price]             DECIMAL(18, 2)  NULL, 
    [ImageFile]         NVARCHAR(50)    NULL, 
    [UserId]            INT             NOT NULL, 
    [EntryDate]         DATETIME2       NOT NULL    CONSTRAINT  [DF_Item_EntryDate]	DEFAULT	(SYSUTCDATETIME()),  
    [IsActive]          BIT             NOT NULL    CONSTRAINT  [DF_Item_IsActive] DEFAULT ((0)), 
    [IsDeleted]         BIT             NOT NULL    CONSTRAINT  [DF_Item_IsDeleted] DEFAULT ((0)), 

    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Item_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category]([Id]), 
    CONSTRAINT [FK_Item_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),

)
