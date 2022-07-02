# DeskHubSharp Revised

Designed and developed by Wyatt J. Miller, 2022

Licensed by the Mozilla Public License version 2

## Table of Contents

- [Overview](#overview)
- [Building](#building)
  - [Requirements](#requirements)
  - [Getting the source code](#getting-the-source-code)
  - [Deployment](#deployment)
- [Documentation](#documentation)
- [Contribution](#contribution)

## Overview

A cross platform application that shows repository and user data from GitHub, built with Avalonia.

So, I finally done it.

I have built a [project](https://scm.wyattjmiller.com/wymiller/DeskHubSharp) in the past that achieves the same goals as this application (albeit unmaintained), but this project is much, much different. I took the original program, ripped out the WPF bits, and stored all the Avalonia bits where the WPF bits used to be, with a few additions. While this project is going to serve a great portion of what the original project did, there are a few adjustments, and perhaps a few additions. 

I also ripped out the legacy .NET Framework and put .NET 6 in it's place, which brings many [improvements](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6).

###### What is Avalonia?

Think WPF but cross platform. Avalonia still runs your favorite declarative language, XAML, but applies a different drawing library, Skia (SkiaSharp). What Skia allows Avalonia to do is draw windows, buttons, and other widgets on not just Windows, but macOS, Linux, Android, and iOS. Even Web Assembly! Learn more [here](http://avaloniaui.net/).

###### 🚧👷‍♂️ All developers! Wear your hard hats! 🚧👷‍♂️

This application is still in the porting process. Don't worry though! It's being worked on. Please file an [issue]() if find anything that shouldn't be happening.

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

All build tasks go through the `dotnet` command. 

If you want to build for development, run:

`dotnet run --project DeskHubSharpRevised/DeskHubSharpRevised.csproj`

If you want to build for production for Linux, run:

`dotnet publish DeskHubSharpRevised/DeskHubSharpRevised.csproj --configuration Release --framework net6.0 --output publish --self-contained True --runtime linux-x64 --verbosity Normal /property:PublishTrimmed=True /property:PublishSingleFile=True /property:IncludeNativeLibrariesForSelfExtract=True /property:DebugType=None /property:DebugSymbols=False`

If you want to build for production for Windows, run:

`dotnet publish DeskHubSharpRevised/DeskHubSharpRevised.csproj --configuration Release --framework net6.0 --output publish --self-contained True --runtime win-x64 --verbosity Normal /property:PublishTrimmed=True /property:PublishSingleFile=True /property:IncludeNativeLibrariesForSelfExtract=True /property:DebugType=None /property:DebugSymbols=False`

These tasks are supposed to be replaced with Cake in the near future.

## Documentation

To see the developer documentation, please run the following command in Powershell/bash:

`doxygen`

Please note that you have to be in the root of the cloned directory to generate the documentation. Alternatively, you specify the configuration file, `Doxyfile`, using the following command:

`doxygen /path/to/Doxyfile`

Also note that this step is optional. This step only generates documentation, which isn't used in running the program.

## Contribution

Issues and pull requests are more than welcome.

I don't have a style guide yet.
