#!/bin/bash
set -e

command -v docker >/dev/null 2>&1 || {
    echo 'I require docker, but it is not installed. Please install docker'
    exit 1
}

while getopts c:d:h:H:l:p:r:s:S:u:v: optname; do
    case $optname in
    c)
        CONNECT_STR=${OPTARG}
        ;;
    d)
        DB_NAME=${OPTARG}
        ;;
    h)
        HA_API_KEY=${OPTARG}
        ;;
    H)
        HA_ENDPOINT=${OPTARG}
        ;;
    l)
        LDAP_SERVER=${OPTARG}
        ;;
    p)
        DOCKER_PASSWORD=${OPTARG}
        ;;
    s)
        SVC_ACCOUNT_USER=${OPTARG}
        ;;
    S)
        SVC_ACCOUNT_PASSWORD=${OPTARG}
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

echo 'Building image...'
docker build \
-t $DOCKER_USERNAME/unionized-api:$BUILD_VERSION \
--build-arg dbConnectStr="'$CONNECT_STR'" \
--build-arg dbName=$DB_NAME \
--build-arg haApiKey=$HA_API_KEY \
--build-arg haEndpoint=$HA_ENDPOINT \
--build-arg ldapServer=$LDAP_SERVER \
--build-arg svcAccountUser=$SVC_ACCOUNT_USER \
--build-arg svcAccountPassword=$SVC_ACCOUNT_PASSWORD \
-f Dockerfile .

echo 'Logging in to Docker...'
echo $DOCKER_PASSWORD | docker login -u $DOCKER_USERNAME --password-stdin

echo 'Pushing to registry...'
docker push $DOCKER_USERNAME/unionized-api:$BUILD_VERSION

echo 'Done'
exit 0