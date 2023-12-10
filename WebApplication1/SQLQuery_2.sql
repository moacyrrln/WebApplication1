/*
DROP TABLE [dbo].[Authors];

CREATE TABLE [dbo].[Authors] (
    [AuthorId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Email]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([AuthorId] ASC)
);

INSERT INTO [dbo].[Authors] ([Name], [Email])
VALUES
    ('Jorge Amado', NULL),
    ('Clarisse Lispertor', NULL);
*/

SELECT * FROM [BookStore].[dbo].[Authors]
SELECT * FROM [BookStore].[dbo].[Users]