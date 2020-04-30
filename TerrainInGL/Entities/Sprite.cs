using OpenToolkit.Mathematics;
using OrgPer.Utils;
using System;
using TerrainInGL.Shaders;
using TerrainInGL.Shaders.VAO;

namespace OrgPer.Sprites
{
    public class Sprite : IDisposable
    {
        public Vector3 Rotation;
        public Vector3 Location;
        public SpriteVAO Model;

        public Sprite(Texture texture)
        {
            Model = new SpriteVAO(texture);
        }

        public Matrix4 GetTransformationMatrix()
        {
            return Maths.CreateTransformationMatrix(this);
        }

        public void Draw(Shader shader)
        {
            shader.SetMatrix4("transformation_matrix", GetTransformationMatrix());
            Model.Draw(shader);
        }

        public void Dispose()
        {
            Model.Dispose();
        }
    }
}
