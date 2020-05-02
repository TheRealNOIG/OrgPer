using OpenToolkit.Graphics.ES11;
using OpenToolkit.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using TerrainInGL.Shaders;
using TerrainInGL.Shaders.VAO;
using TerrainInGL.World;

namespace OrgPer.Utils
{
    class WorldFace
    {
        public CellTexturesIndex index;
        private Vector3 location;
        private Vector3 rotation;
        private Vector3 scale = Vector3.One;

        public WorldFace(Vector3 location, Vector3 rotation)
        {
            this.location = location;
            this.rotation = rotation;
        }
        public WorldFace(Vector3 location, Vector3 rotation, Vector3 scale)
        {
            this.location = location;
            this.rotation = rotation;
            this.scale = scale;
        }

        public void Draw(Shader shader, Texture texture, SpriteVAO vao)
        {
            if (index == CellTexturesIndex.NONE) return;

            shader.SetMatrix4("transformation_matrix", Maths.CreateTransformationMatrix(rotation, location));
            shader.SetVector3("scale", scale);
            shader.SetVector2("offset", new Vector2(texture.GetXOffset((int)index), texture.GetYOffset((int)index)));
            vao.DrawWithoutTexture();
        }
    }
}
