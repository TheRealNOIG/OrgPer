using System;


namespace TerrainInGL.World
{
    interface IScreen
    {
       public bool Active {get;set;}
       public WorldRenderer WorldRenderer {get; set;}

       public void Load();
       public void Update();
    }
}