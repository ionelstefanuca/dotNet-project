
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/23/2016 11:13:22
-- Generated from EDMX file: C:\Users\ionel\Google Drive\proiect dotNet\EF_WCF\EF_WCF\ModelContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Proiect];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CapitoleIntrebari]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Intrebaris] DROP CONSTRAINT [FK_CapitoleIntrebari];
GO
IF OBJECT_ID(N'[dbo].[FK_CursantiIstoricTesteRezolvateNerezolvateDeCursant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IstoricTesteRezolvateNerezolvateDeCursants] DROP CONSTRAINT [FK_CursantiIstoricTesteRezolvateNerezolvateDeCursant];
GO
IF OBJECT_ID(N'[dbo].[FK_CursantiListaCursantiTestProgramat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListaCursantiTestProgramats] DROP CONSTRAINT [FK_CursantiListaCursantiTestProgramat];
GO
IF OBJECT_ID(N'[dbo].[FK_CursantiTesteSalvateInBazaDeDate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TesteSalvateInBazaDeDates] DROP CONSTRAINT [FK_CursantiTesteSalvateInBazaDeDate];
GO
IF OBJECT_ID(N'[dbo].[FK_DisciplinaCapitole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Capitoles] DROP CONSTRAINT [FK_DisciplinaCapitole];
GO
IF OBJECT_ID(N'[dbo].[FK_DisciplinaCursanti]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cursantis] DROP CONSTRAINT [FK_DisciplinaCursanti];
GO
IF OBJECT_ID(N'[dbo].[FK_DisciplinaLectori]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lectoris] DROP CONSTRAINT [FK_DisciplinaLectori];
GO
IF OBJECT_ID(N'[dbo].[FK_IntrebariIntrebariTeste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IntrebariTestes] DROP CONSTRAINT [FK_IntrebariIntrebariTeste];
GO
IF OBJECT_ID(N'[dbo].[FK_IntrebariRaspunsuri]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Raspunsuris] DROP CONSTRAINT [FK_IntrebariRaspunsuri];
GO
IF OBJECT_ID(N'[dbo].[FK_IntrebariTesteSalvateInBazaDeDate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TesteSalvateInBazaDeDates] DROP CONSTRAINT [FK_IntrebariTesteSalvateInBazaDeDate];
GO
IF OBJECT_ID(N'[dbo].[FK_LectoriTestCreatDeLector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestCreatDeLectors] DROP CONSTRAINT [FK_LectoriTestCreatDeLector];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgramareTestListaCursantiTestProgramat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListaCursantiTestProgramats] DROP CONSTRAINT [FK_ProgramareTestListaCursantiTestProgramat];
GO
IF OBJECT_ID(N'[dbo].[FK_TestCreatDeLectorIntrebariTeste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IntrebariTestes] DROP CONSTRAINT [FK_TestCreatDeLectorIntrebariTeste];
GO
IF OBJECT_ID(N'[dbo].[FK_TestCreatDeLectorIstoricTesteCreateDeLectori]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IstoricTesteCreateDeLectoris] DROP CONSTRAINT [FK_TestCreatDeLectorIstoricTesteCreateDeLectori];
GO
IF OBJECT_ID(N'[dbo].[FK_TestCreatDeLectorIstoricTesteRezolvateNerezolvateDeCursant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IstoricTesteRezolvateNerezolvateDeCursants] DROP CONSTRAINT [FK_TestCreatDeLectorIstoricTesteRezolvateNerezolvateDeCursant];
GO
IF OBJECT_ID(N'[dbo].[FK_TestCreatDeLectorProgramareTest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgramareTests] DROP CONSTRAINT [FK_TestCreatDeLectorProgramareTest];
GO
IF OBJECT_ID(N'[dbo].[FK_TestCreatDeLectorTesteSalvateInBazaDeDate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TesteSalvateInBazaDeDates] DROP CONSTRAINT [FK_TestCreatDeLectorTesteSalvateInBazaDeDate];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Capitoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Capitoles];
GO
IF OBJECT_ID(N'[dbo].[Cursantis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cursantis];
GO
IF OBJECT_ID(N'[dbo].[Disciplinas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Disciplinas];
GO
IF OBJECT_ID(N'[dbo].[Intrebaris]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intrebaris];
GO
IF OBJECT_ID(N'[dbo].[IntrebariTestes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IntrebariTestes];
GO
IF OBJECT_ID(N'[dbo].[IstoricTesteCreateDeLectoris]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IstoricTesteCreateDeLectoris];
GO
IF OBJECT_ID(N'[dbo].[IstoricTesteRezolvateNerezolvateDeCursants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IstoricTesteRezolvateNerezolvateDeCursants];
GO
IF OBJECT_ID(N'[dbo].[Lectoris]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lectoris];
GO
IF OBJECT_ID(N'[dbo].[ListaCursantiTestProgramats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListaCursantiTestProgramats];
GO
IF OBJECT_ID(N'[dbo].[ProgramareTests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgramareTests];
GO
IF OBJECT_ID(N'[dbo].[Raspunsuris]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Raspunsuris];
GO
IF OBJECT_ID(N'[dbo].[TestCreatDeLectors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestCreatDeLectors];
GO
IF OBJECT_ID(N'[dbo].[TesteSalvateInBazaDeDates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TesteSalvateInBazaDeDates];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Capitoles'
CREATE TABLE [dbo].[Capitoles] (
    [IdCapitol] int IDENTITY(1,1) NOT NULL,
    [NumeCapitol] nvarchar(max)  NOT NULL,
    [DisciplinaIdDisciplina] int  NOT NULL
);
GO

-- Creating table 'Cursantis'
CREATE TABLE [dbo].[Cursantis] (
    [IdCursant] int IDENTITY(1,1) NOT NULL,
    [ContCursant] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Parola] nvarchar(max)  NOT NULL,
    [DisciplinaIdDisciplina] int  NOT NULL
);
GO

-- Creating table 'Disciplinas'
CREATE TABLE [dbo].[Disciplinas] (
    [IdDisciplina] int IDENTITY(1,1) NOT NULL,
    [NumeDisciplina] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Intrebaris'
CREATE TABLE [dbo].[Intrebaris] (
    [IdIntrebare] int IDENTITY(1,1) NOT NULL,
    [Intrebarea] nvarchar(max)  NOT NULL,
    [CapitoleIdCapitol] int  NOT NULL
);
GO

-- Creating table 'IntrebariTestes'
CREATE TABLE [dbo].[IntrebariTestes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TestCreatDeLectorIdTest] int  NOT NULL,
    [IntrebariIdIntrebare] int  NOT NULL
);
GO

-- Creating table 'IstoricTesteCreateDeLectoris'
CREATE TABLE [dbo].[IstoricTesteCreateDeLectoris] (
    [IdIstoricTeste] int IDENTITY(1,1) NOT NULL,
    [TestCreatDeLectorIdTest] int  NOT NULL,
    [Data] datetime  NOT NULL
);
GO

-- Creating table 'IstoricTesteRezolvateNerezolvateDeCursants'
CREATE TABLE [dbo].[IstoricTesteRezolvateNerezolvateDeCursants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TestCreatDeLectorIdTest] int  NOT NULL,
    [CursantiIdCursant] int  NOT NULL,
    [Rezolvat] bit  NOT NULL,
    [Obligatoriu] bit  NOT NULL
);
GO

-- Creating table 'Lectoris'
CREATE TABLE [dbo].[Lectoris] (
    [IdLector] int IDENTITY(1,1) NOT NULL,
    [ContLector] nvarchar(max)  NOT NULL,
    [Parola] nvarchar(max)  NOT NULL,
    [DisciplinaIdDisciplina] int  NOT NULL
);
GO

-- Creating table 'ListaCursantiTestProgramats'
CREATE TABLE [dbo].[ListaCursantiTestProgramats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProgramareTestId] int  NOT NULL,
    [CursantiIdCursant] int  NOT NULL
);
GO

-- Creating table 'ProgramareTests'
CREATE TABLE [dbo].[ProgramareTests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TestCreatDeLectorIdTest] int  NOT NULL,
    [NumeTestProgramat] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Raspunsuris'
CREATE TABLE [dbo].[Raspunsuris] (
    [IdRaspuns] int IDENTITY(1,1) NOT NULL,
    [Raspuns] nvarchar(max)  NOT NULL,
    [RaspunsCorect] int  NOT NULL,
    [MotivareRaspuns] nvarchar(max)  NOT NULL,
    [IntrebariIdIntrebare] int  NOT NULL
);
GO

-- Creating table 'TestCreatDeLectors'
CREATE TABLE [dbo].[TestCreatDeLectors] (
    [IdTest] int IDENTITY(1,1) NOT NULL,
    [NumeTest] nvarchar(max)  NOT NULL,
    [Timp] nvarchar(max)  NOT NULL,
    [LectoriIdLector] int  NOT NULL,
    [NrIntrebari] int  NOT NULL
);
GO

-- Creating table 'TesteSalvateInBazaDeDates'
CREATE TABLE [dbo].[TesteSalvateInBazaDeDates] (
    [CursantiIdCursant] int  NOT NULL,
    [IntrebariIdIntrebare] int  NOT NULL,
    [TestCreatDeLectorIdTest] int  NOT NULL,
    [Raspuns] nvarchar(5)  NOT NULL,
    [MotivareRaspuns] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCapitol] in table 'Capitoles'
ALTER TABLE [dbo].[Capitoles]
ADD CONSTRAINT [PK_Capitoles]
    PRIMARY KEY CLUSTERED ([IdCapitol] ASC);
GO

-- Creating primary key on [IdCursant] in table 'Cursantis'
ALTER TABLE [dbo].[Cursantis]
ADD CONSTRAINT [PK_Cursantis]
    PRIMARY KEY CLUSTERED ([IdCursant] ASC);
GO

-- Creating primary key on [IdDisciplina] in table 'Disciplinas'
ALTER TABLE [dbo].[Disciplinas]
ADD CONSTRAINT [PK_Disciplinas]
    PRIMARY KEY CLUSTERED ([IdDisciplina] ASC);
GO

-- Creating primary key on [IdIntrebare] in table 'Intrebaris'
ALTER TABLE [dbo].[Intrebaris]
ADD CONSTRAINT [PK_Intrebaris]
    PRIMARY KEY CLUSTERED ([IdIntrebare] ASC);
GO

-- Creating primary key on [Id] in table 'IntrebariTestes'
ALTER TABLE [dbo].[IntrebariTestes]
ADD CONSTRAINT [PK_IntrebariTestes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdIstoricTeste] in table 'IstoricTesteCreateDeLectoris'
ALTER TABLE [dbo].[IstoricTesteCreateDeLectoris]
ADD CONSTRAINT [PK_IstoricTesteCreateDeLectoris]
    PRIMARY KEY CLUSTERED ([IdIstoricTeste] ASC);
GO

-- Creating primary key on [Id] in table 'IstoricTesteRezolvateNerezolvateDeCursants'
ALTER TABLE [dbo].[IstoricTesteRezolvateNerezolvateDeCursants]
ADD CONSTRAINT [PK_IstoricTesteRezolvateNerezolvateDeCursants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdLector] in table 'Lectoris'
ALTER TABLE [dbo].[Lectoris]
ADD CONSTRAINT [PK_Lectoris]
    PRIMARY KEY CLUSTERED ([IdLector] ASC);
GO

-- Creating primary key on [Id] in table 'ListaCursantiTestProgramats'
ALTER TABLE [dbo].[ListaCursantiTestProgramats]
ADD CONSTRAINT [PK_ListaCursantiTestProgramats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgramareTests'
ALTER TABLE [dbo].[ProgramareTests]
ADD CONSTRAINT [PK_ProgramareTests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdRaspuns] in table 'Raspunsuris'
ALTER TABLE [dbo].[Raspunsuris]
ADD CONSTRAINT [PK_Raspunsuris]
    PRIMARY KEY CLUSTERED ([IdRaspuns] ASC);
GO

-- Creating primary key on [IdTest] in table 'TestCreatDeLectors'
ALTER TABLE [dbo].[TestCreatDeLectors]
ADD CONSTRAINT [PK_TestCreatDeLectors]
    PRIMARY KEY CLUSTERED ([IdTest] ASC);
GO

-- Creating primary key on [CursantiIdCursant], [IntrebariIdIntrebare], [TestCreatDeLectorIdTest] in table 'TesteSalvateInBazaDeDates'
ALTER TABLE [dbo].[TesteSalvateInBazaDeDates]
ADD CONSTRAINT [PK_TesteSalvateInBazaDeDates]
    PRIMARY KEY CLUSTERED ([CursantiIdCursant], [IntrebariIdIntrebare], [TestCreatDeLectorIdTest] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CapitoleIdCapitol] in table 'Intrebaris'
ALTER TABLE [dbo].[Intrebaris]
ADD CONSTRAINT [FK_CapitoleIntrebari]
    FOREIGN KEY ([CapitoleIdCapitol])
    REFERENCES [dbo].[Capitoles]
        ([IdCapitol])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CapitoleIntrebari'
CREATE INDEX [IX_FK_CapitoleIntrebari]
ON [dbo].[Intrebaris]
    ([CapitoleIdCapitol]);
GO

-- Creating foreign key on [DisciplinaIdDisciplina] in table 'Capitoles'
ALTER TABLE [dbo].[Capitoles]
ADD CONSTRAINT [FK_DisciplinaCapitole]
    FOREIGN KEY ([DisciplinaIdDisciplina])
    REFERENCES [dbo].[Disciplinas]
        ([IdDisciplina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisciplinaCapitole'
CREATE INDEX [IX_FK_DisciplinaCapitole]
ON [dbo].[Capitoles]
    ([DisciplinaIdDisciplina]);
GO

-- Creating foreign key on [CursantiIdCursant] in table 'IstoricTesteRezolvateNerezolvateDeCursants'
ALTER TABLE [dbo].[IstoricTesteRezolvateNerezolvateDeCursants]
ADD CONSTRAINT [FK_CursantiIstoricTesteRezolvateNerezolvateDeCursant]
    FOREIGN KEY ([CursantiIdCursant])
    REFERENCES [dbo].[Cursantis]
        ([IdCursant])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursantiIstoricTesteRezolvateNerezolvateDeCursant'
CREATE INDEX [IX_FK_CursantiIstoricTesteRezolvateNerezolvateDeCursant]
ON [dbo].[IstoricTesteRezolvateNerezolvateDeCursants]
    ([CursantiIdCursant]);
GO

-- Creating foreign key on [CursantiIdCursant] in table 'ListaCursantiTestProgramats'
ALTER TABLE [dbo].[ListaCursantiTestProgramats]
ADD CONSTRAINT [FK_CursantiListaCursantiTestProgramat]
    FOREIGN KEY ([CursantiIdCursant])
    REFERENCES [dbo].[Cursantis]
        ([IdCursant])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursantiListaCursantiTestProgramat'
CREATE INDEX [IX_FK_CursantiListaCursantiTestProgramat]
ON [dbo].[ListaCursantiTestProgramats]
    ([CursantiIdCursant]);
GO

-- Creating foreign key on [CursantiIdCursant] in table 'TesteSalvateInBazaDeDates'
ALTER TABLE [dbo].[TesteSalvateInBazaDeDates]
ADD CONSTRAINT [FK_CursantiTesteSalvateInBazaDeDate]
    FOREIGN KEY ([CursantiIdCursant])
    REFERENCES [dbo].[Cursantis]
        ([IdCursant])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DisciplinaIdDisciplina] in table 'Cursantis'
ALTER TABLE [dbo].[Cursantis]
ADD CONSTRAINT [FK_DisciplinaCursanti]
    FOREIGN KEY ([DisciplinaIdDisciplina])
    REFERENCES [dbo].[Disciplinas]
        ([IdDisciplina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisciplinaCursanti'
CREATE INDEX [IX_FK_DisciplinaCursanti]
ON [dbo].[Cursantis]
    ([DisciplinaIdDisciplina]);
GO

-- Creating foreign key on [DisciplinaIdDisciplina] in table 'Lectoris'
ALTER TABLE [dbo].[Lectoris]
ADD CONSTRAINT [FK_DisciplinaLectori]
    FOREIGN KEY ([DisciplinaIdDisciplina])
    REFERENCES [dbo].[Disciplinas]
        ([IdDisciplina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DisciplinaLectori'
CREATE INDEX [IX_FK_DisciplinaLectori]
ON [dbo].[Lectoris]
    ([DisciplinaIdDisciplina]);
GO

-- Creating foreign key on [IntrebariIdIntrebare] in table 'IntrebariTestes'
ALTER TABLE [dbo].[IntrebariTestes]
ADD CONSTRAINT [FK_IntrebariIntrebariTeste]
    FOREIGN KEY ([IntrebariIdIntrebare])
    REFERENCES [dbo].[Intrebaris]
        ([IdIntrebare])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IntrebariIntrebariTeste'
CREATE INDEX [IX_FK_IntrebariIntrebariTeste]
ON [dbo].[IntrebariTestes]
    ([IntrebariIdIntrebare]);
GO

-- Creating foreign key on [IntrebariIdIntrebare] in table 'Raspunsuris'
ALTER TABLE [dbo].[Raspunsuris]
ADD CONSTRAINT [FK_IntrebariRaspunsuri]
    FOREIGN KEY ([IntrebariIdIntrebare])
    REFERENCES [dbo].[Intrebaris]
        ([IdIntrebare])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IntrebariRaspunsuri'
CREATE INDEX [IX_FK_IntrebariRaspunsuri]
ON [dbo].[Raspunsuris]
    ([IntrebariIdIntrebare]);
GO

-- Creating foreign key on [IntrebariIdIntrebare] in table 'TesteSalvateInBazaDeDates'
ALTER TABLE [dbo].[TesteSalvateInBazaDeDates]
ADD CONSTRAINT [FK_IntrebariTesteSalvateInBazaDeDate]
    FOREIGN KEY ([IntrebariIdIntrebare])
    REFERENCES [dbo].[Intrebaris]
        ([IdIntrebare])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IntrebariTesteSalvateInBazaDeDate'
CREATE INDEX [IX_FK_IntrebariTesteSalvateInBazaDeDate]
ON [dbo].[TesteSalvateInBazaDeDates]
    ([IntrebariIdIntrebare]);
GO

-- Creating foreign key on [TestCreatDeLectorIdTest] in table 'IntrebariTestes'
ALTER TABLE [dbo].[IntrebariTestes]
ADD CONSTRAINT [FK_TestCreatDeLectorIntrebariTeste]
    FOREIGN KEY ([TestCreatDeLectorIdTest])
    REFERENCES [dbo].[TestCreatDeLectors]
        ([IdTest])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestCreatDeLectorIntrebariTeste'
CREATE INDEX [IX_FK_TestCreatDeLectorIntrebariTeste]
ON [dbo].[IntrebariTestes]
    ([TestCreatDeLectorIdTest]);
GO

-- Creating foreign key on [TestCreatDeLectorIdTest] in table 'IstoricTesteCreateDeLectoris'
ALTER TABLE [dbo].[IstoricTesteCreateDeLectoris]
ADD CONSTRAINT [FK_TestCreatDeLectorIstoricTesteCreateDeLectori]
    FOREIGN KEY ([TestCreatDeLectorIdTest])
    REFERENCES [dbo].[TestCreatDeLectors]
        ([IdTest])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestCreatDeLectorIstoricTesteCreateDeLectori'
CREATE INDEX [IX_FK_TestCreatDeLectorIstoricTesteCreateDeLectori]
ON [dbo].[IstoricTesteCreateDeLectoris]
    ([TestCreatDeLectorIdTest]);
GO

-- Creating foreign key on [TestCreatDeLectorIdTest] in table 'IstoricTesteRezolvateNerezolvateDeCursants'
ALTER TABLE [dbo].[IstoricTesteRezolvateNerezolvateDeCursants]
ADD CONSTRAINT [FK_TestCreatDeLectorIstoricTesteRezolvateNerezolvateDeCursant]
    FOREIGN KEY ([TestCreatDeLectorIdTest])
    REFERENCES [dbo].[TestCreatDeLectors]
        ([IdTest])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestCreatDeLectorIstoricTesteRezolvateNerezolvateDeCursant'
CREATE INDEX [IX_FK_TestCreatDeLectorIstoricTesteRezolvateNerezolvateDeCursant]
ON [dbo].[IstoricTesteRezolvateNerezolvateDeCursants]
    ([TestCreatDeLectorIdTest]);
GO

-- Creating foreign key on [LectoriIdLector] in table 'TestCreatDeLectors'
ALTER TABLE [dbo].[TestCreatDeLectors]
ADD CONSTRAINT [FK_LectoriTestCreatDeLector]
    FOREIGN KEY ([LectoriIdLector])
    REFERENCES [dbo].[Lectoris]
        ([IdLector])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LectoriTestCreatDeLector'
CREATE INDEX [IX_FK_LectoriTestCreatDeLector]
ON [dbo].[TestCreatDeLectors]
    ([LectoriIdLector]);
GO

-- Creating foreign key on [ProgramareTestId] in table 'ListaCursantiTestProgramats'
ALTER TABLE [dbo].[ListaCursantiTestProgramats]
ADD CONSTRAINT [FK_ProgramareTestListaCursantiTestProgramat]
    FOREIGN KEY ([ProgramareTestId])
    REFERENCES [dbo].[ProgramareTests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgramareTestListaCursantiTestProgramat'
CREATE INDEX [IX_FK_ProgramareTestListaCursantiTestProgramat]
ON [dbo].[ListaCursantiTestProgramats]
    ([ProgramareTestId]);
GO

-- Creating foreign key on [TestCreatDeLectorIdTest] in table 'ProgramareTests'
ALTER TABLE [dbo].[ProgramareTests]
ADD CONSTRAINT [FK_TestCreatDeLectorProgramareTest]
    FOREIGN KEY ([TestCreatDeLectorIdTest])
    REFERENCES [dbo].[TestCreatDeLectors]
        ([IdTest])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestCreatDeLectorProgramareTest'
CREATE INDEX [IX_FK_TestCreatDeLectorProgramareTest]
ON [dbo].[ProgramareTests]
    ([TestCreatDeLectorIdTest]);
GO

-- Creating foreign key on [TestCreatDeLectorIdTest] in table 'TesteSalvateInBazaDeDates'
ALTER TABLE [dbo].[TesteSalvateInBazaDeDates]
ADD CONSTRAINT [FK_TestCreatDeLectorTesteSalvateInBazaDeDate]
    FOREIGN KEY ([TestCreatDeLectorIdTest])
    REFERENCES [dbo].[TestCreatDeLectors]
        ([IdTest])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestCreatDeLectorTesteSalvateInBazaDeDate'
CREATE INDEX [IX_FK_TestCreatDeLectorTesteSalvateInBazaDeDate]
ON [dbo].[TesteSalvateInBazaDeDates]
    ([TestCreatDeLectorIdTest]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------