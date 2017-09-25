# OperationsDashboard
This project contains many methodologies that would assist in maintaining the KYHBE environment from an operational perspective.


There are a few main components to this system:
-FrontEnd
-Redis
-Pinger
-PowerShell Execution Console
-Docker Engine



## Docker Engine
The docker engine allows us to host as many copies of each type of component, while maintaining a unified view of the architecture.
Each part could be running in multiple instances, on multiple servers, in such a way that it can be reached at any time, with an availability at 99.9999% (4x9's).

## FrondEnd
The front end is the only part that will be directly visible to users.

## Pinger
This container type is responsible for hitting every server in the environment, and reporing it to the Redis database quickly.

## PowerShell Execution Console
This container is responsible for running PowerShell within the context of the KYHBE environment.

## Backend WebAPi
This container manages the connections and logic between all other containers, and as such is the only container type that any other container is connected to.

## Redis
This container is a database functioning in 3 different types- static, dynamic, and expiring.
-Static data is saved to disck automaticly
-dynamic data will be expected to change constantly
-expiring data is expected to expire after an arbitrary period of time