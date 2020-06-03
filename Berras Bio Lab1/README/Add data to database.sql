USE [BerrasBio]
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([MovieModelId], [Name], [RunTime], [Category], [Description]) VALUES (5, N'Gettysburg', 271, N'War & Drama', N'This war drama depicts one of the biggest events of the American Civil War, the Battle of Gettysburg. The massive three-day conflict begins as Confederate General Robert E. Lee (Martin Sheen) presses his troops north into Pennsylvania, leading to confrontations with Union forces, including the regiment of Colonel Joshua Chamberlain (Jeff Daniels). As the battle rages on and casualties mount, the film follows both the front lines and the strategic maneuvering behind the scenes.')
GO
INSERT [dbo].[Movies] ([MovieModelId], [Name], [RunTime], [Category], [Description]) VALUES (6, N'Gods and Generals', 280, N'War & Drama', N'Epic prequel to `Gettysburg'' examining the early days of the American Civil War through the experiences of three historical figures. Colonel Joshua Lawrence Chamberlain must leave behind his quiet academic life, General Thomas Stonewall Jackson must contend with his great religious faith, and General Robert Lee is forced to choose between his loyalty to the USA and his love of the Southern states.')
GO
INSERT [dbo].[Movies] ([MovieModelId], [Name], [RunTime], [Category], [Description]) VALUES (7, N'Ghettoblaster', 89, N'Comedy', N'Ashtray, a young black man, is sent to live in the ghetto with his father where he learns about the realities of life on the streets and how to become a man from his friends and relatives.')
GO
INSERT [dbo].[Movies] ([MovieModelId], [Name], [RunTime], [Category], [Description]) VALUES (8, N'The New Guy', 88, N'Comedy', N'An unpopular high school senior student faces a difficult year and gets himself expelled from school. Taking tips from a convict, he smartens up to gain admission in another school under an alias.')
GO
INSERT [dbo].[Movies] ([MovieModelId], [Name], [RunTime], [Category], [Description]) VALUES (9, N'Star Wars Episode IV', 125, N'Sci-Fi', N'After Princess Leia, the leader of the Rebel Alliance, is held hostage by Darth Vader, Luke and Han Solo must free her and destroy the powerful weapon created by the Galactic Empire.')
GO
INSERT [dbo].[Movies] ([MovieModelId], [Name], [RunTime], [Category], [Description]) VALUES (10, N'The Fourth Kind', 98, N'Horror', N'In Alaska, where many people begin disappearing mysteriously, a psychologist makes some shocking discoveries about aliens.')
GO
INSERT [dbo].[Movies] ([MovieModelId], [Name], [RunTime], [Category], [Description]) VALUES (11, N'Star wars V', 127, N'Sci-Fi', N'Darth Vader is adamant about turning Luke Skywalker to the dark side. Master Yoda trains Luke to become a Jedi Knight while his friends try to fend off the Imperial fleet.')
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Theaters] ON 
GO
INSERT [dbo].[Theaters] ([TheaterModelId], [Name], [TotalSeats]) VALUES (2, N'Salon 1', 50)
GO
INSERT [dbo].[Theaters] ([TheaterModelId], [Name], [TotalSeats]) VALUES (3, N'Salon 2', 100)
GO
SET IDENTITY_INSERT [dbo].[Theaters] OFF
GO
SET IDENTITY_INSERT [dbo].[Viewings] ON 
GO
INSERT [dbo].[Viewings] ([ViewingModelId], [StartTime], [AvaibleSeats], [TotalSeats], [TheaterModelId], [MovieModelId]) VALUES (34, CAST(N'2020-06-03T05:30:00.0000000' AS DateTime2), 50, 50, 2, 5)
GO
INSERT [dbo].[Viewings] ([ViewingModelId], [StartTime], [AvaibleSeats], [TotalSeats], [TheaterModelId], [MovieModelId]) VALUES (35, CAST(N'2020-06-03T12:40:00.0000000' AS DateTime2), 50, 50, 2, 6)
GO
INSERT [dbo].[Viewings] ([ViewingModelId], [StartTime], [AvaibleSeats], [TotalSeats], [TheaterModelId], [MovieModelId]) VALUES (36, CAST(N'2020-06-03T04:30:00.0000000' AS DateTime2), 100, 100, 3, 8)
GO
INSERT [dbo].[Viewings] ([ViewingModelId], [StartTime], [AvaibleSeats], [TotalSeats], [TheaterModelId], [MovieModelId]) VALUES (37, CAST(N'2020-06-03T20:30:00.0000000' AS DateTime2), 0, 100, 3, 10)
GO
INSERT [dbo].[Viewings] ([ViewingModelId], [StartTime], [AvaibleSeats], [TotalSeats], [TheaterModelId], [MovieModelId]) VALUES (38, CAST(N'2020-06-03T20:30:00.0000000' AS DateTime2), 50, 50, 2, 9)
GO
SET IDENTITY_INSERT [dbo].[Viewings] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 
GO
INSERT [dbo].[Tickets] ([TicketModelId], [OrderDateTime], [ViewingModelId], [NumberOfViewingTickets], [PersonName], [PhoneNumber]) VALUES (313, CAST(N'2020-06-02T23:29:24.1530881' AS DateTime2), 37, 10, N'Anton Asplund', N'0702895997')
GO
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
