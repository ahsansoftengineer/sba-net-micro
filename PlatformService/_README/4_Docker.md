### Dockerfile
```docker

```
### Docker run
```bash
docker build -t ahsansoftengineer/platformservice-a .
docker push ahsansoftengineer/platformservice-a
docker run -p 5000:5000 -d ahsansoftengineer/platformservice-a
docker run -p 5000:5000 -e DOTNET_ENVIRONMENT=Development -d ahsansoftengineer/platformservice-a
docker exec -it d2d4 # Get Inside Container
```

###