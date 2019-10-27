## rabbitmq-demo

The application presents a simple use of the ``RabbitMQ`` message bus using the ``RawRabbit`` library. It consists of 3 services:

- ``Refuelio.Api`` - system API that listens for all requests (commands)
- ``Refuelio.Services.Cars`` - service for handling logic related to cars
- ``Refuelio.Services.Refuels`` - service used for saving cars refueling informations

> **Note:** The application shares the ``Refuelio.Common`` library, which contains code helpful in configuring the bus and database. It also shares commands and events. In fact, the services should not share the code and I did it for the demo

## How it works: 
1. The API receives a ``CreateCar`` request (command) which places in the correct queue in the bus.
2. ``Refuelio.Services.Cars`` service is subscribed to the appropriate queue and handles all placed ``CreateCar`` commands that will appear in the queue. After processing each command it sends a ``CarCreated`` event to the bus. 
3. ``Refuelio.Services.Refuels`` service is subscribed to the appropriate queue and handles all placed ``CreateRefuel`` commands. It is also subscribed to ``CarCreated`` events.

## Setup
``docker-compose up -d`` command runs ``MongoDB`` and ``RabbitMQ``. 
