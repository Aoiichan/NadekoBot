# Raspberry pi
This project is tested only on raspbian.<br>
This is more a hack for the moment, check the current [issues][1] !
## Installation guide
### Setup
On Windows :
- Download & install git : https://desktop.github.com/
- Download & install the installer dotnet sdk cli 2.0.3: https://www.microsoft.com/net/learn/get-started/windows
- Clone this repository with git. (On `gitHub.com`, navigate to the `Code` tab of the repository, then on the right side of the screen, click `Clone or download`. Click `Open in Desktop`, this will open GitHub Desktop. Select where you’d like to save it locally under `Local Path` and then click `Clone`)

On Raspberry :
- `sudo apt update`
- `sudo apt upgrade`
- `sudo apt install libunwind8 libunwind8-dev gettext libicu-dev liblttng-ust-dev libcurl4-openssl-dev libssl-dev uuid-dev unzip youtube-dl libopus0 opus-tools libopus-dev libsodium-dev ffmpeg tmux python python3-pip redis-server`

### Build
On windows :
- Open a powershell (in the folder `Ctrl + L` then `powershell`)
- `dotnet restore`
- `dotnet publish -r ubuntu.16.04-arm -c Release`
- Create your `credential.json` : http://nadekobot.readthedocs.io/en/latest/JSON%20Explanations/
- Copy `credential.json` in `./bin/Release/netcoreapp2.0/ubuntu.16.04-arm/publish`.
- :warning: If it's not the 1st install and you want to keep your data, backup/copy the folder `data`.
- Transfert `publish` from `./bin/Release/netcoreapp2.0/ubuntu.16.04-arm/` to the raspberry.
- If saved previously, restore your `data` backup folder in `publish`.

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
