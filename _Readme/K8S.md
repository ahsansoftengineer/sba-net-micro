```bash
# Install the Below Package in Ubuntu
sudo snap install kubectl --classic
kubectl version

# Other Commands
kubectl get pods
kubectl get deployments
kubectl get services
kubectl get namespace
kubectl get storageclass
kubectl get pvc

# HARD RESTART DEPLOYMENTS
kubectl rollout restart deployments # Restart all deployments
kubectl rollout restart deployments name-depl # Restart 1 Deployments
kubectl rollout restart deployments name-depl1 name-depl2
```