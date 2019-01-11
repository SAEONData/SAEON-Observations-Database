﻿/*
Deployment script for Observations

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Observations"
:setvar DefaultFilePrefix "Observations"
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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Dropping [dbo].[UX_Observation]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [UX_Observation];


GO
PRINT N'Creating [dbo].[UX_Observation]...';


GO
ALTER TABLE [dbo].[Observation]
    ADD CONSTRAINT [UX_Observation] UNIQUE NONCLUSTERED ([SensorID] ASC, [ValueDate] ASC, [DataValue] ASC, [PhenomenonOfferingID] ASC, [PhenomenonUOMID] ASC) ON [Observations];


GO
PRINT N'Altering [dbo].[vObservationExpansion]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER VIEW [dbo].[vObservationExpansion]
AS
Select
  Observation.ID, Observation.ImportBatchID, ImportBatch.Code ImportBatchCode, ImportBatch.ImportDate ImportBatchDate, 
  Observation.ValueDate, Observation.ValueDay, Observation.ValueYear, Observation.ValueDecade, 
  Observation.RawValue, Observation.DataValue, Observation.TextValue, 
  Observation.Comment, Observation.CorrelationID,
  Site.ID SiteID, Site.Code SiteCode, Site.Name SiteName, Site.Description SiteDescription, Site.Url SiteUrl,
  Station.ID StationID, Station.Code StationCode, Station.Name StationName, Station.Description StationDescription, Station.Url StationUrl,
  Instrument.ID InstrumentID, Instrument.Code InstrumentCode, Instrument.Name InstrumentName, Instrument.Description InstrumentDescription, Instrument.Url InstrumentUrl,
  Observation.SensorID, Sensor.Code SensorCode, Sensor.Name SensorName, Sensor.Description SensorDescription, Sensor.Url SensorUrl,
  Coalesce(Observation.Latitude, Sensor.Latitude, Instrument_Sensor.Latitude, Instrument.Latitude, Station_Instrument.Latitude, Station.Latitude) Latitude,
  Coalesce(Observation.Longitude, Sensor.Longitude, Instrument_Sensor.Longitude, Instrument.Longitude, Station_Instrument.Longitude, Station.Longitude) Longitude,
  Coalesce(Observation.Elevation, Sensor.Elevation, Instrument_Sensor.Elevation, Instrument.Elevation, Station_Instrument.Elevation, Station.Elevation) Elevation,
  Observation.PhenomenonOfferingID, Phenomenon.ID PhenomenonID, Phenomenon.Code PhenomenonCode, Phenomenon.Name PhenomenonName, Phenomenon.Description PhenomenonDescription, Phenomenon.Url PhenomenonUrl,
  Offering.ID OfferingID, Offering.Code OfferingCode, Offering.Name OfferingName, Offering.Description OfferingDescription,
  Observation.PhenomenonUOMID, UnitOfMeasure.ID UnitOfMeasureID, UnitOfMeasure.Code UnitOfMeasureCode, UnitOfMeasure.Unit UnitOfMeasureUnit, UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Observation.StatusID, Status.Code StatusCode, Status.Name StatusName, Status.Description StatusDescription,
  Observation.StatusReasonID, StatusReason.Code StatusReasonCode, StatusReason.Name StatusReasonName, StatusReason.Description StatusReasonDescription
from
  Observation
  inner join ImportBatch
    on (Observation.ImportBatchID = ImportBatch.ID)
  inner join Sensor
    on (Observation.SensorID = Sensor.ID)
  inner join Instrument_Sensor
    on (Observation.SensorID = Instrument_Sensor.SensorID) 
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) 
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument_Sensor.InstrumentID) 
  inner join Station
    on (Station_Instrument.StationID = Station.ID) 
  inner join Site
    on (Station.SiteID = Site.ID) 
  inner join PhenomenonOffering
    on (Observation.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Phenomenon
    on (PhenomenonOffering.PhenomenonID = Phenomenon.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (Observation.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
  left join Status
    on (Observation.StatusID = Status.ID)
  left join StatusReason
    on (Observation.StatusReasonID = StatusReason.ID)
Where
  ((Instrument_Sensor.StartDate is null) or (Observation.ValueDate >= Instrument_Sensor.StartDate)) and
  ((Instrument_Sensor.EndDate is null) or (Observation.ValueDate <= Instrument_Sensor.EndDate)) and
  ((Instrument.StartDate is null) or (Observation.ValueDay >= Instrument.StartDate)) and
  ((Instrument.EndDate is null) or (Observation.ValueDay <= Instrument.EndDate)) and
  ((Station_Instrument.StartDate is null) or (Observation.ValueDay >= Station_Instrument.StartDate)) and
  ((Station_Instrument.EndDate is null) or (Observation.ValueDay <= Station_Instrument.EndDate)) and
  ((Station.StartDate is null) or (Observation.ValueDay >= Station.StartDate))  and
  ((Station.EndDate is null) or (Observation.ValueDay <= Station.EndDate)) and
  ((Site.StartDate is null) or (Observation.ValueDay >= Site.StartDate)) and
  ((Site.EndDate is null) or (Observation.ValueDay <= Site.EndDate))
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[vObservation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservation]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Update complete.';


GO