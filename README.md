# GtaVMod

This is a custom GTA V mod running on RageMP with a .NET server-side

## DEMO

## Features
### Authentication

- `/register [password]`  
  Register a new account on the server with a password. Once registered, the player is marked as logged in.

- `/login [password]`  
  Log in with a previously registered account. All gameplay commands require the player to be logged in.


### Player Commands

- `/pos`  
  View your current X, Y, Z coordinates.

- `/tp [x] [y] [z]`  
  Teleport to specified coordinates.

- `/quit`  
  Disconnect from the server

### Economy System

- `/money`  
  Check your current money balance.

- `/give [player] [amount]`  
  Give money to the specific player by name.

### Vehicle System

- `/veh [model]`  
  Spawn a vehicle of the specified model near your current position.  
  *(Example: `/veh t20`)*
## Prerequisites

- **Rage Multiplayer Server** installed and set up: https://rage.mp/
- **.NET Core SDK** (3.1): https://dotnet.microsoft.com/download
- **PostgreSQL** database server installed and running: https://www.postgresql.org/download/

## Local Setup Instructions

1. Download the RAGE Multiplayer Client
2. Retrieve Server Files (`server_files` folder)
3. Enable csharp in `service_filies/conf.json`
<img width="499" height="331" alt="image" src="https://github.com/user-attachments/assets/1bedfbb2-ab07-4974-af23-0558e1e943ea" />

5. Execute `updater.exe`
6. Inside `servicer-files/dotnet` folder open settings.xml and add this line `<resource src="GtaVMod" />`. It should look like this
<img width="1142" height="273" alt="image" src="https://github.com/user-attachments/assets/6930095e-c4c4-4093-91f3-ad0d9e382119" />

7. Open `dotnet/resources` folder (if you can't find this folder, just create it)
8. Create a new folder, called `GtaVMod` there
9. Clone the repo to this folder
10. Build the project to obtain DLL.
11. Start `service-files/ragemp-server.exe`
12. Finally, connect to the 127.0.0.1:22005 via RAGE MP
