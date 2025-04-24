#!/bin/bash

gnome-terminal -- bash -c "dotnet watch run --project ../SBA.APIGateway/SBA.APIGateway.csproj"
gnome-terminal -- bash -c "dotnet watch run --project ../SBA.Auth/SBA.Auth.csproj"
gnome-terminal -- bash -c "dotnet watch run --project ../SBA.Hierarchy/SBA.Hierarchy.csproj"