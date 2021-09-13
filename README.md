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