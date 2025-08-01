### DOCKER SQL
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker image ls
docker run --name sql-sba-dev -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@55w0rd!123' -p 1430:1433 -d mcr.microsoft.com/mssql/server:2022-latest

docker run --name sql-sba-stage -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@55w0rd!123' -p 1431:1433 -d mcr.microsoft.com/mssql/server:2022-latest

docker stop sql-sba-dev
docker rm sql-sba-dev
docker container ls
docker ps
```
### DOCKER Redis
#### Caching Criteria
- Cache CUDS            [CacheKey = api/hierarchy/v1/contrller/1]
- Cache Single          [CacheKey = api/hierarchy/v1/contrller/1]
- Cache Full List       [CacheKey = api/hierarchy/v1/contrller/list]
- Cache Full Options    [CacheKey = api/hierarchy/v1/contrller/options]
- Cache Full Dictionary [CacheKey = api/hierarchy/v1/contrller/dictonary]
```bash
docker pull redis
# docker run --name sba-redis-srvr -p 6379:6379 -d redis
docker run --name dev-sba-redis -p 6379:6379 -d redis redis-server --requirepass 'P@55w0rd!123'
docker stop dev-sba-redis
docker rm dev-sba-redis
sudo apt install redis-tools

redis-cli -a 'P@55w0rd!123'
set myKey Ahsan
get myKey
```
### Rabbit MQ
```bash
docker run -d --name dev-sba-rabbit-mq --hostname dev-sba-rabbit-host -p 5672:5672 -p 15672:15672 rabbitmq:3-management
docker stop dev-sba-rabbit-mq
docker rm dev-sba-rabbit-mq

```