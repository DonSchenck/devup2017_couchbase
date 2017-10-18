

### Build the .NET Solution  
Once you are in your directory ('/devup2017_couchbase/demoAnyDoc' if you followed my suggestion), use the following commands at the command line:

`dotnet restore`  
`ASPNETCORE_URLS=http://*:5000`  
`dotnet run`

### Point your browser to the Swagger URI for this project 
Point your browser (in your host machine) to `10.1.2.2:5000/Swagger`.

Select the first option, the `Get` operation, and click the "Try it out!" button. You'll get a JSON document much like the following:  

[{"travel-sample":{"callsign":"MILE-AIR","country":"United States","iata":"Q5","icao":"MLA","id":10,"name":"40-Mile Air","type":"airline"}},{"travel-sample":{"callsign":"TXW","country":"United States","iata":"TQ","icao":"TXW","id":10123,"name":"Texas Wings","type":"airline"}},{"travel-sample":{"callsign":"atifly","country":"United States","iata":"A1","icao":"A1F","id":10226,"name":"Atifly","type":"airline"}},{"travel-sample":{"callsign":null,"country":"United Kingdom","iata":null,"icao":"JRB","id":10642,"name":"Jc royal.britannica","type":"airline"}},{"travel-sample":{"callsign":"LOCAIR","country":"United States","iata":"ZQ","icao":"LOC","id":10748,"name":"Locair","type":"airline"}},{"travel-sample":{"callsign":"SASQUATCH","country":"United States","iata":"K5","icao":"SQH","id":10765,"name":"SeaPort Airlines","type":"airline"}},{"travel-sample":{"callsign":"ACE AIR","country":"United States","iata":"KO","icao":"AER","id":109,"name":"Alaska Central Express","type":"airline"}},{"travel-sample":{"callsign":"FLYSTAR","country":"United Kingdom","iata":"5W","icao":"AEU","id":112,"name":"Astraeus","type":"airline"}},{"travel-sample":{"callsign":"REUNION","country":"France","iata":"UU","icao":"REU","id":1191,"name":"Air Austral","type":"airline"}},{"travel-sample":{"callsign":"AIRLINAIR","country":"France","iata":"A5","icao":"RLA","id":1203,"name":"Airlinair","type":"airline"}}]  

That's great, but let's add some data to an existing JSON document.

We're going to add some Delta Sky Club lounge information to the Atlanta airport document. First, let's get the original document and see what it looks like.

On the Swagger page, go to the second `Get` operation, the one with `/api/Values/{id}` as the route. After you expand that section of the page, you'll see that you can enter parameters. There is a prompt for one parameter: id. Enter `airport_3682` and click the "Try it out!" button.  

The Response Body will contain the JSON document for the Hartsfield Jackson Atlanta airport.

To add data to this JSON document, open the `Post` operation section of your Swagger page and paste in the contents of the file `deltaupsert2.json`, located in the same directory as this project. Click the "Try it out!" button.

Now return to the `Get` with `/api/Values/{id}` section and click the "Try it out!" button to retrieve the updated JSON document. You'll notice that some Delta Sky Club lounge information has been added.

Finally, select the Query section of your Couchbase website (the dashboard) and paste in the query from the file `ComplexQuery.n1ql` located in the same directory as this project. This will give you a better user experience at viewing the data.

As you can see, you add any data to any JSON document without changing your database configuration.

### Note
In fact, the operations for this example *should* be along the lines of

GET /airlines/
GET /airlines/{id}
GET /airports/
GET /airports/{id}

etc etc.
--- END ---
