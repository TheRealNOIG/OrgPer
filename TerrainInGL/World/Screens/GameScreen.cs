using System.Collections.Generic;
using OpenToolkit.Graphics.OpenGL;
using OpenToolkit.Windowing.Common;
using OrgPer.Entities;
using OrgPer.Sprites;
using TerrainInGL.Shaders;

namespace TerrainInGL.World {
    public class GameScreen : IScreen {
        private Shader shader;
        private Sprite testSprite;
        public List<Sprite> Sprites { get; set; }
        public WorldRenderer WorldRenderer { get; set; }
        public bool Active { get; set; }
        public void Load () {
            WorldRenderer = new WorldRenderer (shader, testSprite);
        }
        public void Update () {

        }
        public void Render (Camera camera, FrameEventArgs args) {
            WorldRenderer.OnRenderFrame (camera, args);
        }
        public void Dispose () {

        }
        public GameScreen () {
            //Might want to give the VAO's a pointer to a list of shader they can use instead of creating it here
            shader = new Shader ("OrgPer.Shaders.static.vert", "OrgPer.Shaders.static.frag");

            //For testing only
            testSprite = new Sprite ();
        }

    }
}