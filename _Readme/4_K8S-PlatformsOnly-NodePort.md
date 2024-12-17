
### Testing Deployments
- It won't work any more since the depl-platform.yaml has changed 
```bash
docker build -t ahsansoftengineer/platformservice-a .
docker push ahsansoftengineer/platformservice-a

kubectl apply -f depl-platforms.yaml
kubectl get pods
kubectl get deployments
kubectl delete -f depl-platforms.yaml
kubectl delete deployments app=depl-platforms # --all
```

### Testing Node Port
```bash
kubectl apply -f srvc-np-platforms.yaml
kubectl delete -f srvc-np-platforms.yaml
# http://localhost:31504/swagger/index.html #Auto Generated URL
```