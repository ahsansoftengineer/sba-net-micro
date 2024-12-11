```bash
kubectl apply -f depl-platforms.yaml
kubectl get pods
kubectl get deployments
kubectl delete deployments app=depl-platforms  # --all
kubectl delete -f depl-platforms.yaml


kubectl apply -f srvc-np-platforms.yaml
kubectl delete -f srvc-np-platforms.yaml
# http://localhost:31504/swagger/index.html #Auto Generated URL
```