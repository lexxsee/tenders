create table Citizens
(
    Id int identity
        constraint Citizens_pk
            primary key nonclustered,
    SurName nvarchar(100) not null,
    FirstName nvarchar(100) not null,
    Patronymic nvarchar(100),
    DateOfBirth date not null,
    DateOfDeath date
)
go

create unique index Citizens_Id_uindex
    on Citizens (Id)
go

create table CitizenDocumentTypes
(
    Id int not null
        constraint CitizenDocument_pk
            primary key nonclustered,
    Name nvarchar(50) not null
)
go

create unique index CitizenDocument_Id_uindex
    on CitizenDocumentTypes (Id)
go



create table CitizenDocuments
(
    Id int identity
        constraint CitizenDocuments_pk
            primary key nonclustered,
    TypeId int not null
        constraint CitizenDocuments_CitizenDocumentTypes_Id_fk
            references CitizenDocumentTypes,
    CitizenId int not null
        constraint CitizenDocuments_Citizens_Id_fk
            references Citizens
            on delete cascade,
    Number nvarchar(50) not null
)
go

create unique index CitizenDocuments_Id_uindex
    on CitizenDocuments (Id)
go
