using OpenToolkit.Mathematics;
using OrgPer.Sprites;
using OrgPer.Utils;
using System.Globalization;
using TerrainInGL.Shaders;
using TerrainInGL.Shaders.VAO;

namespace TerrainInGL.World
{
    class WorldCell
    {
        public WorldFace NorthFace;
        public WorldFace SouthFace;
        public WorldFace EastFace;
        public WorldFace WestFace;
        public WorldFace TopFace;
        public WorldFace BottomFace;

        public WorldCell(int x, int y, float cellSize)
        {
            float scale = 1.3f;
            float hs = cellSize / 2;
            BottomFace = new WorldFace(new Vector3(x * cellSize, y * cellSize, -1), new Vector3(0, 0, 0), new Vector3(cellSize, cellSize, 1));
            NorthFace = new WorldFace(new Vector3(x * cellSize, (y * cellSize) + hs, cellSize), new Vector3(90, 0, 0), new Vector3(cellSize, cellSize + scale, 1)); ;

            //TEST
            BottomFace.index = CellTexturesIndex.four;
            NorthFace.index = (CellTexturesIndex)14;
        }

        public void Draw(Shader shader, Texture texture, SpriteVAO vao)
        {
            NorthFace.Draw(shader, texture, vao);
            //SouthFace.Draw(shader, texture, vao);
            //EastFace.Draw(shader, texture, vao);
            //WestFace.Draw(shader, texture, vao);
            //TopFace.Draw(shader, texture, vao);
            BottomFace.Draw(shader, texture, vao);
        }
    }
}
