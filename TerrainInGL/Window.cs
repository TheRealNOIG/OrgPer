using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OrgPer.Entities;
using System.ComponentModel;
using OpenTK.Graphics.OpenGL;
using TerrainInGL.Utils;

namespace TerrainInGL
{
    class Window : GameWindow
    {
        private float clearColor = 106f / 255f;
        private Camera camera;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            Run();
        }

        protected unsafe override void OnLoad()
        {
            GLFWCallbacks.KeyCallback KeyEventDelegate = OnKeyEvent;
            GLFW.SetKeyCallback(WindowPtr, KeyEventDelegate);

            camera = new Camera();

            GL.ClearColor(clearColor, clearColor, clearColor, 1f);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            camera.Update((float)args.Time);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private unsafe void OnKeyEvent(OpenTK.Windowing.GraphicsLibraryFramework.Window* windowID, Keys key, int scanCode, OpenTK.Windowing.GraphicsLibraryFramework.InputAction action, OpenTK.Windowing.GraphicsLibraryFramework.KeyModifiers mods)
        {
            KeyboardManager.OnKeyEvent(key, action, mods);
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
        }
    }
}
