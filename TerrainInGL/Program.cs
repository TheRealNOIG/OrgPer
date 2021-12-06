using OpenTK.Windowing.Desktop;

namespace TerrainInGL
{
    class Program
    {
        static void Main(string[] args)
        {
            var windowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(1024, 720),
                Title = "Hello World!",
                AutoLoadBindings = true

            };

            var gameWindowSettings = new GameWindowSettings()
            {
                UpdateFrequency = 144,
                RenderFrequency = 144
            };

            new Window(gameWindowSettings, windowSettings);
        }
    }
}
