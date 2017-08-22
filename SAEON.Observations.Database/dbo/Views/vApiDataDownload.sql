﻿--> Added 2.0.32 20170527 TimPN
CREATE VIEW [dbo].[vApiDataDownload]
AS
Select
  Observation.ID,
  Site.ID SiteID,
  Site.Code SiteCode,
  Site.Name SiteName,
  Site.Description SiteDescription,
  Site.Url SiteUrl,
  Station.ID StationID,
  Station.Code StationCode,
  Station.Name StationName,
  Station.Description StationDescription,
  Station.Url StationUrl,
  Station.Latitude StationLatitude,
  Station.Longitude StationLongitude,
  Station.Elevation StationElevation,
  Instrument.ID InstrumentID,
  Instrument.Code InstrumentCode,
  Instrument.Name InstrumentName,
  Instrument.Description InstrumentDescription,
  Instrument.Url InstrumentUrl,
  Sensor.ID SensorID,
  Sensor.Code SensorCode,
  Sensor.Name SensorName,
  Sensor.Description SensorDescription,
  Sensor.Url SensorUrl,
  Phenomenon.ID PhenomenonID,
  Phenomenon.Code PhenomenonCode,
  Phenomenon.Name PhenomenonName,
  Phenomenon.Description PhenomenonDescription,
  Phenomenon.Url PhenomenonUrl,
  PhenomenonOffering.ID PhenomenonOfferingID,
  Offering.ID OfferingID,
  Offering.Code OfferingCode,
  Offering.Name OfferingName,
  Offering.Description OfferingDescription,
  PhenomenonUOM.ID PhenomenonUnitOfMeasureID,
  UnitOfMeasure.ID UnitOfMeasureID,
  UnitOfMeasure.Code UnitOfMeasureCode,
  UnitOfMeasure.Unit UnitOfMeasureUnit,
  UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Phenomenon.Name + ', ' + Offering.Name + ', ' + UnitOfMeasure.UnitSymbol FeatureCaption,
  Replace(Phenomenon.Name + '_' + Offering.Name + '_' + UnitOfMeasure.Unit,' ','') FeatureName,
  Observation.ValueDate,
  Observation.ValueDay,
  Observation.DataValue Value,
  Observation.Comment,
  Observation.CorrelationID,
  IsNull(Status.Name, 'No Status') Status
from
  Observation
  inner join Status
    on (Observation.StatusID = Status.ID)
  inner join Sensor
    on (Observation.SensorID = Sensor.ID)
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
  inner join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID) and
       ((Instrument_Sensor.StartDate is null) or (Observation.ValueDay >= Instrument_Sensor.StartDate)) and
       ((Instrument_Sensor.EndDate is null) or (Observation.ValueDay <= Instrument_Sensor.EndDate))
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) and
       ((Instrument.StartDate is null) or (Observation.ValueDay >= Instrument.StartDate )) and
       ((Instrument.EndDate is null) or (Observation.ValueDay <= Instrument.EndDate))
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID) and
       ((Station_Instrument.StartDate is null) or (Observation.ValueDay >= Station_Instrument.StartDate)) and
       ((Station_Instrument.EndDate is null) or (Observation.ValueDay <= Station_Instrument.EndDate))
  inner join Station
    on (Station_Instrument.StationID = Station.ID) and
       ((Station.StartDate is null) or (Observation.ValueDay = Station.StartDate)) and
       ((Station.EndDate is null) or (Observation.ValueDay <= Station.EndDate))
  inner join Site
    on (Station.SiteID = Site.ID) and
       ((Site.StartDate is null) or (Observation.ValueDay >= Site.StartDate)) and
       ((Site.EndDate is null) or (Observation.ValueDay <= Site.EndDate))
where
  (Status.Name = 'Verified')
--< Added 2.0.32 20170527 TimPN