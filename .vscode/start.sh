#!/bin/bash

# Navigate to the script's directory
cd "$(dirname "$0")"

# Launch each project in a new terminal tab (requires gnome-terminal)
gnome-terminal -- bash -c "dotnet watch --launch-profile https --no-build --debug --project ../SBA.APIGateway/SBA.APIGateway.csproj; exec bash"
gnome-terminal -- bash -c "dotnet watch --launch-profile https --no-build --debug --project ../SBA.Auth/SBA.Auth.csproj; exec bash"
gnome-terminal -- bash -c "dotnet watch --launch-profile https --no-build --debug --project ../SBA.Hierarchy/SBA.Hierarchy.csproj; exec bash"
