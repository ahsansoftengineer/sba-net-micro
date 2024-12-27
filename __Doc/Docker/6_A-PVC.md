### PVC file
```yaml
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: claim-mssql
spec:
  resources:
    requests:
      storage: 500Mi
  accessModes:
  - ReadWriteMany
```
### Create Claims
- This Task Done Only Once
- Creating Claim for Database
```bash
kubectl apply -f 4_pvc-local.yaml
kubectl get pvc
kubectl delete -f 4_pvc-local.yaml
```