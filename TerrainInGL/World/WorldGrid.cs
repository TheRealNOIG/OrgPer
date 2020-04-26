using System;
using System.Collections.Generic;
using System.Text;

namespace TerrainInGL.World
{
    public class WorldGrid
    {
        private WorldCell[,] cells;
        private float cellSize;

        public WorldGrid(int width, int height, float cellSize)
        {
            cells = new WorldCell[width, height];
            this.cellSize = cellSize;
        }

    }

    public static class CellTextures
    {
        //List of textures cords in spritesheet

        
    }
}
