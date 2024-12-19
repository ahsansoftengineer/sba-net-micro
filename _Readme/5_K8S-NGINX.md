### NGINX PROXY SERVER
#### RESOURCE LINKS
- (Nginx Docs)[https://kubernetes.github.io/ingress-nginx/deploy/#docker-desktop]
- [Git Hub Nginx](https://github.com/kubernetes/ingress-nginx?tab=readme-ov-file)

#### BASH TO ADD IN DOCKER
- Create Pods for INGRESS NGINX
```bash
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.12.0-beta.0/deploy/static/provider/aws/deploy.yaml
```
#### COMD TO WORK WITH NGINX
```bash
kubectl get namespace
kubectl get pods --namespace=ingress-nginx
kubectl get services --namespace=ingress-nginx
```

#### Update the Host file
- C:\Windows\System32\drivers\etc
```bash
# Added by Ahsan
127.0.0.1 ahsan.com
# End of section

# Added by Docker Desktop
192.168.100.191 host.docker.internal
192.168.100.191 gateway.docker.internal
127.0.0.1 kubernetes.docker.internal
# End of section
```
#### Nginx Srvc Config
- Nginx doing the Task of NodePort
- Node Port Platform -> http://localhost:30541/
- Node Port Commands -> http://localhost:30841/
- Nginx Proxy (Platform / Commands ) -> ahsan.com/api/platform
- Nginx Proxy (Platform / Commands ) -> ahsan.com/api/c/platforms
```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: ingress-srv
  annotations:
    kubernetes.io/ingress.class: nginx
    nginx.ingress.kubernetes.io/use-regex: 'true'
spec:
  # Routing Rules
  rules:
  - host: ahsan.com
    http:
      paths:
      - path: /swag-platforms #~*^/swag-platforms.*
        pathType: Prefix
        backend:
          service:
            name: srv-clusterip-platforms # Cluster IP
            port:
              number: 5401
      - path: /swag-commands
        pathType: Prefix
        backend:
          service:
            name: srv-clusterip-commands # Cluster IP
            port:
              number: 8401

      - path: /api/platform
        pathType: Prefix
        backend:
          service:
            name: srv-clusterip-platforms # Cluster IP
            port:
              number: 5401
      - path: /api/c/platforms
        pathType: Prefix
        backend:
          service:
            name: srv-clusterip-commands # Cluster IP
            port:
              number: 8401
```
### RUN NGINX
```bash
kubectl apply -f srvc-ingress.yaml
kubectl delete -f srvc-ingress.yaml
```