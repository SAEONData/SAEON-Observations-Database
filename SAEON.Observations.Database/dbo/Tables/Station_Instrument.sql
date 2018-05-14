﻿--> Added 2.0.5 20160512 TimPN
CREATE TABLE [dbo].[Station_Instrument]
(
    [ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Station_Instrument_ID] DEFAULT newid(), 
    [StationID] UNIQUEIDENTIFIER NOT NULL, 
    [InstrumentID] UNIQUEIDENTIFIER NOT NULL, 
--> Changed 2.0.22 20170111 TimPN
--    [StartDate]        DATETIME         NULL,
    [StartDate]        DATE         NULL,
--< Changed 2.0.22 20170111 TimPN
--> Changed 2.0.22 20170111 TimPN
--    [EndDate]        DATETIME         NULL,
    [EndDate]        DATE         NULL,
--< Changed 2.0.22 20170111 TimPN
--> Added 2.0.33 20170628 TimPN
    [Latitude] Float Null,
    [Longitude] Float Null,
    [Elevation] Float Null,
--< Added 2.0.33 20170628 TimPN
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [AddedAt] DATETIME NULL CONSTRAINT [DF_Station_Instrument_AddedAt] DEFAULT GetDate(), 
    [UpdatedAt] DATETIME NULL CONSTRAINT [DF_Station_Instrument_UpdatedAt] DEFAULT GetDate(), 
--> Added 2.0.33 20170628 TimPN
    [RowVersion] RowVersion not null,
--< Added 2.0.33 20170628 TimPN
    CONSTRAINT [PK_Station_Instrument] PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT [FK_Station_Instrument_Station] FOREIGN KEY ([StationID]) REFERENCES [dbo].[Station] ([ID]),
    CONSTRAINT [FK_Station_Instrument_Instrument] FOREIGN KEY ([InstrumentID]) REFERENCES [dbo].[Instrument] ([ID]),
    CONSTRAINT [FK_Station_Instrument_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]),
    CONSTRAINT [UX_Station_Instrument] UNIQUE ([StationID],[InstrumentID],[StartDate],[EndDate])
)
GO
CREATE INDEX [IX_Station_Instrument_StationID] ON [dbo].[Station_Instrument] ([StationID])
GO
CREATE INDEX [IX_Station_Instrument_InstrumentID] ON [dbo].[Station_Instrument] ([InstrumentID])
GO
CREATE INDEX [IX_Station_Instrument_StartDate] ON [dbo].[Station_Instrument] ([StartDate])
GO
CREATE INDEX [IX_Station_Instrument_EndDate] ON [dbo].[Station_Instrument] ([EndDate])
GO
CREATE INDEX [IX_Station_Instrument_UserId] ON [dbo].[Station_Instrument] ([UserId])
--> Added 2.0.37 20180201 TimPN
GO
CREATE INDEX [IX_Station_Instrument_Latitude] ON [dbo].[Station_Instrument] ([Latitude])
GO
CREATE INDEX [IX_Station_Instrument_Longitude] ON [dbo].[Station_Instrument] ([Longitude])
GO
CREATE INDEX [IX_Station_Instrument_Elevation] ON [dbo].[Station_Instrument] ([Elevation])
--< Added 2.0.37 20180201 TimPN
--> Changed 2.0.15 20161102 TimPN
GO
CREATE TRIGGER [dbo].[TR_Station_Instrument_Insert] ON [dbo].[Station_Instrument]
FOR INSERT
AS
BEGIN
    SET NoCount ON
    Update
        src
    set
        AddedAt = GETDATE(),
        UpdatedAt = NULL
    from
        Station_Instrument src
        inner join inserted ins
            on (ins.ID = src.ID)
END
GO
CREATE TRIGGER [dbo].[TR_Station_Instrument_Update] ON [dbo].[Station_Instrument]
FOR UPDATE
AS
BEGIN
    SET NoCount ON
    Update
        src
    set
--> Changed 2.0.19 20161205 TimPN
--		AddedAt = del.AddedAt,
        AddedAt = Coalesce(del.AddedAt, ins.AddedAt, GetDate ()),
--< Changed 2.0.19 20161205 TimPN
        UpdatedAt = GETDATE()
    from
        Station_Instrument src
        inner join inserted ins
            on (ins.ID = src.ID)
        inner join deleted del
            on (del.ID = src.ID)
END
--< Changed 2.0.15 20161102 TimPN
--< Added 2.0.5 20160512 TimPN
