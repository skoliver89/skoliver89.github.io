-- Create Requests Table
CREATE TABLE dbo.Requests
(
	RequestID			INT IDENTITY (1,1)	NOT NULL,
	IDNumber			INT					NOT NULL,
	DOB					DATE				NOT NULL,
	FullName			NVARCHAR(128)		NOT NULL,
	NewResAddr			NVARCHAR(128)		NOT NULL,
	NewResCityStateZip	NVARCHAR(128)		NOT NULL,
	NewResCounty		NVARCHAR(128)		NOT NULL,
	NewMailAddr			NVARCHAR(128)		NULL,
	NewMailCityStateZip	NVARCHAR(128)		NULL,
	NewMailCounty		NVARCHAR(128)		NULL
);

INSERT INTO dbo.Requests (IDNumber, DOB, FullName, NewResAddr, NewResCityStateZip, 
	NewResCounty) VALUES
	('3865008', '1968-04-14', 'Smith, John, Jacob', '123 NW Maple DR', 'Oregon City OR 97045', 'Clackamas'),
	('1234567', '1989-07-30', 'Smith, Jane, Rose', '123 NW Maple DR', 'Oregon City OR 97045', 'Clackamas'),
	('1232345', '1997-11-09', 'Doe, Jerry, Killian ', '469 Vista DR APT 101', 'Fantasy Town WA 98001', 'King'),
	('7361245', '2001-02-01', 'Conners, Martha, Pearl', '4357 21st ST', 'Dream City OR 97001', 'Wasco');
	INSERT INTO dbo.Requests (IDNumber, DOB, FullName, NewResAddr, NewResCityStateZip,
	NewResCounty, NewMailAddr, NewMailCityStateZip, NewMailCounty) VALUES
	('1567456', '2000-05-20', 'Smith, Chris, Lee', '123 NW Maple DR', 'Oregon City OR 97045', 'Clackamas',
		'456 College DR', 'Monmouth OR 97361', 'Polk');
GO