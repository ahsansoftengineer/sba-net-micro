
### PlatformService Docker & K8S
#### Dockerfile Platform Service
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "PlatformService.dll"]
```
#### BASH Dockerfile
- Run Inside K8S Folder
```bash
# -t tagname, -f file/reference, ./buildContext  
docker build -t ahsansoftengineer/platformservice-d -f ./../PlatformService/Dockerfile ./../PlatformService
docker push ahsansoftengineer/platformservice-d
```
#### YAML K8S Deployment file & Cluster IP Config 
```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: depl-platforms-d
spec:
  replicas: 1
  selector:
    matchLabels:
      app: platformservice-d
  template:
    metadata:
      labels:
        app: platformservice-d
    spec:
      containers:
      - name: platformservice-d
        image: ahsansoftengineer/platformservice-d
        ports:
        - containerPort: 5401
        env:
        - name: DOTNET_ENVIRONMENT
          value: "DockerK8S"
        - name: ASPNETCORE_URLS
          value: "http://+:5401"

# CLUSTER IP CONFIG
--- 
apiVersion: v1
kind: Service
metadata:
  name: srv-clusterip-platforms
spec:
  type: ClusterIP
  selector:
    app: platformservice-d
  ports:
  - name: platformservice-d
    protocol: TCP
    port: 5401
    targetPort: 5401
```
#### BASH K8S Deployment
- Run Inside K8S Folder
```bash
kubectl apply -f depl-platforms.yaml
kubectl get pods
kubectl get deployments
kubectl delete -f depl-platforms.yaml
```

#### SERVICE Node Port
```yaml
apiVersion: v1
kind: Service
metadata:
  name: srvc-np-platforms-d
spec:
  type: NodePort
  selector:
    app: platformservice-d
  ports:
    - name: platformservice-d
      protocol: TCP
      port: 5401         # Cluster-wide service port
      targetPort: 5401   # Pod's application port
      nodePort: 30541     # Range 30000-32767
```
#### BASH K8S SERVICE NODE PORT
- Run Inside K8S Folder
```bash
kubectl apply -f srvc-np-platforms.yaml
kubectl get pods
kubectl get deployments
kubectl delete -f  srvc-np-platforms.yaml
```
#### http://localhost:30541/swagger/index.html
