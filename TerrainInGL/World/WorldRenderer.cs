using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Windowing.Common;
using System;
using TerrainInGL.Shaders;
using TerrainInGL.Shaders.VAO;

namespace TerrainInGL.World
{
    public class WorldRenderer : IDisposable
    {
        private Shader shader;

        private SpriteVAO testSprite;

        public WorldRenderer()
        {
            shader = new Shader("OrgPer.Shaders.static.vert", "OrgPer.Shaders.static.frag");
            testSprite = new SpriteVAO();
        }

        public void OnRenderFrame(FrameEventArgs args)
        {
            shader.Use();
            testSprite.BindVAO();
            GL.DrawElements(PrimitiveType.Triangles, testSprite.indices.Length, DrawElementsType.UnsignedInt, 0);
            testSprite.UnbindVAO();
        }

        public void Dispose()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.BindVertexArray(0);

            testSprite.Dispose();
            GL.DeleteProgram(shader.Handle);
        }


    }
}
