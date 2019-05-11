CREATE TABLE [dbo].[Users] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (200) NOT NULL,
    [PasswordHash] NVARCHAR (200) NOT NULL,
    [PasswordSalt] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

