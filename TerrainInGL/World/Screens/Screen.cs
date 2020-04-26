using System;
using System.Collections.Generic;
using OpenToolkit.Windowing.Common;
using OrgPer.Entities;
using OrgPer.Sprites;

namespace TerrainInGL.World {
    interface IScreen : IDisposable {
        public List<Sprite> Sprites { get; set; }
        public bool Active { get; set; }
        public WorldRenderer WorldRenderer {get; set;}
        public void Load ();
        public void Update ();
        public void Render (Camera camera, FrameEventArgs args);
    }
}