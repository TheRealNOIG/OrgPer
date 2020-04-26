using System;
using OpenToolkit.Windowing.Common;
using OrgPer.Entities;


namespace TerrainInGL.World
{
    interface IScreen : IDisposable
    {
       public bool Active {get;set;}
       public void Load();
       public void Update();
       public void Render(Camera camera, FrameEventArgs args);
    }
}