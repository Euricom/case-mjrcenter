echo "--- Dump logs for all containers ---"
for fn in `docker ps -qa`; do
    echo "--- Start log for container: $fn ---"
    docker logs $fn
    echo "---- End log for container: $fn ----"
done

echo
echo "--- Remove any stopped containers ---"
for fn in `docker ps -q -f "status=exited"`; do
    echo "--- Removing container: $fn ---"
    docker rm -f $fn
done

echo
echo "--- Show running containers ---"
docker ps
