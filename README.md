# NetRestAPI

-- dotnet dev-certs https --trust    //Trusting the Https certififate
-- dotnet add package Automapper  // add automapper
-- dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection // add automapper dependency injection
-- dotnet add package MongoDB.Driver   // add MongoDB

 docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db  mongo    //run mongo
