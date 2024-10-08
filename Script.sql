
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2024 00:30:39
-- Generated from EDMX file: D:\Project\NET\Apartman-Yonetim-Sistemi\Site Y�netim Sistemi\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [siteyonetimsistemi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_aidatAy_aidatlar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aidatAy] DROP CONSTRAINT [FK_aidatAy_aidatlar];
GO
IF OBJECT_ID(N'[dbo].[FK_aidatlar_uye]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aidatlar] DROP CONSTRAINT [FK_aidatlar_uye];
GO
IF OBJECT_ID(N'[dbo].[FK_anket_yonetici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[anket] DROP CONSTRAINT [FK_anket_yonetici];
GO
IF OBJECT_ID(N'[dbo].[FK_AnketiGorenler_anket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AnketiGorenler] DROP CONSTRAINT [FK_AnketiGorenler_anket];
GO
IF OBJECT_ID(N'[dbo].[FK_anketSonuclari_anket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[anketSonuclari] DROP CONSTRAINT [FK_anketSonuclari_anket];
GO
IF OBJECT_ID(N'[dbo].[FK_anketSorulari_anket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[anketSorulari] DROP CONSTRAINT [FK_anketSorulari_anket];
GO
IF OBJECT_ID(N'[dbo].[FK_aracbilgisi_daireSakini]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[aracbilgisi] DROP CONSTRAINT [FK_aracbilgisi_daireSakini];
GO
IF OBJECT_ID(N'[dbo].[FK_daireSakini_uye1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[daireSakini] DROP CONSTRAINT [FK_daireSakini_uye1];
GO
IF OBJECT_ID(N'[dbo].[FK_dogalGaz_fatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[dogalGaz] DROP CONSTRAINT [FK_dogalGaz_fatura];
GO
IF OBJECT_ID(N'[dbo].[FK_duyurular_yonetici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[duyurular] DROP CONSTRAINT [FK_duyurular_yonetici];
GO
IF OBJECT_ID(N'[dbo].[FK_elektrik_fatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[elektrik] DROP CONSTRAINT [FK_elektrik_fatura];
GO
IF OBJECT_ID(N'[dbo].[FK_fatura_uye]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[fatura] DROP CONSTRAINT [FK_fatura_uye];
GO
IF OBJECT_ID(N'[dbo].[FK_gelenMesaj_mesaj]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gelenMesaj] DROP CONSTRAINT [FK_gelenMesaj_mesaj];
GO
IF OBJECT_ID(N'[dbo].[FK_guvenlik_apartman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[guvenlik] DROP CONSTRAINT [FK_guvenlik_apartman];
GO
IF OBJECT_ID(N'[dbo].[FK_mesaj_uye]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[mesaj] DROP CONSTRAINT [FK_mesaj_uye];
GO
IF OBJECT_ID(N'[dbo].[FK_resimler_kullanici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[resimler] DROP CONSTRAINT [FK_resimler_kullanici];
GO
IF OBJECT_ID(N'[dbo].[FK_su_fatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[su] DROP CONSTRAINT [FK_su_fatura];
GO
IF OBJECT_ID(N'[dbo].[FK_uye_apartman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[uye] DROP CONSTRAINT [FK_uye_apartman];
GO
IF OBJECT_ID(N'[dbo].[FK_uye_kullanici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[uye] DROP CONSTRAINT [FK_uye_kullanici];
GO
IF OBJECT_ID(N'[dbo].[FK_yonetici_kullanici]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[yonetici] DROP CONSTRAINT [FK_yonetici_kullanici];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[aidatAy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aidatAy];
GO
IF OBJECT_ID(N'[dbo].[aidatlar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aidatlar];
GO
IF OBJECT_ID(N'[dbo].[anket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[anket];
GO
IF OBJECT_ID(N'[dbo].[AnketiGorenler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnketiGorenler];
GO
IF OBJECT_ID(N'[dbo].[anketSonuclari]', 'U') IS NOT NULL
    DROP TABLE [dbo].[anketSonuclari];
GO
IF OBJECT_ID(N'[dbo].[anketSorulari]', 'U') IS NOT NULL
    DROP TABLE [dbo].[anketSorulari];
GO
IF OBJECT_ID(N'[dbo].[apartman]', 'U') IS NOT NULL
    DROP TABLE [dbo].[apartman];
GO
IF OBJECT_ID(N'[dbo].[aracbilgisi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aracbilgisi];
GO
IF OBJECT_ID(N'[dbo].[daireSakini]', 'U') IS NOT NULL
    DROP TABLE [dbo].[daireSakini];
GO
IF OBJECT_ID(N'[dbo].[dogalGaz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dogalGaz];
GO
IF OBJECT_ID(N'[dbo].[duyurular]', 'U') IS NOT NULL
    DROP TABLE [dbo].[duyurular];
GO
IF OBJECT_ID(N'[dbo].[elektrik]', 'U') IS NOT NULL
    DROP TABLE [dbo].[elektrik];
GO
IF OBJECT_ID(N'[dbo].[fatura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[fatura];
GO
IF OBJECT_ID(N'[dbo].[gelenMesaj]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gelenMesaj];
GO
IF OBJECT_ID(N'[dbo].[guvenlik]', 'U') IS NOT NULL
    DROP TABLE [dbo].[guvenlik];
GO
IF OBJECT_ID(N'[dbo].[kullanici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[kullanici];
GO
IF OBJECT_ID(N'[dbo].[mesaj]', 'U') IS NOT NULL
    DROP TABLE [dbo].[mesaj];
GO
IF OBJECT_ID(N'[dbo].[resimler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[resimler];
GO
IF OBJECT_ID(N'[dbo].[su]', 'U') IS NOT NULL
    DROP TABLE [dbo].[su];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[uye]', 'U') IS NOT NULL
    DROP TABLE [dbo].[uye];
GO
IF OBJECT_ID(N'[dbo].[yonetici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[yonetici];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'aidatAys'
CREATE TABLE [dbo].[aidatAys] (
    [id] int IDENTITY(1,1) NOT NULL,
    [aidatId] int  NULL,
    [ay] int  NULL
);
GO

-- Creating table 'aidatlars'
CREATE TABLE [dbo].[aidatlars] (
    [id] int  NOT NULL
);
GO

-- Creating table 'ankets'
CREATE TABLE [dbo].[ankets] (
    [id] int IDENTITY(1,1) NOT NULL,
    [anketKonusu] nvarchar(50)  NULL,
    [yoneticiId] int  NULL
);
GO

-- Creating table 'AnketiGorenlers'
CREATE TABLE [dbo].[AnketiGorenlers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [uyeId] int  NULL,
    [anketId] int  NULL
);
GO

-- Creating table 'anketSonuclaris'
CREATE TABLE [dbo].[anketSonuclaris] (
    [id] int  NOT NULL,
    [s1] int  NULL,
    [s2] int  NULL,
    [s3] int  NULL,
    [s4] int  NULL,
    [s5] int  NULL,
    [kisiSayisi] int  NULL
);
GO

-- Creating table 'anketSorularis'
CREATE TABLE [dbo].[anketSorularis] (
    [id] int IDENTITY(1,1) NOT NULL,
    [soru] nvarchar(200)  NULL,
    [anketId] int  NULL
);
GO

-- Creating table 'apartmen'
CREATE TABLE [dbo].[apartmen] (
    [id] int IDENTITY(1,1) NOT NULL,
    [apartmanAdi] nvarchar(50)  NULL,
    [apartmanBlok] char(2)  NULL,
    [katSayisi] int  NULL,
    [apartmanYoneticisi] int  NULL,
    [daireSayisi] int  NULL,
    [aidat] int  NULL
);
GO

-- Creating table 'aracbilgisis'
CREATE TABLE [dbo].[aracbilgisis] (
    [id] int IDENTITY(1,1) NOT NULL,
    [aracTipi] nvarchar(50)  NULL,
    [plaka] nvarchar(50)  NULL,
    [uyeId] int  NULL,
    [aracSahibi] int  NULL
);
GO

-- Creating table 'daireSakinis'
CREATE TABLE [dbo].[daireSakinis] (
    [id] int IDENTITY(1,1) NOT NULL,
    [uyeId] int  NULL,
    [ad] nvarchar(50)  NULL,
    [soyAd] nvarchar(50)  NULL,
    [yas] int  NULL
);
GO

-- Creating table 'dogalGazs'
CREATE TABLE [dbo].[dogalGazs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [faturaId] int  NULL,
    [miktar] int  NULL,
    [yil] int  NULL,
    [ay] int  NULL,
    [faturaNo] int  NULL,
    [sonOdemeTarihi] datetime  NULL,
    [odenme] int  NULL
);
GO

-- Creating table 'duyurulars'
CREATE TABLE [dbo].[duyurulars] (
    [id] int IDENTITY(1,1) NOT NULL,
    [duyurAdi] nvarchar(50)  NULL,
    [duyuruKonusu] nvarchar(50)  NULL,
    [yoneticiId] int  NULL
);
GO

-- Creating table 'elektriks'
CREATE TABLE [dbo].[elektriks] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fatura�d] int  NULL,
    [miktar] int  NULL,
    [yil] int  NULL,
    [ay] int  NULL,
    [faturaNo] int  NULL,
    [sonOdemeTarihi] datetime  NULL,
    [odenme] int  NULL
);
GO

-- Creating table 'faturas'
CREATE TABLE [dbo].[faturas] (
    [id] int  NOT NULL
);
GO

-- Creating table 'gelenMesajs'
CREATE TABLE [dbo].[gelenMesajs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [gidenId] int  NULL,
    [mesaj] nvarchar(1000)  NULL,
    [mesajId] int  NULL,
    [gelenId] int  NULL,
    [oncelik] int  NULL
);
GO

-- Creating table 'guvenliks'
CREATE TABLE [dbo].[guvenliks] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Ad] nvarchar(50)  NULL,
    [Soyad] nchar(10)  NULL,
    [telno] char(11)  NULL,
    [apartmanId] int  NULL
);
GO

-- Creating table 'kullanicis'
CREATE TABLE [dbo].[kullanicis] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ad] nvarchar(50)  NULL,
    [soyAd] nvarchar(50)  NULL,
    [dogumTarihi] datetime  NULL,
    [cinsiyet] char(1)  NULL,
    [mailAdresi] nvarchar(50)  NULL,
    [telefon] char(11)  NULL,
    [medeniDurum] char(1)  NULL,
    [sifre] nvarchar(50)  NULL,
    [tipAdi] nvarchar(50)  NULL,
    [kAdi] nvarchar(50)  NULL
);
GO

-- Creating table 'mesajs'
CREATE TABLE [dbo].[mesajs] (
    [id] int  NOT NULL
);
GO

-- Creating table 'resimlers'
CREATE TABLE [dbo].[resimlers] (
    [id] int  NOT NULL,
    [resimAd] nvarchar(50)  NULL,
    [resim] varbinary(max)  NULL
);
GO

-- Creating table 'sus'
CREATE TABLE [dbo].[sus] (
    [id] int IDENTITY(1,1) NOT NULL,
    [faturaId] int  NULL,
    [miiktar] int  NULL,
    [yil] int  NULL,
    [ay] int  NULL,
    [faturaNo] int  NULL,
    [sonOdemeTarihi] datetime  NULL,
    [odenme] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'uyes'
CREATE TABLE [dbo].[uyes] (
    [Id] int  NOT NULL,
    [apartmanId] int  NULL,
    [kat] int  NULL,
    [daireNo] int  NULL,
    [aracSayisi] int  NULL,
    [aracId] int  NULL
);
GO

-- Creating table 'yoneticis'
CREATE TABLE [dbo].[yoneticis] (
    [id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'aidatAys'
ALTER TABLE [dbo].[aidatAys]
ADD CONSTRAINT [PK_aidatAys]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'aidatlars'
ALTER TABLE [dbo].[aidatlars]
ADD CONSTRAINT [PK_aidatlars]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ankets'
ALTER TABLE [dbo].[ankets]
ADD CONSTRAINT [PK_ankets]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AnketiGorenlers'
ALTER TABLE [dbo].[AnketiGorenlers]
ADD CONSTRAINT [PK_AnketiGorenlers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'anketSonuclaris'
ALTER TABLE [dbo].[anketSonuclaris]
ADD CONSTRAINT [PK_anketSonuclaris]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'anketSorularis'
ALTER TABLE [dbo].[anketSorularis]
ADD CONSTRAINT [PK_anketSorularis]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'apartmen'
ALTER TABLE [dbo].[apartmen]
ADD CONSTRAINT [PK_apartmen]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'aracbilgisis'
ALTER TABLE [dbo].[aracbilgisis]
ADD CONSTRAINT [PK_aracbilgisis]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'daireSakinis'
ALTER TABLE [dbo].[daireSakinis]
ADD CONSTRAINT [PK_daireSakinis]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'dogalGazs'
ALTER TABLE [dbo].[dogalGazs]
ADD CONSTRAINT [PK_dogalGazs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'duyurulars'
ALTER TABLE [dbo].[duyurulars]
ADD CONSTRAINT [PK_duyurulars]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'elektriks'
ALTER TABLE [dbo].[elektriks]
ADD CONSTRAINT [PK_elektriks]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'faturas'
ALTER TABLE [dbo].[faturas]
ADD CONSTRAINT [PK_faturas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'gelenMesajs'
ALTER TABLE [dbo].[gelenMesajs]
ADD CONSTRAINT [PK_gelenMesajs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'guvenliks'
ALTER TABLE [dbo].[guvenliks]
ADD CONSTRAINT [PK_guvenliks]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'kullanicis'
ALTER TABLE [dbo].[kullanicis]
ADD CONSTRAINT [PK_kullanicis]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'mesajs'
ALTER TABLE [dbo].[mesajs]
ADD CONSTRAINT [PK_mesajs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'resimlers'
ALTER TABLE [dbo].[resimlers]
ADD CONSTRAINT [PK_resimlers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'sus'
ALTER TABLE [dbo].[sus]
ADD CONSTRAINT [PK_sus]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'uyes'
ALTER TABLE [dbo].[uyes]
ADD CONSTRAINT [PK_uyes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'yoneticis'
ALTER TABLE [dbo].[yoneticis]
ADD CONSTRAINT [PK_yoneticis]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [aidatId] in table 'aidatAys'
ALTER TABLE [dbo].[aidatAys]
ADD CONSTRAINT [FK_aidatAy_aidatlar]
    FOREIGN KEY ([aidatId])
    REFERENCES [dbo].[aidatlars]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_aidatAy_aidatlar'
CREATE INDEX [IX_FK_aidatAy_aidatlar]
ON [dbo].[aidatAys]
    ([aidatId]);
GO

-- Creating foreign key on [id] in table 'aidatlars'
ALTER TABLE [dbo].[aidatlars]
ADD CONSTRAINT [FK_aidatlar_uye]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[uyes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [yoneticiId] in table 'ankets'
ALTER TABLE [dbo].[ankets]
ADD CONSTRAINT [FK_anket_yonetici]
    FOREIGN KEY ([yoneticiId])
    REFERENCES [dbo].[yoneticis]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_anket_yonetici'
CREATE INDEX [IX_FK_anket_yonetici]
ON [dbo].[ankets]
    ([yoneticiId]);
GO

-- Creating foreign key on [anketId] in table 'AnketiGorenlers'
ALTER TABLE [dbo].[AnketiGorenlers]
ADD CONSTRAINT [FK_AnketiGorenler_anket]
    FOREIGN KEY ([anketId])
    REFERENCES [dbo].[ankets]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnketiGorenler_anket'
CREATE INDEX [IX_FK_AnketiGorenler_anket]
ON [dbo].[AnketiGorenlers]
    ([anketId]);
GO

-- Creating foreign key on [id] in table 'anketSonuclaris'
ALTER TABLE [dbo].[anketSonuclaris]
ADD CONSTRAINT [FK_anketSonuclari_anket]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[ankets]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [anketId] in table 'anketSorularis'
ALTER TABLE [dbo].[anketSorularis]
ADD CONSTRAINT [FK_anketSorulari_anket]
    FOREIGN KEY ([anketId])
    REFERENCES [dbo].[ankets]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_anketSorulari_anket'
CREATE INDEX [IX_FK_anketSorulari_anket]
ON [dbo].[anketSorularis]
    ([anketId]);
GO

-- Creating foreign key on [apartmanId] in table 'guvenliks'
ALTER TABLE [dbo].[guvenliks]
ADD CONSTRAINT [FK_guvenlik_apartman]
    FOREIGN KEY ([apartmanId])
    REFERENCES [dbo].[apartmen]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_guvenlik_apartman'
CREATE INDEX [IX_FK_guvenlik_apartman]
ON [dbo].[guvenliks]
    ([apartmanId]);
GO

-- Creating foreign key on [apartmanId] in table 'uyes'
ALTER TABLE [dbo].[uyes]
ADD CONSTRAINT [FK_uye_apartman]
    FOREIGN KEY ([apartmanId])
    REFERENCES [dbo].[apartmen]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_uye_apartman'
CREATE INDEX [IX_FK_uye_apartman]
ON [dbo].[uyes]
    ([apartmanId]);
GO

-- Creating foreign key on [aracSahibi] in table 'aracbilgisis'
ALTER TABLE [dbo].[aracbilgisis]
ADD CONSTRAINT [FK_aracbilgisi_daireSakini]
    FOREIGN KEY ([aracSahibi])
    REFERENCES [dbo].[daireSakinis]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_aracbilgisi_daireSakini'
CREATE INDEX [IX_FK_aracbilgisi_daireSakini]
ON [dbo].[aracbilgisis]
    ([aracSahibi]);
GO

-- Creating foreign key on [uyeId] in table 'daireSakinis'
ALTER TABLE [dbo].[daireSakinis]
ADD CONSTRAINT [FK_daireSakini_uye1]
    FOREIGN KEY ([uyeId])
    REFERENCES [dbo].[uyes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_daireSakini_uye1'
CREATE INDEX [IX_FK_daireSakini_uye1]
ON [dbo].[daireSakinis]
    ([uyeId]);
GO

-- Creating foreign key on [faturaId] in table 'dogalGazs'
ALTER TABLE [dbo].[dogalGazs]
ADD CONSTRAINT [FK_dogalGaz_fatura]
    FOREIGN KEY ([faturaId])
    REFERENCES [dbo].[faturas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dogalGaz_fatura'
CREATE INDEX [IX_FK_dogalGaz_fatura]
ON [dbo].[dogalGazs]
    ([faturaId]);
GO

-- Creating foreign key on [yoneticiId] in table 'duyurulars'
ALTER TABLE [dbo].[duyurulars]
ADD CONSTRAINT [FK_duyurular_yonetici]
    FOREIGN KEY ([yoneticiId])
    REFERENCES [dbo].[yoneticis]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_duyurular_yonetici'
CREATE INDEX [IX_FK_duyurular_yonetici]
ON [dbo].[duyurulars]
    ([yoneticiId]);
GO

-- Creating foreign key on [fatura�d] in table 'elektriks'
ALTER TABLE [dbo].[elektriks]
ADD CONSTRAINT [FK_elektrik_fatura]
    FOREIGN KEY ([fatura�d])
    REFERENCES [dbo].[faturas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_elektrik_fatura'
CREATE INDEX [IX_FK_elektrik_fatura]
ON [dbo].[elektriks]
    ([fatura�d]);
GO

-- Creating foreign key on [id] in table 'faturas'
ALTER TABLE [dbo].[faturas]
ADD CONSTRAINT [FK_fatura_uye]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[uyes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [faturaId] in table 'sus'
ALTER TABLE [dbo].[sus]
ADD CONSTRAINT [FK_su_fatura]
    FOREIGN KEY ([faturaId])
    REFERENCES [dbo].[faturas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_su_fatura'
CREATE INDEX [IX_FK_su_fatura]
ON [dbo].[sus]
    ([faturaId]);
GO

-- Creating foreign key on [mesajId] in table 'gelenMesajs'
ALTER TABLE [dbo].[gelenMesajs]
ADD CONSTRAINT [FK_gelenMesaj_mesaj]
    FOREIGN KEY ([mesajId])
    REFERENCES [dbo].[mesajs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gelenMesaj_mesaj'
CREATE INDEX [IX_FK_gelenMesaj_mesaj]
ON [dbo].[gelenMesajs]
    ([mesajId]);
GO

-- Creating foreign key on [id] in table 'resimlers'
ALTER TABLE [dbo].[resimlers]
ADD CONSTRAINT [FK_resimler_kullanici]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[kullanicis]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'uyes'
ALTER TABLE [dbo].[uyes]
ADD CONSTRAINT [FK_uye_kullanici]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[kullanicis]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'yoneticis'
ALTER TABLE [dbo].[yoneticis]
ADD CONSTRAINT [FK_yonetici_kullanici]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[kullanicis]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'mesajs'
ALTER TABLE [dbo].[mesajs]
ADD CONSTRAINT [FK_mesaj_uye]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[uyes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

