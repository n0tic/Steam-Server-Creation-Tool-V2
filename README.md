# Steam Server Creation Tool V2 #
<p align="left">
  <img alt="GitHub release (latest by date including pre-releases)" src="https://img.shields.io/github/v/release/n0tic/SteamServerCreationTool?color=seagreen&include_prereleases">
  <img src="https://img.shields.io/badge/status-Alpha-blue" />
  <img alt="GitHub all releases" src="https://img.shields.io/github/downloads/n0tic/Steam-Server-Creation-Tool-V2/total?color=orange&label=downloads">
  <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/n0tic/Steam-Server-Creation-Tool-V2?color=crimson">
  <a href="https://visitorbadge.io/status?path=https%3A%2F%2Fgithub.com%2Fn0tic%2FSteam-Server-Creation-Tool-V2"><img src="https://api.visitorbadge.io/api/combined?path=https%3A%2F%2Fgithub.com%2Fn0tic%2FSteam-Server-Creation-Tool-V2&countColor=%23263759&style=flat-square" /></a>
</p>


<img src="https://github.com/n0tic/Steam-Server-Creation-Tool-V2/blob/master/Steam%20Server%20Creation%20Tool%20V2/Resources/SteamCMD.png" alt="Image Preview" />

Steam Server Creation Tool V2 is a utility designed to simplify downloading and managing multiplayer game servers originally distributed through Steam. Instead of relying on manual SteamCMD console commands, it provides a user-friendly interface that makes installation, updates, and server management easier and more accessible.

Due to Steam deprecating the API previously used to retrieve server data, the tool now operates using a maintained, precompiled server database included with the project. This ensures the application remains functional and reliable even as Steam adds, removes, or changes available server packages.

---------------------------------------------------------------------------------------------------------------------------------
# Links
[Discord Group](https://discord.gg/WypdXXJ34p)

[Steam Group](https://steamcommunity.com/groups/SSCTV2)

[Video](https://www.youtube.com/watch?v=aWx8Dah6AcA)

[Downloads / Releases](https://github.com/n0tic/Steam-Server-Creation-Tool-V2/releases)

# Requirements
- Internet Connection
- .NET Framework 4.8
- Newtonsoft Json (Included)

# How does it work?
- Application fetch steam "apps":
  - Database: https://raw.githubusercontent.com/n0tic/Steam-Server-Creation-Tool-V2/master/Steam%20Server%20Creation%20Tool%20V2/servers.json
- Application fetch steamcmd from:
  - Direct: https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip
  - Website: https://developer.valvesoftware.com/wiki/SteamCMD


# StartServerScript?
WARNING: If you are using a username and password; the password will be in clear text format in the script! 
NOTE: This is not a required/needed feature to run a servers. It's a bonus feature which you can use if you want.

Within the root folder of the created server, you will find a generated batch (.bat) file named "StartServerScript.bat." This file serves as a supplementary tool for the server, automating tasks such as updating the server and validating files before initiating the startup process. In the event of a server crash during execution via the StartServerScript, the tool will automatically initiate a server restart.

Before this script can be used correctly it will will need to be updated with valid information. 
You need to edit rows 19, 20, 21. In this example you see the valheim server setup.
```
SET serverExecutablePath=D:\Valheim Server
SET serverExecutableFileName=valheim_server.exe
SET serverLaunchOptions=-nographics -batchmode -name "MyFirstServer" -port 2456 -world "DedicatedServer" -password "SomePasswordHere"
```
From what we can see above we have the valheim server located at the "D:\" drive and inside the folder "Valheim Server".
The server is set to launch the file "valheim_server.exe" with the launch options:

-nographics -batchmode -name "MyFirstServer" -port 2456 -world "DedicatedServer" -password "SomePasswordHere"

If this would be valid information, the script would then run the server and monitor that process. If this window is closed or the server has crashed, the server will automatically be restarted as the StartServerScript is protecting the process. In order to stop the server from restarting you need to close the StartServerScript first - Alternatively, select Y to terminate the process; When prompted. NOTE: Some servers require/want you to close the server with the CTRL+C command.

Note: In the event of issues connecting to the server, server crashes, or misconfigurations, troubleshooting and configuration adjustments will be required. This aspect falls outside the scope of the script itself. Best of luck!

# AutoUpdater

The **AutoUpdater** is an addition to the **Steam Server Creation Tool V2** program. If you choose to download and use it, make sure you place the `AutoUpdater.exe` in the same folder as the **Steam Server Creation Tool V2** executable. Additionally, you need to enable the "Allow AutoUpdater" feature in the **Steam Server Creation Tool V2** settings (checkbox in the middle).

Once set up, when you check for updates, the program will give you an option if a newer version is available. If everything is configured correctly, the AutoUpdater will automatically download the latest release, update your current installation, and restart the application. 

In case of any issues, it should open the download page in your browser, allowing you to manually download and install the latest version.

# Bugs?


# Disclamer
Newtonsoft Json:
```
The MIT License (MIT)

Copyright (c) 2007 James Newton-King

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```

All files are provided as-is with no express or implied warranty. No liability for content in external links.

I am not affiliated, associated, endorsed by, or in any way officially connected with Steam, Valve, or any of its subsidiaries or affiliates. Steam Server Creation Tool V2 and all its content are provided 'as is' and 'with all faults.' I make no representations or warranties of any kind regarding safety, suitability, inaccuracies, typographical errors, or other potential issues. I do not guarantee the accuracy or completeness of any information or usage on or in this project or found by following any link.

There are inherent risks in the use of any software, and you are solely responsible for determining whether this software is compatible with your equipment and other software installed on it. You are also solely responsible for the protection of your equipment and backup of your data. The Steam Server Creation Tool V2 will not be liable for any damages you may suffer in connection with using, modifying, or distributing SSCT | Steam Server Creation Tool.

# More Previews!

Youtube video:
[![Watch the video](https://img.youtube.com/vi/aWx8Dah6AcA/maxresdefault.jpg)](https://www.youtube.com/watch?v=aWx8Dah6AcA)


![Image Preview](https://github.com/n0tic/Steam-Server-Creation-Tool-V2/blob/master/Steam%20Server%20Creation%20Tool%20V2/Resources/SteamCMD.png)
![Image Preview](https://github.com/n0tic/Steam-Server-Creation-Tool-V2/blob/master/Steam%20Server%20Creation%20Tool%20V2/Resources/NewServer.png)
![Image Preview](https://github.com/n0tic/Steam-Server-Creation-Tool-V2/blob/master/Steam%20Server%20Creation%20Tool%20V2/Resources/ManageServers.png)
![Image Preview](https://github.com/n0tic/Steam-Server-Creation-Tool-V2/blob/master/Steam%20Server%20Creation%20Tool%20V2/Resources/PortScan.png)
![Image Preview](https://github.com/n0tic/Steam-Server-Creation-Tool-V2/blob/master/Steam%20Server%20Creation%20Tool%20V2/Resources/ConsoleWindow.png)
![Image Preview](https://github.com/n0tic/Steam-Server-Creation-Tool-V2/blob/master/Steam%20Server%20Creation%20Tool%20V2/Resources/Settings.png)




This project is not affiliated with, endorsed by, or associated in any way with Steam or Valve Corporation.
