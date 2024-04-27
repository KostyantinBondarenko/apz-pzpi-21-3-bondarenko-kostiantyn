﻿CREATE TABLE [dbo].[Athletes]
(
	[Id]		UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[UserId]	UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT	[FK_Athletes_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers]([Id])
)