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
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.SAEON\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.SAEON\MSSQL\DATA\"

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
PRINT N'Altering [dbo].[fnObservations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
--> Added 2.0.20 20161213 TimPN
ALTER function fnObservations(@UserID UniqueIdentifier)
Returns Table
As
return
  Select
	vObservation.*
  from
	vObservation
  where
	Exists(
	  Select 
	    * 
	  from 
		DataSourceRole 
	  inner join  aspnet_UsersInRoles 
		on (DataSourceRole.RoleId = aspnet_UsersInRoles.RoleId)
	  where
		(vObservation.ValueDate >= DataSourceRole.DateStart) and
		(vObservation.ValueDate <= DataSourceRole.DateEnd))
--< Added 2.0.20 20161213 TimPN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;

GO
PRINT N'Dropping [dbo].[vObservationRole]...';

Drop View vObservationRoles

GO
PRINT N'Update complete.';


GO
