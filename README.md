# Everhour

docker build -f src/Everhour.Api/Dockerfile -t everhour-api .
docker build --no-cache -f src/Everhour.Api/Dockerfile -t everhour-api .


docker tag everhour-api josenerydev/everhour-api:v2

docker push josenerydev/everhour-api:v2
