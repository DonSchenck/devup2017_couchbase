# devup2017_couchbase
Source code for the session ".NET and Couchbase: Using NoSQL is Easier Than You Think" which was present at devupconf 2017 at St. Charles, Missouri, on Monday, October 16, 2017.

## Accompanying slide deck
The accompanying slide deck (using Google Slides) can be found at https://docs.google.com/presentation/d/1ihW3NZOzQlRJVBwci6jpyaBeX-94Z_jCMF9YzhPDT9s/edit?usp=sharing

## But ... what do we have here?
Two simple webapi RESTful services written in C#/.NET Core 2.0 using Couchbase. It was written on a Red Hat Enterprise Linux machine, but Linux *is not* required. However, you will need a Couchbase instance running, and this particular demo uses a Couchbase demo database running in a local (i.e. localhost:8091) Linux container.  

## Environment
This demo was done using .NET Core 2.0, running in a Red Hat Enterprise Linux (RHEL) Virtual Machine (VM). The VM also had docker installed. All of this was done using a Macbook Pro (circa 2016 model) with 16GB RAM.  

### Get Your Environment
You can get a matching environment here:

#### MacOS  
Get the Red Hat Development Suite here: https://developers.redhat.com/download-manager/file/devsuite-2.0.1-GA-bundle-installer-mac.zip

#### Windows
The older, version 1.3.0, of the Red Hat Development Suite works best. You can get it here: https://developers.redhat.com/download-manager/file/devsuite-1.3.0-GA-bundle-installer.exe

#### RHEL  
Follow the instructions at the bottom of this page: https://developers.redhat.com/products/devsuite/download/

## How to use this demo (details of each step are further in this document):  
1. Clone or download this repo.
1. Set up a Couchbase demo database and use the travel-demo database.
1. Build the .NET solutions.
1. Use Swagger to execute HTTP POST and GET operations against this RESTful service.
1. Add to and/or improve the service as an exercise.

### Clone or download this repo
Either use 'git clone' or download the file from this page. It does not matter what you name the directory into which you place it, but `devup2017_couchbase` seems like the best idea.  

### Set up a Couchbase demo database and use the 'travel-demo' database.
The easiest way to do this is to use a Linux container. At the RHEL command line, the following command will get a Couchbase demo instance up and running in seconds:  
`docker run -d --name db -p 8091-8094:8091-8094 -p 11210:11210 couchbase`  

Once the database is up and running, point your browser to localhost:8091 and follow the simple steps to get it set up. *For purposes of this example, make sure you set up the "travel-sample" database.*

**NOTE** If you are running your Linux instance in a VM and you are attempting to access the Couchbase browser-based setup from the host machine (example, you are running RHEL in a VM on a Windows machine), you will need to use the IP address of the VM instead of 'localhost'. For the Red Hat Container Development Kit, for example, that address is 10.1.2.2, so the Couchbase dashboard URL would be `http://10.1.2.2:8091`.

## There are two examples  
Two examples are included in this repo: `demoPOCO` and `demoAnyDoc`.  

`demoPOCO` uses a C# object to POST (insert) data to the database. It forces the user to use the `Airline` object in their request. This strongly-typed example is what a typical service and relation database would use. It has limits.

The `demoAnyDoc` demo allows you to add any JSON document to the database. Further, it introduces the `upsert` database operation, which performs an insert or update based on whether or not an existing, matching object is found.

This example allows infinite flexibility, where you can change data structure without changing your database -- a strength of any NoSQL database.

The instructions for each demo can be found in their respective README.md files. 

--- END ---



### Build the .NET Solution  
Once you are in your directory ('couchbase_demo' if you followed my suggestion, above), use the following commands at the command line:

`dotnet restore`  
`ASPNETCORE_URLS=http://*:5000`  
`dotnet run`

### Use your browser or a tool such as Postman to execute an HTTP GET operation against this RESTful service.  
For example, point your browser (in your host machine) to `10.1.2.2/api/values` and you'll get a JSON document much like the following:  

[{"travel-sample":{"callsign":"MILE-AIR","country":"United States","iata":"Q5","icao":"MLA","id":10,"name":"40-Mile Air","type":"airline"}},{"travel-sample":{"callsign":"TXW","country":"United States","iata":"TQ","icao":"TXW","id":10123,"name":"Texas Wings","type":"airline"}},{"travel-sample":{"callsign":"atifly","country":"United States","iata":"A1","icao":"A1F","id":10226,"name":"Atifly","type":"airline"}},{"travel-sample":{"callsign":null,"country":"United Kingdom","iata":null,"icao":"JRB","id":10642,"name":"Jc royal.britannica","type":"airline"}},{"travel-sample":{"callsign":"LOCAIR","country":"United States","iata":"ZQ","icao":"LOC","id":10748,"name":"Locair","type":"airline"}},{"travel-sample":{"callsign":"SASQUATCH","country":"United States","iata":"K5","icao":"SQH","id":10765,"name":"SeaPort Airlines","type":"airline"}},{"travel-sample":{"callsign":"ACE AIR","country":"United States","iata":"KO","icao":"AER","id":109,"name":"Alaska Central Express","type":"airline"}},{"travel-sample":{"callsign":"FLYSTAR","country":"United Kingdom","iata":"5W","icao":"AEU","id":112,"name":"Astraeus","type":"airline"}},{"travel-sample":{"callsign":"REUNION","country":"France","iata":"UU","icao":"REU","id":1191,"name":"Air Austral","type":"airline"}},{"travel-sample":{"callsign":"AIRLINAIR","country":"France","iata":"A5","icao":"RLA","id":1203,"name":"Airlinair","type":"airline"}}]  

### Add to and/or improve this service as an exercise.
1. Each operation creates a database connection ("cluster"). That code needs to be refactored.  
1. The Update (PUT) and Delete (DELETE) operations have not been written.  
1. Right now, the GET returns the first two items. Making that number configurable and adding paging would be needed if this was going to be used in production.  
1. No exception handling is in place.  
1. Linq2Couchbase is available and would simplify things.  

## Microservices, anyone? ###  
This I would DEFINITELY like to do: Take the CRUD operations and create five different microservices. Use a tool such as Debezium to distribute the database? (I'm just thinking out loud and asking).  
1. A microservice for Create.
1. A microservice to Read *one* item.  
1. A microservice to Read based on a query with paging.  
1. A microservice to Update one item.  
1. A microservice to Delete on item.


--- END ---
