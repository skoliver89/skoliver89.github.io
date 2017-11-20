CREATE TABLE dbo.RequestLogs
(
	RequestID			INT IDENTITY (1,1)	NOT NULL,
	RequestTime			DATETIME	NOT NULL,
	RequestClientIP		VARCHAR(50),
	RequestClientAgent	VARCHAR(128),
	RequestQuery		VARCHAR(128),
	RequestLang			VARCHAR(10),
	RequestRating		VARCHAR(10)

	CONSTRAINT [PK_dbo.RequestLogs] PRIMARY KEY CLUSTERED (RequestID ASC)
);