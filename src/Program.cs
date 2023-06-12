using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using ComputeSharp.D2D1.WinUI;
using Microsoft.Graphics.Canvas;
using Win2DRenderer.Backend;
using Win2DRenderer.Shaders;

[assembly: DisableRuntimeMarshalling]

string applicationDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
string texturePath = Path.Combine(applicationDirectory, "Assets", "texture.png");
string heightmapPath = Path.Combine(applicationDirectory, "Assets", "heightmap.png");

// Load the two bitmaps we need
CanvasBitmap texture = await CanvasBitmap.LoadAsync(CanvasDevice.GetSharedDevice(), texturePath);
CanvasBitmap heightmap = await CanvasBitmap.LoadAsync(CanvasDevice.GetSharedDevice(), heightmapPath);

// Create the effect and bind the input bitmaps
PixelShaderEffect<HeightmapShader> effect = new()
{
    Sources = { [0] = texture, [1] = heightmap }
};

Win32Application win32Application = new(CanvasDevice.GetSharedDevice());

win32Application.Draw += (_, e) =>
{
    // Update the shader constant buffer
    effect.ConstantBuffer = new HeightmapShader(
        time: (float)e.TotalTime.TotalSeconds,
        factors: new float3(0, 2, 4));

    // Draw frames here...
    e.DrawingSession.DrawImage(effect);
};

return Win32ApplicationRunner.Run(win32Application, "Win2D sample");
