# Raspberry pi
This project is tested only on raspbian.<br>
This is more a hack for the moment, check the current [issues][1] !
## Installation guide
### Setup
On Windows :
- Download & install git : https://desktop.github.com/
- Download & install the installer dotnet sdk cli 2.1.0: https://github.com/dotnet/cli
- Clone this repository with git.
- Open a terminal in `src/NadekoBot` (windows with `ctrl + L` + `powershell` because `cmd` doesn't work).
- Add the pkg [EntityFrameworkCore.Tools.Dotnet][3] with
```
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet --version 2.1.0-preview1-26462 --source https://dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json
```
- Add the pkg [Microsoft.NETCore.App][4] with
```
dotnet add package Microsoft.NETCore.App --version 2.1.0-preview2-25601-02 --source https://dotnet.myget.org/F/dotnet-core/api/v3/index.json
```
On Raspberry :
- `sudo apt update`
- `sudo apt upgrade`
- `sudo apt install libunwind8 libunwind8-dev gettext libicu-dev liblttng-ust-dev libcurl4-openssl-dev libssl-dev uuid-dev unzip`

### Build
On windows :
- `dotnet restore`
- `dotnet publish -r ubuntu.16.04-arm -c Release`
- Create your `credential.json` : http://nadekobot.readthedocs.io/en/latest/JSON%20Explanations/
- Copy `credential.json` in `./bin/Release/netcoreapp2.0/ubuntu.16.04-arm/publish`.
- Transfert `publish` from `./bin/Release/netcoreapp2.0/ubuntu.16.04-arm/` to the raspberry.

On raspberry :
- Go into the `publish` folder.
- `chmod a+xrw *` (you can set more appropriates permissions, but this isn't the purpose of this guide).
- `./NadekoBot`, 1st boot can take 2min. You can use `tmux` for background run : [guide][5].

## Issues
If you have an issue, report it [here][2].
Check current issues [here][1].

[1]:https://github.com/Taknok/NadekoBot/issues
[2]:https://github.com/Taknok/NadekoBot/issues/new
[3]:https://dotnet.myget.org/feed/aspnetcore-dev/package/nuget/Microsoft.EntityFrameworkCore.Tools.DotNet
[4]:https://dotnet.myget.org/feed/dotnet-core/package/nuget/Microsoft.NETCore.App/2.1.0-preview2-25601-02
[5]:http://nadekobot.readthedocs.io/en/latest/guides/Linux%20Guide/#additional-information
Credits : Kwoth and everyone else working on NadekoBot
