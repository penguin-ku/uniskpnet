# GenerateLayoutFromSkp

The GenerateLayoutFromSkp example takes a SketchUp file and takes the data to generate a LayOut file.

In the example, it contains the SimpleHouse.skp file that it uses to generate the Layout file.

## Getting Started

Checkout the repo
```
git checkout shenanigans local-shenanigans
```

See Build and Run for notes on how to run the project on specific OS platforms.

### Prerequisites

#### Windows
Minimum of [Windows Visual Studio 2015](https://www.visualstudio.com/vs/older-downloads/)

#### Mac
Minimum of Xcode 7.2 with [MacOSX 10.10 sdk](https://github.com/phracker/MacOSX-SDKs)

If you want to use a newer Visual Studio, then make sure you have the 2015 compiler installed. [More info.](https://blogs.msdn.microsoft.com/vcblog/2017/11/02/visual-studio-build-tools-now-include-the-vs2017-and-vs2015-msvc-toolsets/)

### Build and Run

How to run the projects for each platform.

#### Windows
```
Open GenerateLayOutFromSkp.sln
Change configuration to Debug x64 or Release x64
Build and Run
```

#### Mac
```
Open GenerateLayOutFromSkp.xcodeproj
Build and Run

Note: The executable will be in your DerivedData folder for this project.
You can right-click the executable in the Targets folder to Show in Finder.
```

### Execute the program

#### Win:
Note: Make sure `SimpleHouse.skp` is located in the same directory as the executable.

```
C:\path\to\GenerateLayOutFromSkp.exe

Outputs a new file:
  C:\path\to\executable\Letter Landscape.layout
```

#### Mac:
```
~/path/to/GenerateLayOutFromSkp

Outputs a new file:
  ~/path/to/executable/Letter Landscape.layout
```

## Contributions
SketchUp Team