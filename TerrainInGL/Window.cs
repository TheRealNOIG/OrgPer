using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Windowing.Common;
using OpenToolkit.Windowing.Desktop;
using OpenToolkit.Windowing.GraphicsLibraryFramework;
using OrgPer.Entities;
using System;
using System.ComponentModel;
using TerrainInGL.Utils;
using TerrainInGL.World;

namespace TerrainInGL
{
    class Window : GameWindow
    {
        private float clearColor = 106f / 255f;
        private WorldRenderer worldRenderer;
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

            worldRenderer = new WorldRenderer();

            GL.ClearColor(clearColor, clearColor, clearColor, 1f);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            worldRenderer.OnRenderFrame(camera, args);
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

        private unsafe void OnKeyEvent(OpenToolkit.Windowing.GraphicsLibraryFramework.Window* windowID, Keys key, int scanCode, OpenToolkit.Windowing.GraphicsLibraryFramework.InputAction action, OpenToolkit.Windowing.GraphicsLibraryFramework.KeyModifiers mods)
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
