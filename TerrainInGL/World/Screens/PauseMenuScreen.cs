using OpenToolkit.Graphics.OpenGL;
using OpenToolkit.Windowing.Common;
using OrgPer.Entities;
using OrgPer.Sprites;
using TerrainInGL.Shaders;
using System.Collections.Generic;

namespace TerrainInGL.World {

    public class PauseMenuScreen : IScreen {
        public bool Active { get; set; }

        private Shader shader;
        private Sprite testSprite;
        public List<Sprite> Sprites { get; set; }
        public WorldRenderer WorldRenderer { get; set; }
        public void Load () {

        }
        public void Update () {

        }

        public PauseMenuScreen () {

        }
        public void Render (Camera camera, FrameEventArgs args) {

        }
        public void Dispose () {

        }

    }

}