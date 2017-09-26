# OperationsDashboard
This project contains many methodologies that would assist in maintaining the KYHBE environment from an operational perspective.


There are a few main components to this system:
 - FrontEnd
 - Redis
 - Pinger
 - PowerShell Execution Console
 - Docker Engine




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
 - Static data is saved to disck automaticly
 - dynamic data will be expected to change constantly
 - expiring data is expected to expire after an arbitrary period of time


#Dev Installation
1. Install [VSCode](https://go.microsoft.com/fwlink/?Linkid=852157) and VS2017 [Community](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15#) or [Professional](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Professional&rel=15)
2. Install [Node.JS](https://nodejs.org/dist/v6.11.3/node-v6.11.3-x64.msi)
3. Install [DotNetCore2.0](https://download.microsoft.com/download/0/F/D/0FD852A4-7EA1-4E2A-983A-0484AC19B92C/dotnet-sdk-2.0.0-win-x64.exe)
4. Install [Docker For Windows](https://download.docker.com/win/edge/Docker%20for%20Windows%20Installer.exe)

powershell Installation:
~~~~ powershell
Set-ExecutionPolicy AllSigned #allows chocolatey to be installed
iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1')) #installs chocolatey
choco install git,vs2017,vscode,nodejs,docker,docker-compose,dotnetcore -y #install a few apps
$url_dotNetCore2 = "https://download.microsoft.com/download/0/F/D/0FD852A4-7EA1-4E2A-983A-0484AC19B92C/dotnet-sdk-2.0.0-win-x64.exe"
invoke-webrequest -uri $url_dotNetCore2 -usebasicparsing -outfile "$env:temp\dotnetcore2.0_Win-x64.exe"
& $env:temp\dotnetcore2.0_Win-x64.exe
~~~~ 
