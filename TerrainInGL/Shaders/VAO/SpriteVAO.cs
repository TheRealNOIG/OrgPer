using OpenToolkit.Graphics.OpenGL4;
using OrgPer.Utils;
using System;

namespace TerrainInGL.Shaders.VAO
{
    public class SpriteVAO : VAO
    {
        private readonly float[] vertices =
        {
            0.5f, 0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            -0.5f, -0.5f, 0.0f,
            -0.5f, 0.5f, 0.0f
        };

        private readonly float[] textureCoords =
        {
            1, 1,
            1, 0,
            0, 0,
            0, 1
        };

        private readonly uint[] indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        public Texture? texture;

        public SpriteVAO(Texture texture)
        {
            CreateVAO();
            StoreElement(indices);
            StoreArrayInAttributeList(0, 3, vertices);
            StoreArrayInAttributeList(1, 2, textureCoords);
            UnbindVAO();
            this.texture = texture;
        }

        public SpriteVAO()
        {
            CreateVAO();
            StoreElement(indices);
            StoreArrayInAttributeList(0, 3, vertices);
            StoreArrayInAttributeList(1, 2, textureCoords);
            UnbindVAO();
        }

        public void Draw(Shader shader)
        {
            shader.SetFloat("number_of_rows", texture.NumberOfRows);
            shader.SetVector2("offset", new OpenToolkit.Mathematics.Vector2(texture.GetXOffset(), texture.GetYOffset()));

            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void DrawWithoutTexture()
        {
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public override void BindVAO()
        {
            base.BindVAO();
            GL.ActiveTexture(TextureUnit.Texture0);
        }

        public override void UnbindVAO()
        {
            base.UnbindVAO();
        }

        public override void Dispose()
        {
            base.Dispose();
            texture?.Dispose();
        }
    }
}
