USE [r0786156]
GO

SELECT * FROM [LaFiestaDB].[Artiest]
SELECT * FROM [LaFiestaDB].[Festival]
SELECT * FROM [LaFiestaDB].[FestivalArtiest]
SELECT * FROM [LaFiestaDB].[Locatie]
SELECT * FROM [LaFiestaDB].[Ticket]
SELECT * FROM [LaFiestaDB].[TicketFestival]
GO

DELETE FROM [LaFiestaDB].[Artiest]
DELETE FROM [LaFiestaDB].[Festival]
DELETE FROM [LaFiestaDB].[FestivalArtiest]
DELETE FROM [LaFiestaDB].[Locatie]
DELETE FROM [LaFiestaDB].[Ticket]
DELETE FROM [LaFiestaDB].[TicketFestival]
GO

SET IDENTITY_INSERT [LaFiestaDB].[Artiest] ON 
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (1, N'ShawnMendes.jpg', N'Shawn', N'Mendes', N'Man', '1998-08-08', N'Singer-songwriter')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (2, N'TheWeeknd.jpg', N'The', N'Weeknd', N'Man', '1990-02-16', N'Singer-songwriter')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (3, N'CamilaCabello.jpg', N'Camila', N'Cabello', N'Vrouw', '1997-03-03', N'Singer-songwriter')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (4, N'MichaelBublé.jpg', N'Michael', N'Bublé', N'Man', '1975-09-09', N'Jazz')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (5, N'Suzan&Freek.jpg', N'Suzan', N'& Freek', N'Overige', '2014', N'Nederlandstalig')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (6, N'DuaLipa.jpg', N'Dua', N'Lipa', N'Vrouw', '1995-08-22', N'Pop')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (7, N'KatyPerry.jpg', N'Katy', N'Perry', N'Vrouw', '1984-10-25', N'Pop')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (8, N'Coldplay.jpg', N'Coldplay', N'', N'Overige', '1996', N'Rock')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (9, N'Maroon5.jpg', N'Maroon', N'5', N'Overige', '2004', N'Pop')
INSERT [LaFiestaDB].[Artiest] ([Id], [Afbeelding], [Voornaam], [Achternaam], [Geslacht], [Geboortedatum], [Genre]) VALUES (10, N'ModJoeriVerlooy.jpg', N'Mod', N'Joeri Verlooy', N'Man', '1990-09-01', N'EDM')

SET IDENTITY_INSERT [LaFiestaDB].[Artiest] OFF
GO

SET IDENTITY_INSERT [LaFiestaDB].[Locatie] ON
INSERT [LaFiestaDB].[Locatie] ([Id], [Huisnummer], [Straat], [Postcode], [Plaats]) VALUES (1, N'6', N'Winterhof', N'2590', N'Berlaar')
INSERT [LaFiestaDB].[Locatie] ([Id], [Huisnummer], [Straat], [Postcode], [Plaats]) VALUES (2, N'99', N'Antwerpsestraat', N'2500', N'Lier')
SET IDENTITY_INSERT [LaFiestaDB].[Locatie] OFF
GO

SET IDENTITY_INSERT [LaFiestaDB].[Festival] ON
INSERT [LaFiestaDB].[Festival] ([Id], [Naam], [Afbeelding], [BeginDatum], [EindDatum], [MinimumLeeftijd], [Omschrijving], [LocatieId]) VALUES (1, N'Verjaardag Zahra', N'Verjaardag.jpg','2023-01-07', '2023-01-08', 18, N'Dit is een verjaardagsfeest ter eren van Zahra''s 19de verjaardag.', 1)
INSERT [LaFiestaDB].[Festival] ([Id], [Naam], [Afbeelding], [BeginDatum], [EindDatum], [MinimumLeeftijd], [Omschrijving], [LocatieId]) VALUES (2, N'Verjaardag Stijn', N'Verjaardag.jpg','2023-03-09', '2023-03-10', 20, N'Dit is een verjaardagsfeest ter eren van Stijn''s 22ste verjaardag.', 1)
INSERT [LaFiestaDB].[Festival] ([Id], [Naam], [Afbeelding], [BeginDatum], [EindDatum], [MinimumLeeftijd], [Omschrijving], [LocatieId]) VALUES (3, N'Thomas More gaat door', N'ThomasMoreParty.jpg','2023-09-01', '2023-09-02', 20, N'Dit is een festival voor en door studenten van Thomas More Lier.', 2)
SET IDENTITY_INSERT [LaFiestaDB].[Festival] OFF
GO

