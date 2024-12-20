### SECRET
```bash
kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55w0rd!"
```

### MS SQL
- Need PVC to Work
```yaml

```

### BASH
```yaml
kubectl apply -f 5_depl-mssql-platform.yaml
kubectl delete -f 5_depl-mssql-platform.yaml

# deployment.apps/depl-mssql-platform created
# service/srvc-clusterip-mssql created
# service/srvc-loadbalancer-mssql created
```
