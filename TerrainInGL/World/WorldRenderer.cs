using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Mathematics;
using OpenToolkit.Windowing.Common;
using OrgPer.Entities;
using OrgPer.Sprites;
using OrgPer.Utils;
using System;
using TerrainInGL.Shaders;

namespace TerrainInGL.World
{
    public class WorldRenderer : IDisposable
    {
        private Shader shader;
        private Sprite testSprite;

        public WorldRenderer()
        {
            //Might want to give the VAO's a pointer to a list of shader they can use instead of creating it here
            shader = new Shader("OrgPer.Shaders.static.vert", "OrgPer.Shaders.static.frag");
            
            //For testing only
            testSprite = new Sprite(ResourceManager.getTexture("test.png"));
        }

        public void OnRenderFrame(Camera camera, FrameEventArgs args)
        {
            shader.Use();

            //Matrix
            shader.SetMatrix4("view_matrix", camera.GetViewMatrix());
            shader.SetMatrix4("projection_matrix", camera.GetProjectionMatrix());
            shader.SetMatrix4("transformation_matrix", testSprite.GetTransformationMatrix());

            testSprite.Draw();
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
