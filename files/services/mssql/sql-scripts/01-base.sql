
SET NOCOUNT ON;
GO

USE [master];
GO

-- -----------------------------------------------------
-- IF EXISTS, DROP: quickstart
-- -----------------------------------------------------
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'quickstart')
BEGIN
    DROP DATABASE [quickstart];
END
GO

-- -----------------------------------------------------
-- DATABASE: quickstart
-- -----------------------------------------------------
CREATE DATABASE [quickstart] ON (
    NAME = quickstart_data,
    FILENAME = '/var/opt/mssql/data/quickstart_data.mdf',
    SIZE = 8MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 64MB
) LOG ON (
    NAME = quickstart_log,
    FILENAME = '/var/opt/mssql/data/quickstart_log.ldf',
    SIZE = 8MB,
    MAXSIZE = 128MB,
    FILEGROWTH = 64MB
) COLLATE LATIN1_GENERAL_100_CI_AS_SC; -- OR Latin1_General_CI_AS
GO

-- Add a database to the availability group.
-- Ensure that the database you add to the availability group is in 
-- full recovery mode and has a valid log backup. If this is a test 
-- database or a newly created database, take a database backup. 
-- On the primary SQL Server, run the following Transact-SQL script 
-- to create and back up a database called quickstart:
ALTER DATABASE [quickstart] SET RECOVERY FULL;
BACKUP DATABASE [quickstart] TO DISK = N'/var/opt/mssql/data/quickstart.bak';
GO

-- On the primary SQL Server replica, run the following Transact-SQL 
-- script to add a database called quickstart to an availability group 
-- called ag1:
ALTER AVAILABILITY GROUP [ag1] ADD DATABASE [quickstart];
GO

USE [quickstart];
GO

-- -----------------------------------------------------
-- SCHEMA: domain
-- -----------------------------------------------------
CREATE SCHEMA [domain];
GO
