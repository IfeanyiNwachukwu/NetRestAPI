# NetRestAPI

-- dotnet dev-certs https --trust    //Trusting the Https certififate
-- dotnet add package Automapper  // add automapper
-- dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection // add automapper dependency injection
-- dotnet add package MongoDB.Driver   // add MongoDB

 docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db  mongo    //run mongo

 -- docker volume ls    // Lists all volumes in docker
 -- docker volume rm /volumeName/  //Removes particular volume

  docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=pass#word1 mongo

-- dotnet user-secrets init
-- dotnet user-secrets set MongoDbSettings:Password /secretPassword/

--dotnet add package AspNetCore.HealthChecks.MongoDb

--ctrl Shift P Add docker files to work space

-- docker build -t catalogueDash/catalogueDash.:v1 . //Build docker image

docker build -t cataloguedash:v1

--docker network create CatalogueBroadcaster //Creating a Network

--  docker network ls //To see all Networks

--  docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=pass#word1  --network=CatalogueBroadcaster mongo // Adding mongo to a created Docker network called CatalogueBroadcaster

-- docker run -it --rm -p 8000:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=pass#word1 --network=CatalogueBroadcaster cataloguedash:v1

-- At this point the images are running in our box... 
-- docker login  // To log into docker from the terminal

PUSHING IMAGES TO DOCKER HUB
-- docker login  // To log into docker from the terminal
-- docker tag cataloguedash:v1 wisdomnwachukwu/cataloguedash:v1 //tag
-- docker push wisdomnwachukwu/cataloguedash:v1 // Actual pushing
-- docker rmi images
-- docker logout

Run images locally that has been pushed
--  docker run -it --rm -p 8000:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=pass#word1 --network=CatalogueBroadcaster wisdomnwachukwu/cataloguedash:v1

Orchestrating with Kubernetes
-- Kubectl config current-context
--  kubectl create secret generic catalogue-secrets --from-literal=mongodb-password='pass#word1'

-- cd .\kubernetes\ //changing directory to the yaml directory
--  kubectl apply -f .\catalogue.yaml
-- kubectl apply -f .\mongodb.yaml
-- kubectl get deployments // gets a list of all created deployments
-- kubectl get pods  // checkout running pods
-- kubectl logs /Name of pod/
--  kubectl get statefulsets

