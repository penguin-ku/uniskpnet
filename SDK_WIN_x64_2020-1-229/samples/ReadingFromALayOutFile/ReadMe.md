# ReadingFromALayOutFile

The ReadingFromALayOutFile example takes a LayOut file and prints the pages and layers contained in the document.

In the example, it contains the SimpleHouse.layout file that it uses to get the data.

## Getting Started

Checkout the repo
```
git checkout shenanigans local-shenanigans
```

See Build and Run for notes on how to run the project on specific OS platforms.

### Prerequisites

#### Windows
Minimum of [Windows Visual Studio 2015](https://www.visualstudio.com/vs/older-downloads/).

#### Mac
Minimum of Xcode 7.2 with [MacOSX 10.10 sdk](https://github.com/phracker/MacOSX-SDKs).

If you want to use a newer Visual Studio, then make sure you have the 2015 compiler installed. [More info](https://blogs.msdn.microsoft.com/vcblog/2017/11/02/visual-studio-build-tools-now-include-the-vs2017-and-vs2015-msvc-toolsets/).

### Build and Run

How to run the projects for each platform.

#### Windows
```
Open ReadingFromALayOutFile.sln
Change configuration to Debug x64 or Release x64
Build and Run
```

#### Mac
```
Open ReadingFromALayOutFile.xcodeproj
Build and Run

Note: The executable will be in your DerivedData folder for this project.
You can right-click the executable in the Targets folder to Show in Finder.
```

### Execute the program

#### Win:
```
C:\path\ReadingFromALayOutFile.exe <inputfile>
```

#### Mac:
```
~/path/ReadingFromALayOutFile <inputfile>
```
Full options are
```
Usage:
  ReadingFromALayOutFile <inputfile>

  inputfile can be any .layout file.
```

## Contributions
SketchUp Team