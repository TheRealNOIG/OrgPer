using System;

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


    }
}