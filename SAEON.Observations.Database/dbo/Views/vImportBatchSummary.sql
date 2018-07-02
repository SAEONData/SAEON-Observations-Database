﻿--> Added 2.0.28 20180423 TimPN
CREATE VIEW [dbo].[vImportBatchSummary]
AS 
Select
  ImportBatchSummary.*, 
  Phenomenon.Code PhenomenonCode, Phenomenon.Name PhenomenonName,
  Offering.Code OfferingCode, Offering.Name OfferingName,
  UnitOfMeasure.Code UnitOfMeasureCode, UnitOfMeasure.Unit UnitOfMeasureUnit, UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Sensor.Code SensorCode, Sensor.Name SensorName,
  Instrument.Code InstrumentCode, Instrument.Name InstrumentName,
  Station.Code StationCode, Station.Name StationName,
  Site.Code SiteCode, Site.Name SiteName
From
  ImportBatchSummary
  inner join Sensor
    on (ImportBatchSummary.SensorID = Sensor.ID)
  inner join Instrument
    on (ImportBatchSummary.InstrumentID = Instrument.ID)
  inner join Station
    on (ImportBatchSummary.StationID = Station.ID)
  inner join Site
    on (ImportBatchSummary.SiteID = Site.ID)
  inner join PhenomenonOffering
    on (ImportBatchSummary.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Phenomenon
    on (PhenomenonOffering.PhenomenonID = Phenomenon.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (ImportBatchSummary.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
--< Added 2.0.28 20180423 TimPN
