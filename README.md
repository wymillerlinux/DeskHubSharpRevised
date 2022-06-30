# DeskHubSharp Revised

Designed and developed by Wyatt J. Miller, 2022

Licensed by the Mozilla Public License version 2

## Building

### Requirements

You must have the following to build from source:

- .NET 6.0
- git
- Doxygen (optional)

### Getting the source code

Clone using the following command:

`git clone https://scm.wyattjmiller.com/wymiller/DeskHubSharpRevised`

### Deployment

If you want to build for development, run:

`dotnet build`

If you want to build for production for Linux, run:

`dotnet publish DeskHubSharpRevised/DeskHubSharpRevised.csproj --configuration Release --framework net6.0 --output publish --self-contained True --runtime linux-x64 --verbosity Normal /property:PublishTrimmed=True /property:PublishSingleFile=True /property:IncludeNativeLibrariesForSelfExtract=True /property:DebugType=None /property:DebugSymbols=False`

If you want to build for production for Windows, run:

`dotnet publish DeskHubSharpRevised/DeskHubSharpRevised.csproj --configuration Release --framework net6.0 --output publish --self-contained True --runtime win-x64 --verbosity Normal /property:PublishTrimmed=True /property:PublishSingleFile=True /property:IncludeNativeLibrariesForSelfExtract=True /property:DebugType=None /property:DebugSymbols=False`

## Documentation

To see the documentation, please run the following command in Powershell/bash:

`doxygen`

Please note that you have to be in the root of the cloned directory to generate the documentation. Alternatively, you specify the configuration file, `Doxyfile`, using the following command:

`doxygen /path/to/Doxyfile`

## Contribution

Issues and pull requests are more than welcome.
