# FruityViceAPI

This project is build in ASPNET Core 3.1 Framework.

This is the implementation of Fruityvice Public APIs.
It uses HTTPClient Library in order to connect with the external APIs of Fruityvice

Just Clone the project and run it in your Visual Studio. It should start the Swagger directly and you can see all the endpoints.

This has all the implementation of the API available in the Fruityvice website.

The Project is using a Simple Architecture like

Request ----> Controller ----> Services ----> HttpClient (FruityviceConnection)

It also contains one Unit Test Project which is build using Xunit Test Framework.
