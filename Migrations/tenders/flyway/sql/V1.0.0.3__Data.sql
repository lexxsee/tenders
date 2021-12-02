SET IDENTITY_INSERT master.dbo.Citizens ON;
INSERT INTO master.dbo.Citizens (Id, SurName, FirstName, Patronymic, DateOfBirth, DateOfDeath) VALUES (1, N'Волков', N'Олег', N'Александрович', N'1981-06-20', null);
INSERT INTO master.dbo.Citizens (Id, SurName, FirstName, Patronymic, DateOfBirth, DateOfDeath) VALUES (2, N'Иванов', N'Иван', N'Олегович', N'1984-04-25', null);
INSERT INTO master.dbo.Citizens (Id, SurName, FirstName, Patronymic, DateOfBirth, DateOfDeath)VALUES (3, N'Сидоров', N'Андрей', N'Петрович', N'1918-01-23', N'1986-05-23');
SET IDENTITY_INSERT master.dbo.Citizens OFF;

SET IDENTITY_INSERT master.dbo.CitizenDocuments ON;
INSERT INTO master.dbo.CitizenDocuments (Id, TypeId, CitizenId, Number) VALUES (1, 1, 1, N'12345');
INSERT INTO master.dbo.CitizenDocuments (Id, TypeId, CitizenId, Number) VALUES (2, 2, 1, N'54321');
INSERT INTO master.dbo.CitizenDocuments (Id, TypeId, CitizenId, Number) VALUES (3, 1, 2, N'45678');
INSERT INTO master.dbo.CitizenDocuments (Id, TypeId, CitizenId, Number) VALUES (4, 2, 2, N'324235');
INSERT INTO master.dbo.CitizenDocuments (Id, TypeId, CitizenId, Number) VALUES (5, 1, 3, N'342323');
INSERT INTO master.dbo.CitizenDocuments (Id, TypeId, CitizenId, Number) VALUES (6, 2, 3, N'5345435');
SET IDENTITY_INSERT master.dbo.CitizenDocuments OFF;