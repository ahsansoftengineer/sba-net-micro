### CommandsService Docker & K8S
#### Dockerfile Commands Service
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

ENTRYPOINT [ "dotnet", "CommandsService.dll"]
```
#### BASH Dockerfile
- Run Inside K8S Folder
- We need ClusterIP for Inter Service Communication
```bash
# -t tagname, -f file/reference, ./buildContext  
docker build -t ahsansoftengineer/commandservice-d -f ./../CommandsService/Dockerfile ./../CommandsService
docker push ahsansoftengineer/commandservice-d
```
#### YAML K8S Deployment file & Cluster IP Config 
```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: depl-commands-d
spec:
  replicas: 1
  selector:
    matchLabels:
      app: commandservice-d
  template:
    metadata:
      labels:
        app: commandservice-d
    spec:
      containers:
      - name: commandservice-d
        image: ahsansoftengineer/commandservice-d
        ports:
        - containerPort: 8401
        env:
        - name: DOTNET_ENVIRONMENT
          value: "DockerK8S"
        - name: ASPNETCORE_URLS
          value: "+:8401"

# CLUSTER IP CONFIG
# We need ClusterIP for Inter Service Communication
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
```bash
kubectl apply -f 1_depl-commands.yaml
kubectl get pods
kubectl get deployments
kubectl rollout restart deployments 1_depl-commands-d
kubectl delete -f 1_depl-commands.yaml
# Delete (Deployments & Service)
kubectl delete deployments depl-commands-d
kubectl delete services srvc-clusterip-commands
```

#### SERVICE Node Port
```yaml
apiVersion: v1
kind: Service
metadata:
  name: srvc-np-commands-d
spec:
  type: NodePort
  selector:
    app: commandservice-d
  ports:
    - name: commandservice-d
      protocol: TCP
      port: 8401         # Cluster-wide service port
      targetPort: 8401   # Pod's application port
      nodePort: 30841     # Range 30000-32767
```
#### BASH K8S SERVICE NODE PORT
- We need Node Port to Access application via Host
- Run Inside K8S Folder
```bash
kubectl apply -f 2_srvc-np-commands.yaml
kubectl get services
kubectl get nodes -o wide # EXTERNAL-IP replace with localhost
kubectl delete -f 2_srvc-np-commands.yaml
```
### ROUTES (K8S Node Port)
- http://localhost:30841/swagger/index.html
- http://localhost:30841/api/c/platforms POST

### Inter Service Comm (Cluster IP)
- srv-clusterip-commands:8401/api/c/platforms/