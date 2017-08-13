echo "--- Read environment settings ---"
. /mnt/settings/scripts/set-environment.sh
env

echo
echo "--- Pull images of containers ---"
docker-compose pull

echo
echo "--- Update running instances ---"
docker-compose up -d gateway
