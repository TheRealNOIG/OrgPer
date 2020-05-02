using OpenToolkit.Graphics.ES11;
using OrgPer.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TerrainInGL.Shaders;
using TerrainInGL.Shaders.VAO;

namespace TerrainInGL.World
{
    public class WorldGrid
    {
        private float cellSize;
        private WorldCell[,] cells;
        private Texture textureAtlis;
        private SpriteVAO vao;

        public WorldGrid(int width, int height, float cellSize, Texture textureAtlis)
        {
            cells = new WorldCell[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new WorldCell(x, y, cellSize);
                }
            this.cellSize = cellSize;
            this.textureAtlis = textureAtlis;
            vao = new SpriteVAO();
        }

        public void Draw(Shader shader)
        {
            vao.BindVAO();
            textureAtlis.Use();
            shader.SetFloat("number_of_rows", textureAtlis.NumberOfRows);
            foreach (WorldCell cell in cells)
            {
                cell.Draw(shader, textureAtlis, vao);
            }
        }

    }

    public enum CellTexturesIndex : int
    {
        NONE = 999,
        one = 0,
        two = 1,
        three = 2,
        four = 4
    }
}
