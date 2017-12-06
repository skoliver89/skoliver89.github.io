CREATE TABLE dbo.Buyers
(
	ID	INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(128)	NOT NULL

	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED (ID ASC)
);

CREATE TABLE dbo.Sellers
(
	ID INT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(128) NOT NULL

	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED (ID ASC)
);

CREATE TABLE dbo.Items
(
	ID INT IDENTITY(1001,1)	NOT NULL,
	Name NVARCHAR(128)		NOT NULL,
	Description	NVARCHAR(600)	NOT NULL,
	Seller	INT NOT NULL

	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED (ID ASC),
	CONSTRAINT [FK_dbo.Items] FOREIGN KEY (Seller)
		REFERENCES dbo.Sellers(ID)
			ON UPDATE NO ACTION
			ON DELETE CASCADE
);

CREATE TABLE dbo.Bids
(
	ID INT IDENTITY(1,1)	NOT NULL,
	Item	INT NOT NULL,
	Buyer	INT	NOT NULL,
	Price	DECIMAL	NOT NULL,
	Timestamp	DATETIME	NOT NULL

	CONSTRAINT	[PK_dbo.Bids]	PRIMARY KEY CLUSTERED (ID ASC),
	CONSTRAINT	[FK1_dbo.Bids]	FOREIGN KEY (Item)
		REFERENCES dbo.Items(ID)
			ON UPDATE NO ACTION
			ON DELETE CASCADE,
	CONSTRAINT [FK2_dbo.bids]	FOREIGN KEY (Buyer)
		REFERENCES dbo.Buyers(ID)
			ON UPDATE NO ACTION
			ON DELETE CASCADE
);

INSERT INTO dbo.Buyers (Name) VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');

INSERT INTO dbo.Sellers (Name) VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');

INSERT INTO dbo.Items (Name, Description, Seller) VALUES
('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 3),
('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 1),
('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 2);

INSERT INTO dbo.Bids (Item, Buyer, Price, Timestamp) VALUES
(1001,3,250000,'12/04/2017 09:04:22'),
(1003,1,95000 ,'12/04/2017 08:44:03');