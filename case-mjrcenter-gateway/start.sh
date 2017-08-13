echo "--- Read environment settings ---"
. /mnt/settings/scripts/set-environment.sh
env

echo
echo "--- Cleanup running instances ---"
/usr/local/bin/docker-compose kill

echo
echo "--- Pull images of containers ---"
/usr/local/bin/docker-compose pull

echo
echo "--- Build fresh containers ---"
/usr/local/bin/docker-compose build

echo
echo "--- Start containers ---"
/usr/local/bin/docker-compose up -d gateway

echo
. /usr/local/bin/mjrcenter-gateway/show-status.sh

echo "--- Done. ---"