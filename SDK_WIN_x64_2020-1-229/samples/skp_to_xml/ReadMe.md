# skp_to_xml

The skp_to_xml example is a sample exporter for SketchUp. This will export the SketchUp model into an xml file.

## Getting Started

Checkout the repo
```
git checkout shenanigans local-shenanigans
```

See Build and Installing the extension for notes on how to run the project on specific OS platforms.

### Prerequisites

#### Windows
Minimum of [Windows Visual Studio 2015](https://www.visualstudio.com/vs/older-downloads/)

#### Mac
Minimum of Xcode 7.2 with [MacOSX 10.10 sdk](https://github.com/phracker/MacOSX-SDKs)

If you want to use a newer Visual Studio, then make sure you have the 2015 compiler installed. [More info.](https://blogs.msdn.microsoft.com/vcblog/2017/11/02/visual-studio-build-tools-now-include-the-vs2017-and-vs2015-msvc-toolsets/)

### Build

How to run the projects for each platform.

#### Windows
```
1. Open skp2xml.vcxproj
2. Change configuration to Debug x64 or Release x64 (recommended: Release x64)
3. Build
```

#### Mac
```
1. Open XMLExporter.xcodeproj
2. Build

Note: The plugin will be in your DerivedData folder for this project.
You can right-click the plugin in the Targets folder to Show in Finder.
```

### Installing the extension

#### Win:
```
1. Go to C:\path\to\skp_to_xml\win\Release_64
2. Copy/paste skp2xml.dll into C:\Program Files\SketchUp\SketchUp 2019\Exporters
3. Open SketchUp 2019 and create a model.
4. Go to File -> Export -> 3D Model
5. Choose "XML Exporter (*.xml)" as your Save as type.
6. Give the xml a filename and click Export.
```

#### Mac:
```
1. Go into xcode project after building and locate the Products folder in the project navigator.
2. Right-click the plugin and click Show in Finder.
3. Copy/paste the plugin into /Applications/SketchUp 2019/SketchUp.app/Contents/PlugIns
4. Run SketchUp 2019 and create a model.
5. Go to File -> Export - 3D Model.
6. Choose "XML Exporter (*.xml)" as your Save type.
7. Give the xml a filename and click Export.
```

## Contributions
SketchUp Team