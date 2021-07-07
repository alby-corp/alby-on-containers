docker-compose -f docker-compose.yml -f docker-compose.override.yml build identityserver
docker-compose -f docker-compose.yml -f docker-compose.override.yml build hermes
docker-compose -f docker-compose.yml -f docker-compose.override.yml build pollon