SET IDENTITY_INSERT [LaFiestaDB].[FestivalArtiest] ON
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (1, 1, 1)
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (2, 2, 1)
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (3, 3, 1)
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (4, 1, 2)
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (5, 2, 2)
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (6, 3, 2)
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (7, 1, 3)
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (8, 2, 3)
INSERT [LaFiestaDB].[FestivalArtiest] ([Id], [FestivalId], [ArtiestId]) VALUES (9, 3, 3)
SET IDENTITY_INSERT [LaFiestaDB].[FestivalArtiest] OFF
GO

SET IDENTITY_INSERT [LaFiestaDB].[Ticket] ON
INSERT [LaFiestaDB].[Ticket] ([Id], [Datum], [Prijs], [Aantal], [Soort], [CustomUserId]) VALUES (1, '2023-01-07', 8.75, 20, N'Standaard', '38455972-ca46-4614-aa24-5e43ca9c12c5')
INSERT [LaFiestaDB].[Ticket] ([Id], [Datum], [Prijs], [Aantal], [Soort], [CustomUserId]) VALUES (2, '2023-03-09', 9.75, 20, N'Standaard', '38455972-ca46-4614-aa24-5e43ca9c12c5')
INSERT [LaFiestaDB].[Ticket] ([Id], [Datum], [Prijs], [Aantal], [Soort], [CustomUserId]) VALUES (3, '2023-09-01', 8.75, 200, N'Standaard', '38455972-ca46-4614-aa24-5e43ca9c12c5')
INSERT [LaFiestaDB].[Ticket] ([Id], [Datum], [Prijs], [Aantal], [Soort], [CustomUserId]) VALUES (4, '2023-09-01', 9.75, 200, N'Standaard+', '38455972-ca46-4614-aa24-5e43ca9c12c5')
INSERT [LaFiestaDB].[Ticket] ([Id], [Datum], [Prijs], [Aantal], [Soort], [CustomUserId]) VALUES (5, '2023-09-01', 10.75, 200, N'Standaard++', '38455972-ca46-4614-aa24-5e43ca9c12c5')
INSERT [LaFiestaDB].[Ticket] ([Id], [Datum], [Prijs], [Aantal], [Soort], [CustomUserId]) VALUES (6, '2023-09-01', 15.75, 15, N'VIP', '38455972-ca46-4614-aa24-5e43ca9c12c5')
SET IDENTITY_INSERT [LaFiestaDB].[Ticket] OFF
GO

SET IDENTITY_INSERT [LaFiestaDB].[TicketFestival] ON
INSERT [LaFiestaDB].[TicketFestival] ([Id], [FestivalId], [TicketId]) VALUES (1, 1, 1)
INSERT [LaFiestaDB].[TicketFestival] ([Id], [FestivalId], [TicketId]) VALUES (2, 2, 2)
INSERT [LaFiestaDB].[TicketFestival] ([Id], [FestivalId], [TicketId]) VALUES (3, 3, 3)
INSERT [LaFiestaDB].[TicketFestival] ([Id], [FestivalId], [TicketId]) VALUES (4, 3, 4)
INSERT [LaFiestaDB].[TicketFestival] ([Id], [FestivalId], [TicketId]) VALUES (5, 3, 5)
INSERT [LaFiestaDB].[TicketFestival] ([Id], [FestivalId], [TicketId]) VALUES (6, 3, 6)
SET IDENTITY_INSERT [LaFiestaDB].[TicketFestival] OFF
GO