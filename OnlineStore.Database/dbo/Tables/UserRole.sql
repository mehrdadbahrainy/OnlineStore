CREATE TABLE [dbo].[UserRole]
(
	[Id]        INT     NOT NULL IDENTITY(1000, 1), 
    [UserId]    INT     NOT NULL, 
    [RoleId]    INT     NOT NULL, 

    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([Id] ASC),
)
