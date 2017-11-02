-- Create Requests Table
CREATE TABLE dbo.Requests
(
	RequestID			INT IDENTITY (1,1) NOT NULL,
	IDNumber			INT	NOT NULL,
	DOB					Date	NOT NULL,
	FullName			NVARCHAR(128)	NOT NULL,
	NewResAddr			NVARCHAR(128)	NOT NULL,
	NewResCityStateZip	NVARCHAR(128) NOT NULL,
	NewResCounty		NVARCHAR(128)	NOT NULL,
	NewMailAddr			NVARCHAR(128),
	NewMailCityStateZip	NVARCHAR(128),
	NewMailCounty		NVARCHAR(128)
);