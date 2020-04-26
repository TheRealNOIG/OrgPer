using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using OpenToolkit;
using OpenToolkit.Graphics.OpenGL;
using OpenToolkit.Windowing.Common;
using OpenToolkit.Input;
using OrgPer.Entities;

namespace TerrainInGL.World 
{
    public class GameScreen : IScreen
    {
        public bool Active {get; set;}
        public WorldRenderer WorldRenderer {get; set;}
        public void Load() {
           WorldRenderer = new WorldRenderer(); 
        }
        public void Update() {
            
        }
        public void Render(Camera camera, FrameEventArgs args) {
            WorldRenderer.OnRenderFrame(camera,args);
        }


    }
}