This repo includes a simple and minimal Win2D sample in an unpackaged Win32 app.

### How to build ⚙️

From a VS Developer Command Prompt:

```ps
msbuild Win2DRenderer.csproj -t:restore,publish /p:Configuration=Release /p:Platform=x64 /p:PublishSingleFile=True /p:SelfContained=True /p:PublishTrimmed=True /p:RuntimeIdentifier=win10-x64
```

This will create a self-contained build.

To publish with NativeAOT, use:

```ps
$env:ENABLE_PUBLISH_AOT='true';
msbuild Win2DRenderer.csproj -t:restore,publish /p:Configuration=Release /p:Platform=x64 /p:RuntimeIdentifier=win10-x64
```

Optionally, you can change the executable to skip the console, by also defining:

```ps
$env:HIDE_CONSOLE='true';
```