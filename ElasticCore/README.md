# ElasticCore
Logging with ElasticSearch, Kibana, .NET Core 2.1 and Serilog

## What is ElasticSearch?
In simple terms, ElasticSearch is an open source database that is well suited to indexing logs and analytical data.
## What is Kibana?
Kibana is an open source data visualization user interface for ElasticSearch. Think of ElasticSearch as the database and Kibana as the web user interface which you can use to build graphs and query data in ElasticSearch.
## What is Serilog?
Serilog is a plugin for ASP.NET Core that makes logging easy. There are various sinks available for Serilog - for instance you get plain text, SQL and ElasticSearch sinks to name a few.

## How to run the project
The steps are very easy you only have to
* Check if .NET Core sdk version 2.1 installed on your system, you can download it from [Here](https://www.microsoft.com/net/download/dotnet-core/2.1) then check if the instalation has gone correctly by typing
      
      user$ dotnet --version
      user$ 2.1.402
* Restore the dependencies by typing the commande
  
      user$ dotnet restore
* Apply migrations

      user$ docker pull nshou/elasticsearch-kibana
      user$ docker run -d -p 9200:9200 -p 5601:5601 nshou/elasticsearch-kibana
* Finnaly go and run the app by typing

      user$ dotnet run
* Support me by making a <img style="margin-bottom: -20px;" src="https://user-images.githubusercontent.com/24621701/44811262-193e6e00-abcc-11e8-8e61-e52d8c78d5c9.png" /> for the repo and thank you :D , If you want to contribute to the project and make it better, your help is very welcome. 

## Screenshots
![image](https://user-images.githubusercontent.com/24621701/46341959-9c0d7b00-c607-11e8-8d57-3d5f785980be.png)

![image](https://user-images.githubusercontent.com/24621701/46341903-71232700-c607-11e8-90e9-dafdc52e743b.png)



