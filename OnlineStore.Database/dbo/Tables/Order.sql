CREATE TABLE [dbo].[Order]
(
	[Id]                INT                 NOT NULL    IDENTITY(1000,1), 
    [UserId]            INT                 NOT NULL, 
    [OrderState]        INT                 NOT NULL, 
    [EntryDate]         DATETIME2           NOT NULL    CONSTRAINT  [DF_Order_EntryDate]	DEFAULT	(SYSUTCDATETIME()),  
    [IsActive]          BIT                 NOT NULL    CONSTRAINT  [DF_Order_IsActive]     DEFAULT ((0)), 
    [IsDeleted]         BIT                 NOT NULL    CONSTRAINT  [DF_Order_IsDeleted]    DEFAULT ((0)), 


    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]),

)
