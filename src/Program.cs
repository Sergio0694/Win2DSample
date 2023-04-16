using System.Runtime.CompilerServices;
using Win2DRenderer.Backend;
using Windows.UI;

[assembly: DisableRuntimeMarshalling]

Win32Application win32Application = new();

win32Application.Draw += static (_, e) =>
{
    // Draw frames here...
    e.DrawingSession.DrawEllipse(155, 115, 80, 30, Color.FromArgb(a: 255, r: 0, g: 148, b: 255), 3);
    e.DrawingSession.DrawText("Hello, world!", 100, 100, Color.FromArgb(a: 255, r: 255, g: 216, b: 0));
};

return Win32ApplicationRunner.Run(win32Application, "Win2D sample");
