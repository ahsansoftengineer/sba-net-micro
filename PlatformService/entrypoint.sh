#!/bin/bash
set -e

# echo "Checking .NET SDK and Entity Framework tools..."
# if ! dotnet --list-sdks > /dev/null; then
#     echo "Error: .NET SDK is not installed"
#     exit 1
# fi

# if ! dotnet ef --help > /dev/null; then
#     echo "Installing dotnet-ef tool..."
#     dotnet tool install --global dotnet-ef
#     export PATH="$PATH:/root/.dotnet/tools"
# fi

# echo "Waiting for SQL Server to be available..."
# until dotnet ef database update --no-build; do
#     >&2 echo "SQL Server is unavailable - sleeping"
#     sleep 30
# done

# >&2 echo "SQL Server is up - applying migrations and starting app"

exec dotnet PlatformService.dll
