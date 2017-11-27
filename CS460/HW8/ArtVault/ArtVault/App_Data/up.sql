--Create the tables
CREATE TABLE dbo.Artists
(
	Name		VARCHAR(50)		NOT NULL,
	BirthDate	DATE			NOT NULL,
	BirthCity	VARCHAR(100)	NOT NULL

	CONSTRAINT [UC_dbo.Artists] UNIQUE (Name),
	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY (Name)
);

CREATE TABLE dbo.ArtWorks
(
	Title	VARCHAR(100)	NOT NULL,
	Artist	VARCHAR(50)		NULL
	
	CONSTRAINT [UC_dbo.ArtWorks] UNIQUE (Title),
	CONSTRAINT [PK_dbo.ArtWorks] PRIMARY KEY (Title),
	CONSTRAINT [FK_dbo.ArtWorks] FOREIGN KEY (Artist)
		REFERENCES dbo.Artists(Name)
			ON UPDATE NO ACTION
			ON DELETE NO ACTION
);

CREATE TABLE dbo.Genres
(
	Name	VARCHAR(50)	NOT NULL

	CONSTRAINT [UC_dbo.Genres] UNIQUE (Name),
	CONSTRAINT [PK_dbo.Genres] PRIMARY KEY (Name)
);

CREATE TABLE dbo.Classifications
(
	ArtWork	VARCHAR(100)	NOT NULL,
	Genre	VARCHAR(50)		NOT NULL

	CONSTRAINT [PK_dbo.Classifications] PRIMARY KEY (Artwork, Genre),
	CONSTRAINT [FK1_dbo.Classifications] FOREIGN KEY (Artwork)
		REFERENCES dbo.Artworks(Title)
			ON UPDATE NO ACTION
			ON DELETE CASCADE,
	CONSTRAINT [FK2_dbo.Classifications] FOREIGN KEY (Genre)
		REFERENCES dbo.Genres(Name)
			ON UPDATE NO ACTION
			ON DELETE CASCADE
);


--Populate the tables with some data
INSERT INTO dbo.Artists (Name, BirthDate, BirthCity) VALUES
('M C Escher', '1898-06-17', 'Leeuwarden, Netherlands'),
('Leonardo Da Vinci', '1519-05-02', 'Vinci, Italy'),
('Hatip Mehmed Efendi', '1680-11-18', 'Unknown'),
('Salvador Dali', '1904-05-11', 'Figueres, Spain');

INSERT INTO dbo.ArtWorks (Title, Artist) VALUES
('Circle Limit III', 'M C Escher'),
('Twon Tree', 'M C Escher'),
('Mona Lisa', 'Leonardo Da Vinci'),
('The Vitruvian Man', 'Leonardo Da Vinci'),
('Ebru', 'Hatip Mehmed Efendi'),
('Honey Is Sweeter Than Blood', 'Salvador Dali');

INSERT INTO dbo.Genres(Name) VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance');

INSERT INTO dbo.Classifications(ArtWork, Genre) VALUES
('Circle Limit III', 'Tesselation'),
('Twon Tree', 'Tesselation'),
('Twon Tree', 'Surrealism'),
('Mona Lisa', 'Portrait'),
('Mona Lisa', 'Renaissance'),
('The Vitruvian Man', 'Renaissance'),
('Ebru', 'Tesselation'),
('Honey Is Sweeter Than Blood', 'Surrealism');

GO