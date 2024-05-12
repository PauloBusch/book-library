echo "Waiting for SQL Server container..."
sleep 120

echo "Running scripts."
/opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P SqlServer2022! -d master -i "/tmp/Scripts/Setup Database.sql"
