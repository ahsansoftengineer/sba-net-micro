#!/bin/bash
set -e

# echo "Waiting for SQL Server to be available..."
# # Wait until SQL Server is reachable
# until dotnet ef database update --no-build; do
#   >&2 echo "SQL Server is unavailable - sleeping"
#   sleep 30
# done

# >&2 echo "SQL Server is up - applying migrations and starting app"

# Run the application
exec dotnet PlatformService.dll
