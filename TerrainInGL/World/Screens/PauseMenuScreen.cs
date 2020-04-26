using OpenToolkit.Windowing.Common;
using OrgPer.Entities;

namespace TerrainInGL.World
{
   
    public class PauseMenuScreen : IScreen
    {
        public bool Active { get; set; }
        public WorldRenderer WorldRenderer { get; set; }
        public void Load()
        {
            WorldRenderer = new WorldRenderer();
           
        }
        public void Update()
        {

        }
        public void Render(Camera camera, FrameEventArgs args)
        {
            
        }
      
    }
    
}