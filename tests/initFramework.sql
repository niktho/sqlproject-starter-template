/*
    This pre-deployment script is currently setting up the
    tSQLt framework that enables us to run unit tests on
    SQL Server or Azure SQL databases.

    Other pre-deployment scripts should be referenced here
    or be added below directly.
*/

:r ../.external-dependencies/tSQLt/PrepareServer.sql
:r ../.external-dependencies/tSQLt/tSQLt.class.sql