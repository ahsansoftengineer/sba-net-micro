#!/bin/bash

# Navigate to script directory
cd "$(dirname "$0")"

# Set environment variable
export ASPNETCORE_ENVIRONMENT=Development

# Trap to clean up on exit
trap '
    echo "Stopping services..."
    pkill -f "dotnet watch"
    echo "Cleaning up ports..."
    for port in {5800..5820}; do
        fuser -k ${port}/tcp 2>/dev/null
    done
    echo "Cleaning terminal..."
    sleep 1
    clear
    exit
' SIGINT SIGTERM EXIT

# Start each project in the background
echo "Starting projects..."
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.APIGateway/SBA.APIGateway.csproj &
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.Auth/SBA.Auth.csproj &
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.Hierarchy/SBA.Hierarchy.csproj &

# Open browser when port 5800 is available
(
  while ! nc -z localhost 5800; do
    sleep 1
  done
  xdg-open http://localhost:5800/ > /dev/null 2>&1
) &

# Wait for all background jobs
wait


# bash .vscode/start.sh