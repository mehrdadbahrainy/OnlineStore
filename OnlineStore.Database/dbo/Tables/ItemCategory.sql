CREATE TABLE [dbo].[ItemCategory]
(
	[Id]            INT                 NOT NULL    IDENTITY(1000,1), 
    [CategoryId]    INT                 NOT NULL, 
    [ItemId]        INT                 NOT NULL, 

    CONSTRAINT [PK_ItemCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemCategory_Order] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category]([Id]),
    CONSTRAINT [FK_ItemCategory_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item]([Id]),
)

GO

CREATE UNIQUE INDEX [UIX_ItemCategory_ItemId_CategoryId] ON [dbo].[ItemCategory] ([ItemId],[CategoryId])
