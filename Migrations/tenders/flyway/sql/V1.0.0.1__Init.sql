create table Citizens
(
    Id int identity
        constraint Citizens_pk
        primary key nonclustered,
    SurName nvarchar not null,
    FirstName nvarchar not null,
    Patronymic nvarchar,
    DateOfBirth datetime2 not null,
    DateOfDeath datetime2
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
    Name nvarchar not null
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
    Number nvarchar not null
)
go

create unique index CitizenDocuments_Id_uindex
    on CitizenDocuments (Id)
go
