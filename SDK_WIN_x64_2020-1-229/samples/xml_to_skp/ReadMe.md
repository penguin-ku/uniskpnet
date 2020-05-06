# xml_to_skp

The xml_to_skp example is a sample importer for SketchUp. This will import a XML file with legitimate xml format into SketchUp.

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
1. Open xmlimporter.vcxproj
2. Change configuration to Debug x64 or Release x64 (recommended: Release x64)
3. Build
```

#### Mac
```
1. Open XmlImporter.xcodeproj
2. Build

Note: The plugin will be in your DerivedData folder for this project.
You can right-click the plugin in the Targets folder to Show in Finder.
```

### Installing the extension

#### Win:
```
1. Go to C:\path\to\xml_to_skp\win\Release_64
2. Copy/paste xml2skp.dll into C:\Program Files\SketchUp\SketchUp 2019\Importers
3. Open SketchUp 2019.
4. Go to File -> Import.
5. Choose "XML Importer (*.xml)" as your file type.
6. Click on your xml file and click Import.
```

#### Mac:
```
1. Go into xcode project after building and locate the Products folder in the project navigator.
2. Right-click the plugin and click Show in Finder.
3. Copy/paste the plugin into /Applications/SketchUp 2019/SketchUp.app/Contents/PlugIns
4. Run SketchUp 2019.
4. Go to File -> Import.
5. Choose "XML Importer (*.xml)" as your file type.
6. Click on your xml file and click Import.
```

## Contributions
SketchUp Team