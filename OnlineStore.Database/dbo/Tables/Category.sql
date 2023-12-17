CREATE TABLE [dbo].[Category]
(
	[Id]		        INT				NOT NULL    IDENTITY(1000,1), 
    [Name]		        NVARCHAR(50)	NOT NULL,
    [EnName]            VARCHAR(50)	    NOT NULL,
    [UserId]            INT             NOT NULL, 
    [EntryDate]         DATETIME2       NOT NULL    CONSTRAINT  [DF_Category_EntryDate]	DEFAULT	(SYSUTCDATETIME()),  
    [IsActive]          BIT             NOT NULL    CONSTRAINT  [DF_Category_IsActive] DEFAULT ((0)), 
    [IsDeleted]         BIT             NOT NULL    CONSTRAINT  [DF_Category_IsDeleted] DEFAULT ((0)), 

    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Category_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),
)
