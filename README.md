# Microsservices project
This is my personal microsservices project

# Technology
The project is using .NET 6, RabbitMQ, MySQL and API Gateway Ocelot.

# Structure 
The project has been modeled as the diagram as follow:
<br>
-- Integration Services receive the request from the gateway and apply businnes logic.
<br>
-- DB Services is responsible to persist de data in DB.
<br>
-- Payment Service receive payments from outside and put on a Exchange on Rabbit.
<br>
-- The Exchange put the payments on a queue to persist the data, and in another queue to update the respectively Payment Order.
<br>
<img align="center" alt="diagram"  src="https://github.com/dalmasiof/microsservice_project/blob/master/microservices%20diagram.png">.
