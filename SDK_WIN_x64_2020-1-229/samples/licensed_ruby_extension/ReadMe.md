# licensed_ruby_extension

The licensed_ruby_extension example uses both the SketchUp Ruby and C API. The example shows how you can communicate between both API's.

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
1. Open licensed_ruby_extension.sln
2. Change configuration to Debug x64 or Release x64 (recommended: Release x64)
3. Build
```

#### Mac
```
1. Open licensed_ruby_extension.xcodeproj
2. Build

Note: The bundle will be in your DerivedData folder for this project.
You can right-click the bundle in the Targets folder to Show in Finder.
```

### Installing the extension

#### Win:
```
1. Go to C:\path\to\license_ruby_extension\Release_x64
2. Copy the .pdb and .so file into C:\path\to\licensed_ruby_extension\RubyExtension\su_licensedrubyextension\bin64
3. Copy all the contents in RubyExtension (should be two things: su_licensedrubyextension.rb and su_licensedrubyextension directory) into your C:\Users\username\AppData\Roaming\SketchUp\SketchUp 2019\SketchUp\Plugins
    You can use this command after you modify the path:
    xcopy /dey "C:\path\to\licensed_ruby_Extension\RubyExtension\*" "C:\path\to\appdata\Roaming\SketchUp\SketchUp 2019\SketchUp\Plugins"
4. Run SketchUp 2019.
5. Go to Extensions -> Licensed Extension.
6. Go to Window -> Ruby Console and type: SUEX_Licensed.do_work

Output should either be "This extension is not licensed" or "Success".
```

#### Mac:
```
1. Go into xcode project after building and locate the Products folder in the project navigator.
2. Right-click the bundle and click Show in Finder.
3. Copy the bundle into ~/path/to/licensed_ruby_extension/RubyExtension/su_licensedrubyextension/bin64
    Note: If bin64 does not exist, create the directory and name it "bin64".
4. Copy all the contents in RubyExtension to your ~/Library/Application Support/SketchUp 2019/SketchUp/Plugins folder.
    You can use this command after you modify the path:
    cp -r "~/path/to/licensed_ruby_extension/RubyExtension" "~/Library/Application Support/SketchUp 2019/SketchUp/Plugins"
5. Run SketchUp 2019.
6. Go to Extensions -> Licensed Extension.
7. Go to Window -> Ruby Console and type: SUEX_Licensed.do_work

Output should either be "This extension is not licensed" or "Success".
```

## Contributions
SketchUp Team