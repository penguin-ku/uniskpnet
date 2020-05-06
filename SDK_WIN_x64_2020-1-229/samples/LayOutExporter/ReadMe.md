# LayOutExporter

The LayOutExporter example takes a LayOut file and exports it to a image file (.jpg or .png)

In the example, it contains the SimpleHouse.layout file that it uses to generate the image file.

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
Open LayOutExporter.sln
Change configuration to Debug x64 or Release x64
Build and Run
```

#### Mac
```
Open LayOutExporter.xcodeproj
Build and Run

Note: The executable will be in your DerivedData folder for this project.
You can right-click the executable in the Targets folder to Show in Finder.
```

### Execute the program

#### Win:
```
C:\path\LayoutExporter.exe -i <inputfile> -o <outputfile>
```

#### Mac:
```
~/path/LayoutExporter -i <inputfile> -o <outputfile>
```
Full options are
```
Required:
-i    inputfile   Specifies the input .layout file. Required.

-o    outputfile  Specifies the output PDF, JPG, or PNG file. Required.

Optional:
-r    resolution  Specifies the output resolution for images when exporter
                  to PDF. Must be one of 'low', 'medium', or 'high'.
                  If not specified, it defaults to the document's output
                  resolution setting.

-dpi  dpi         Specifies the output image DPI when exporting to JPG or PNG.
                  If not specified, it defaults to 96.

-sp   startpage   Specified the index of the first page to export.
                  If not specified, it defaults to 0.

-ep   endpage     Specified the index of the last page to export.
                  If not specified, it defaults to the index of the last page
                  in the layout document.

-nc               Specifies that JPEG image compression should be disabled
                  when exporting to PDF. This usually results in larger PDF files.
                  If not specified, JPEG image compression will be enabled.

-cq   quality     Specifies the JPEG image compression quality from 0.0 to 1.0
                  to use when exporting to PDF with JPEG image compression enabled.
                  If not specified, it defaults to 0.5.

-h                Displays this help information.
```

## Contributions
SketchUp Team