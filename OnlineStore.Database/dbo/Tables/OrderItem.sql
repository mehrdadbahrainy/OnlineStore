CREATE TABLE [dbo].[OrderItem]
(
	[Id]            INT                 NOT NULL    IDENTITY(1000,1), 
    [OrderId]       INT                 NOT NULL, 
    [ItemId]        INT                 NOT NULL, 
    [Quantity]      INT                 NOT NULL, 
    [Price]         DECIMAL(18, 2)      NOT NULL, 
    [EntryDate]     DATETIME2           NOT NULL    CONSTRAINT  [DF_OrderItem_EntryDate]	DEFAULT	(SYSUTCDATETIME()),  
    [IsDeleted]     BIT                 NOT NULL    CONSTRAINT  [DF_OrderItem_IsDeleted]    DEFAULT ((0)), 

    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([Id]),
    CONSTRAINT [FK_OrderItem_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item]([Id]),

)
