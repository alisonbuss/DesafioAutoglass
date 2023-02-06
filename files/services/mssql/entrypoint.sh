#!/bin/bash

# Overwrite default image environment variables.
# FRONT: https://docs.microsoft.com/pt-br/sql/linux/sql-server-linux-configure-environment-variables?view=sql-server-ver15
if [ -z ${MSSQL_USER+x} ]; then export MSSQL_USER="sa"; fi
if [ -z ${MSSQL_DATABASE+x} ]; then export MSSQL_DATABASE="master"; fi
if [ -z ${MSSQL_IP_ADDRESS+x} ]; then export MSSQL_IP_ADDRESS="0.0.0.0"; fi
if [ -z ${SA_PASSWORD+x} ]; then export SA_PASSWORD="!demo54321"; fi

echo "Starting SQL Server database deployment...";

echo "SQL Server service is STARTED!!!";

# Checks if there are SQL scripts from the default directory.
if [ -n "$(ls -A /docker-entrypoint-initdb.d/*.sql 2>/dev/null)" ]; then

    echo "Initializing execution of database scripts...";

    echo "Running base scripts, tables, procedures, views and inserts in the database:";
    for SQL_FILE in $(ls /docker-entrypoint-initdb.d/*.sql | sort -g); do
        FILENAME="$(basename ${SQL_FILE})";
        echo "--Run the script on the database: ${SQL_FILE}";
        /opt/mssql-tools/bin/sqlcmd -S $MSSQL_IP_ADDRESS -d $MSSQL_DATABASE -U $MSSQL_USER -P $SA_PASSWORD \
                                    -i "${SQL_FILE}";
        if [ $? -ne 0 ]; then exit 1; fi # Check if there was an error running the script!
    done

    echo "Finished initializing the database.";

fi

echo "SQL Server database deployment successfully executed!!!";

sleep infinity;
