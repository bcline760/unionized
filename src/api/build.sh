#!/bin/bash
set -e

command -v docker >/dev/null 2>&1 || {
    echo 'I require docker, but it is not installed. Please install docker'
    exit 1
}

while getops p:r:u:v: optname; do
    case $optname in
    p)
        DOCKER_PASSWORD=${OPTARG}
        ;;
    r)
        REGISTRY_URL=${OPTARG}
        ;;
    u)
        DOCKER_USERNAME=${OPTARG}
        ;;
    v)
        BUILD_VERSION=${OPTARG}
        ;;
    \?)
        echo 'Usage: build.sh -pruv [arg] [arg] ...'
        exit 2
        ;;
    : )
        echo 'Usage: build.sh -pruv [arg] [arg] ...'
        exit 2
        ;;
    esac
done

echo 'Logging in to Docker...'
docker login $REGISTRY_URL -u $DOCKER_USERNAME -p $DOCKER_PASSWORD

echo 'Building image...'
docker build -t unionized-api:$BUILD_VERSION -f Dockerfile

echo 'Pushing to registry...'
docker push unionized-api:$BUILD_VERSION

echo 'Done'
exit 0