﻿/*
Deployment script for ObservationsTest

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ObservationsTest"
:setvar DefaultFilePrefix "ObservationsTest"
:setvar DefaultDataPath "D:\Program Files\Microsoft SQL Server\MSSQL14.SAEON\MSSQL\DATA\"
:setvar DefaultLogPath "D:\Program Files\Microsoft SQL Server\MSSQL14.SAEON\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];

GO
PRINT N'Dropping [dbo].[UX_UserDownloads_UserId_Name]...';


GO
ALTER TABLE [dbo].[UserDownloads] DROP CONSTRAINT [UX_UserDownloads_UserId_Name];


GO
PRINT N'Dropping [dbo].[UX_UserQueries_UserId_Name]...';


GO
ALTER TABLE [dbo].[UserQueries] DROP CONSTRAINT [UX_UserQueries_UserId_Name];


GO
PRINT N'Altering [dbo].[ImportBatchSummary]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[ImportBatchSummary] DROP COLUMN [BottomLatitude], COLUMN [LeftLongitude], COLUMN [RightLongitude], COLUMN [TopLatitude];


GO
ALTER TABLE [dbo].[ImportBatchSummary]
    ADD [LatitudeNorth]    FLOAT (53) NULL,
        [LatitudeSouth]    FLOAT (53) NULL,
        [LongitudeWest]    FLOAT (53) NULL,
        [LongitudeEast]    FLOAT (53) NULL,
        [ElevationMinimum] FLOAT (53) NULL,
        [ElevationMaximum] FLOAT (53) NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering [dbo].[UserDownloads]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[UserDownloads] DROP COLUMN [DOI], COLUMN [QueryInput], COLUMN [QueryURL];


GO
ALTER TABLE [dbo].[UserDownloads] ALTER COLUMN [AddedBy] VARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[UserDownloads] ALTER COLUMN [Citation] VARCHAR (5000) NOT NULL;

ALTER TABLE [dbo].[UserDownloads] ALTER COLUMN [Description] VARCHAR (5000) NOT NULL;

ALTER TABLE [dbo].[UserDownloads] ALTER COLUMN [UpdatedBy] VARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[UserDownloads] ALTER COLUMN [UserId] VARCHAR (128) NOT NULL;


GO
ALTER TABLE [dbo].[UserDownloads]
    ADD [Title]                     VARCHAR (5000) NOT NULL,
        [Keywords]                  VARCHAR (1000) NOT NULL,
        [Date]                      DATETIME       NOT NULL,
        [Input]                     VARCHAR (5000) NOT NULL,
        [RequeryURL]                VARCHAR (5000) NOT NULL,
        [DigitalObjectIdentifierID] INT            NOT NULL,
        [MetadataJson]              VARCHAR (Max) NOT NULL,
        [ZipFullName]               VARCHAR (2000) NOT NULL,
        [ZipCheckSum]               VARCHAR (64)   NOT NULL,
        [ZipURL]                    VARCHAR (2000) NOT NULL,
        [Places]                    VARCHAR (5000) NULL,
        [LatitudeNorth]             FLOAT (53)     NULL,
        [LatitudeSouth]             FLOAT (53)     NULL,
        [LongitudeWest]             FLOAT (53)     NULL,
        [LongitudeEast]             FLOAT (53)     NULL,
        [ElevationMinimum]          FLOAT (53)     NULL,
        [ElevationMaximum]          FLOAT (53)     NULL,
        [StartDate]                 DATETIME       NULL,
        [EndDate]                   DATETIME       NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[UX_UserDownloads_UserId_Name]...';


GO
ALTER TABLE [dbo].[UserDownloads]
    ADD CONSTRAINT [UX_UserDownloads_UserId_Name] UNIQUE NONCLUSTERED ([UserId] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[UserDownloads].[IX_UserDownloads_DOI]...';


GO
CREATE NONCLUSTERED INDEX [IX_UserDownloads_DOI]
    ON [dbo].[UserDownloads]([DigitalObjectIdentifierID] ASC);


GO
PRINT N'Altering [dbo].[UserQueries]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[UserQueries] ALTER COLUMN [AddedBy] VARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[UserQueries] ALTER COLUMN [UpdatedBy] VARCHAR (128) NOT NULL;

ALTER TABLE [dbo].[UserQueries] ALTER COLUMN [UserId] VARCHAR (128) NOT NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[UX_UserQueries_UserId_Name]...';


GO
ALTER TABLE [dbo].[UserQueries]
    ADD CONSTRAINT [UX_UserQueries_UserId_Name] UNIQUE NONCLUSTERED ([UserId] ASC, [Name] ASC);


GO
PRINT N'Creating [dbo].[DigitalObjectIdentifiers]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE TABLE [dbo].[DigitalObjectIdentifiers] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [DOI]        AS             '10.15493/obsdb.' + Stuff(CONVERT (VARCHAR (20), CONVERT (VARBINARY (4), ID), 2), 5, 0, '.'),
    [DOIUrl]     AS             'https://doi.org/10.15493/obsdb.' + Stuff(CONVERT (VARCHAR (20), CONVERT (VARBINARY (4), ID), 2), 5, 0, '.'),
    [Name]       VARCHAR (1000) NULL,
    [AddedAt]    DATETIME       NULL,
    [AddedBy]    VARCHAR (128)  NOT NULL,
    [UpdatedAt]  DATETIME       NULL,
    [UpdatedBy]  VARCHAR (128)  NOT NULL,
    [RowVersion] ROWVERSION     NOT NULL,
    CONSTRAINT [PK_DigitalObjectIdentifiers] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[DigitalObjectIdentifiers].[IX_DigitalObjectIdentifiers_Name]...';


GO
CREATE NONCLUSTERED INDEX [IX_DigitalObjectIdentifiers_Name]
    ON [dbo].[DigitalObjectIdentifiers]([Name] ASC);


GO
PRINT N'Creating [dbo].[DF_DigitalObjectIdentifiers_AddedAt]...';


GO
ALTER TABLE [dbo].[DigitalObjectIdentifiers]
    ADD CONSTRAINT [DF_DigitalObjectIdentifiers_AddedAt] DEFAULT (getdate()) FOR [AddedAt];


GO
PRINT N'Creating [dbo].[DF_DigitalObjectIdentifiers_UpdatedAt]...';


GO
ALTER TABLE [dbo].[DigitalObjectIdentifiers]
    ADD CONSTRAINT [DF_DigitalObjectIdentifiers_UpdatedAt] DEFAULT (getdate()) FOR [UpdatedAt];


GO
PRINT N'Creating [dbo].[FK_UserDownloads_DigitalObjectIdentifiers]...';


GO
ALTER TABLE [dbo].[UserDownloads] WITH NOCHECK
    ADD CONSTRAINT [FK_UserDownloads_DigitalObjectIdentifiers] FOREIGN KEY ([DigitalObjectIdentifierID]) REFERENCES [dbo].[DigitalObjectIdentifiers] ([ID]);


GO
PRINT N'Creating [dbo].[TR_DigitalObjectIdentifiers_Insert]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE TRIGGER [dbo].[TR_DigitalObjectIdentifiers_Insert] ON [dbo].[DigitalObjectIdentifiers]
FOR INSERT
AS
BEGIN
  SET NoCount ON
  Update
      src
  set
      AddedAt = GetDate(),
      UpdatedAt = NULL
  from
    DigitalObjectIdentifiers src
    inner join inserted ins
      on (ins.ID = src.ID)
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[TR_DigitalObjectIdentifiers_Update]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE TRIGGER [dbo].[TR_DigitalObjectIdentifiers_Update] ON [dbo].[DigitalObjectIdentifiers]
FOR UPDATE
AS
BEGIN
  SET NoCount ON
  Update
      src
  set
    AddedAt = Coalesce(del.AddedAt, ins.AddedAt, GetDate()),
    UpdatedAt = GetDate()
  from
    DigitalObjectIdentifiers src
    inner join inserted ins
      on (ins.ID = src.ID)
    inner join deleted del
      on (del.ID = src.ID)
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vFeatures]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vFeatures]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vImportBatchSummary]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vImportBatchSummary]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vLocations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vLocations]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering [dbo].[vInventory]...';


GO
ALTER VIEW [dbo].[vInventory]
AS
Select
  Row_Number() over (order by SiteName, StationName, InstrumentName, SensorName, PhenomenonName, OfferingName, UnitOfMeasureUnit) ID, s.*
from
(
Select
  SiteID, SiteCode, SiteName, 
  StationID, StationCode, StationName, 
  InstrumentID, InstrumentCode, InstrumentName, 
  SensorID, SensorCode, SensorName, 
  PhenomenonCode, PhenomenonName, 
  PhenomenonOfferingID, OfferingCode, OfferingName, 
  PhenomenonUOMID, UnitOfMeasureCode, UnitOfMeasureUnit, 
  Sum(Count) Count, Min(StartDate) StartDate, Max(EndDate) EndDate,
  Max(LatitudeNorth) LatitudeNorth, Min(LatitudeSouth) LatitudeSouth,
  Min(LongitudeWest) LongitudeWest, Max(LongitudeEast) LongitudeEast
from
  vImportBatchSummary
group by
  SiteID, SiteCode, SiteName, StationID, StationCode, StationName, InstrumentID, InstrumentCode, InstrumentName, 
  SensorID, SensorCode, SensorName, PhenomenonCode, PhenomenonName, 
  PhenomenonOfferingID, OfferingCode, OfferingName, 
  PhenomenonUOMID, UnitOfMeasureCode, UnitOfMeasureUnit
) s
GO
PRINT N'Creating [dbo].[vUserDownloads]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vUserDownloads]
AS 
SELECT 
  UserDownloads.*, DOI, DOIUrl
FROM 
  UserDownloads
  inner join DigitalObjectIdentifiers
    on (UserDownloads.DigitalObjectIdentifierID = DigitalObjectIdentifiers.ID)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[UserDownloads] WITH CHECK CHECK CONSTRAINT [FK_UserDownloads_DigitalObjectIdentifiers];


GO
PRINT N'Update complete.';


GO
