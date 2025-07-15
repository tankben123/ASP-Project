IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
DROP TABLE [dbo].[Contact]
GO


CREATE TABLE [dbo].[Contact](
	[ContactId] [int] NOT NULL,
	[Email] varchar(500) NOT NULL,
	[Subject] nvarchar(500)  NOT NULL,
	[Body] nvarchar(500)  NOT NULL
)
