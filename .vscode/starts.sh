#!/bin/bash

## With Debugging

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

# Function to attach debugger using VS Code CLI
attach_debugger() {
    PID=$1
    echo "Attaching debugger to process PID $PID..."

    # VS Code command to attach to the running process (ensure VS Code is installed)
    code --attach=$PID --wait
    
    if [ $? -eq 0 ]; then
        echo "Debugger attached to process $PID successfully."
    else
        echo "Failed to attach debugger to PID $PID."
    fi
}

# Start each microservice project in the background
echo "Starting microservices..."

# Start ASP.NET Core projects using dotnet watch (multiple microservices)
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.APIGateway/SBA.APIGateway.csproj &
APIGateway_PID=$!
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.Auth/SBA.Auth.csproj &
Auth_PID=$!
ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile https --no-build --debug --project ../SBA.Hierarchy/SBA.Hierarchy.csproj &
Hierarchy_PID=$!

# Wait for all background jobs to start
wait

# Attach the debugger to each service's PID
attach_debugger $APIGateway_PID
attach_debugger $Auth_PID
attach_debugger $Hierarchy_PID

# Open browser with the specific URL after starting the services
open_url="http://localhost:5800/"
echo "Opening browser with $open_url"
xdg-open "$open_url"  # Use xdg-open for Linux; on macOS, use open, on Windows use start

# Wait for all processes to finish
wait


# chmod +x .vscode/starts.sh
# bash .vscode/starts.sh