### SECRET
- Becareful with Password Complexity
```bash
kubectl create secret generic mssql --from-literal=SA_PASSWORD="Pa55w0rd!"
kubectl get secret mssql
kubectl delete secret mssql
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

### Creadentials
- 127.0.0.1,1433
- sa
- Pa55w0rd!