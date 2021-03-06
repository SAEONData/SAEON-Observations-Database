use ObservationsSACTN
Select 
  SiteName, StationName, InstrumentName, SensorName, PhenomenonName, OfferingName, UnitOfMeasureUnit, ValueDate, DataValue, Latitude, Longitude, Elevation
from
  vObservationExpansion
where
  (StationName like 'SACTN%') and (SensorName like '% Hourly %')
order by
  SiteName, StationName, InstrumentName, SensorName, PhenomenonName, OfferingName, UnitOfMeasureUnit, ValueDate