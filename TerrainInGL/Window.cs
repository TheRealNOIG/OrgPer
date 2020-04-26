using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Windowing.Common;
using OpenToolkit.Windowing.Desktop;
using OpenToolkit.Windowing.GraphicsLibraryFramework;
using OrgPer.Entities;
using System;
using System.ComponentModel;
using TerrainInGL.Utils;
using TerrainInGL.World;
using System.Collections.Generic;

namespace TerrainInGL
{
    class Window : GameWindow
    {
        private float clearColor = 106f / 255f;
        //private WorldRenderer worldRenderer;
        private Camera camera;
        private List<IScreen> worldStack;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            Run();
        }

        protected unsafe override void OnLoad()
        {
            GLFWCallbacks.KeyCallback KeyEventDelegate = OnKeyEvent;
            GLFW.SetKeyCallback(WindowPtr, KeyEventDelegate);

            camera = new Camera();

            //stackless standalone
            //worldRenderer = new WorldRenderer();

            //test stack. contains single screen rn. gamescreen.
            worldStack = new List<IScreen>();
            worldStack.Add(new GameScreen());
            worldStack.Add(new PauseMenuScreen());
            foreach (var screen in worldStack)
            {
                screen.Load();
            }
            //for testing need to set only first screen in list to active
            worldStack[0].Active = true;
            GL.ClearColor(clearColor, clearColor, clearColor, 1f);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //render standalone screen
            //worldRenderer.OnRenderFrame(camera, args);
            //render stack
            foreach (var screen in worldStack)
            {
                if (screen.Active)
                {
                    screen.Render(camera, args);
                }
            }
            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            camera.Update((float)args.Time);
            //TEST disabling a screen in the stack
            if(KeyboardManager.IsKeyPressed(Keys.Escape)){
                worldStack[0].Active = !worldStack[0].Active;
                worldStack[1].Active = !worldStack[1].Active;
            }
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
