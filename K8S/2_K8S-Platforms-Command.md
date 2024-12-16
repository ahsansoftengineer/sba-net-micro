
### 1. PlatformService Docker & K8S
```bash
# -t tagname, -f file/reference, ./buildContext  
docker build -t ahsansoftengineer/platformservice-d -f ./../PlatformService/DockerfileK8S ./../PlatformService
docker push ahsansoftengineer/platformservice-d

kubectl apply -f depl-platforms.yaml
kubectl get pods
kubectl get deployments
kubectl delete -f depl-platforms.yaml
kubectl delete deployments app=depl-platforms # --all
```

### 2. PlatformService NodePort 
```bash
kubectl apply -f srvc-np-platforms.yaml
kubectl delete -f srvc-np-platforms.yaml
# http://localhost:30541/swagger/index.html #Auto Generated URL
```

### CommandService Docker & K8S
```bash
docker build -t ahsansoftengineer/commandservice-d -f ./CommandService/DockerfileK8S ./CommandService
docker push ahsansoftengineer/commandservice-d

kubectl apply -f depl-commands.yaml
kubectl get pods
kubectl get deployments
kubectl delete -f depl-commands.yaml
kubectl delete deployments app=depl-platforms # --all

```