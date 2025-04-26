#!/bin/bash

# Navigate to script directory
cd "$(dirname "$0")"

# Set environment variable
export ASPNETCORE_ENVIRONMENT=Development

# Kill background jobs on script exit (including Ctrl+C or terminal close)
trap 'echo "Stopping services..."; kill $(jobs -p); exit' SIGINT SIGTERM EXIT

# Start each project in the background
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.APIGateway/SBA.APIGateway.csproj &
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.Auth/SBA.Auth.csproj &
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.Hierarchy/SBA.Hierarchy.csproj &

# Wait for all background processes
wait

# bash .vscode/start.sh