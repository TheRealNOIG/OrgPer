using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using OpenToolkit;
using OpenToolkit.Graphics.OpenGL;
using OpenToolkit.Input;
using OpenToolkit.Windowing.Common;
using OpenToolkit.Graphics.OpenGL4;
using OrgPer.Entities;


namespace TerrainInGL.World
{
    interface IScreen
    {
       public bool Active {get;set;}
       public WorldRenderer WorldRenderer {get; set;}

       public void Load();
       public void Update();
       public void Render(Camera camera, FrameEventArgs args);
    }
}