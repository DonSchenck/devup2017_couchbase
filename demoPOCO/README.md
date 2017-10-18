

### Build the .NET Solution  
Once you are in your directory ('couchbase_demo' if you followed my suggestion, above), use the following commands at the command line:

`dotnet restore`  
`ASPNETCORE_URLS=http://*:5000`  
`dotnet run`

### Use your browser or a tool such as Postman to execute an HTTP GET operation against this RESTful service.  
For example, point your browser (in your host machine) to `10.1.2.2/api/values` and you'll get a JSON document much like the following:  

[{"travel-sample":{"callsign":"MILE-AIR","country":"United States","iata":"Q5","icao":"MLA","id":10,"name":"40-Mile Air","type":"airline"}},{"travel-sample":{"callsign":"TXW","country":"United States","iata":"TQ","icao":"TXW","id":10123,"name":"Texas Wings","type":"airline"}},{"travel-sample":{"callsign":"atifly","country":"United States","iata":"A1","icao":"A1F","id":10226,"name":"Atifly","type":"airline"}},{"travel-sample":{"callsign":null,"country":"United Kingdom","iata":null,"icao":"JRB","id":10642,"name":"Jc royal.britannica","type":"airline"}},{"travel-sample":{"callsign":"LOCAIR","country":"United States","iata":"ZQ","icao":"LOC","id":10748,"name":"Locair","type":"airline"}},{"travel-sample":{"callsign":"SASQUATCH","country":"United States","iata":"K5","icao":"SQH","id":10765,"name":"SeaPort Airlines","type":"airline"}},{"travel-sample":{"callsign":"ACE AIR","country":"United States","iata":"KO","icao":"AER","id":109,"name":"Alaska Central Express","type":"airline"}},{"travel-sample":{"callsign":"FLYSTAR","country":"United Kingdom","iata":"5W","icao":"AEU","id":112,"name":"Astraeus","type":"airline"}},{"travel-sample":{"callsign":"REUNION","country":"France","iata":"UU","icao":"REU","id":1191,"name":"Air Austral","type":"airline"}},{"travel-sample":{"callsign":"AIRLINAIR","country":"France","iata":"A5","icao":"RLA","id":1203,"name":"Airlinair","type":"airline"}}]  




--- END ---
