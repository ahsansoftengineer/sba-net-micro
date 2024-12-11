```bash
docker build -t ahsansoftengineer/platformservice-a .
docker push ahsansoftengineer/platformservice-a
docker run -p 8080:8080 -d ahsansoftengineer/platformservice-a
docker run -p 8080:8080 -e DOTNET_ENVIRONMENT=Development -d ahsansoftengineer/platformservice-a
docker exec -it d2d4 # Get Inside Container


```