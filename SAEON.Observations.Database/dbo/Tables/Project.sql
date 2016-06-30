﻿--> Added 2.0.5 20160511 TimPN
CREATE TABLE [dbo].[Project]
(
    [ID] UNIQUEIDENTIFIER CONSTRAINT [DF_Project_ID] DEFAULT newid(), 
    [ProgrammeID] UNIQUEIDENTIFIER NULL,
    [Code] VARCHAR(50) NOT NULL, 
    [Name] VARCHAR(150) NOT NULL, 
    [Description] VARCHAR(5000) NULL,
    [Url] VARCHAR(250) NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [AddedAt] DATETIME NULL CONSTRAINT [DF_Project_AddedAt] DEFAULT GetDate(), 
    [UpdatedAt] DATETIME NULL CONSTRAINT [DF_Project_UpdatedAt] DEFAULT GetDate(), 
    CONSTRAINT [PK_Project] PRIMARY KEY NONCLUSTERED ([ID]),
    CONSTRAINT [UX_Project_ProgramID_Code] UNIQUE ([ProgrammeID],[Code]),
    CONSTRAINT [UX_Project_ProgramID_Name] UNIQUE ([ProgrammeID],[Name]),
    CONSTRAINT [FK_Project_Programme] FOREIGN KEY ([ProgrammeID]) REFERENCES [dbo].[Programme] ([ID]),
    CONSTRAINT [FK_Project_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]),
)
GO
CREATE CLUSTERED INDEX [CX_Project] ON [dbo].[Project] ([AddedAt])
GO
CREATE INDEX [IX_Project_ProgrammeID] ON [dbo].[Project] ([ProgrammeID])
GO
CREATE INDEX [IX_Project_UserId] ON [dbo].[Project] ([UserId])
GO
CREATE INDEX [IX_Project_StartDate] ON [dbo].[Project] ([StartDate])
GO
CREATE INDEX [IX_Project_EndDate] ON [dbo].[Project] ([EndDate])
GO
CREATE TRIGGER [dbo].[TR_Project_Insert] ON [dbo].[Project]
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
        inserted ins 
        inner join Project src
            on (ins.ID = src.ID)
END
GO
CREATE TRIGGER [dbo].[TR_Project_Update] ON [dbo].[Project]
FOR UPDATE
AS
BEGIN
    SET NoCount ON
    --if UPDATE(AddedAt) RAISERROR ('Cannot update AddedAt.', 16, 1)
    Update 
        src 
    set 
        UpdatedAt = GETDATE()
    from
        inserted ins 
        inner join Project src
            on (ins.ID = src.ID)
END
--< Added 2.0.5 20160511 TimPN