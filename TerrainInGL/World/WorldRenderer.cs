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
        private Sprite testSprite , testSprite2;

        public WorldRenderer()
        {
            //Might want to give the VAO's a pointer to a list of shader they can use instead of creating it here
            shader = new Shader("OrgPer.Shaders.static.vert", "OrgPer.Shaders.static.frag");

            //For testing only
            testSprite = new Sprite(ResourceManager.getTexture("testAtlis.png", 4, 4));
            testSprite2 = new Sprite(ResourceManager.getTexture("testAtlis.png", 6, 4));
            testSprite.Location = new Vector3(-1f, 0, 0);
        }

        public void OnRenderFrame(Camera camera, FrameEventArgs args)
        {
            shader.Use();

            //Matrix
            shader.SetMatrix4("view_matrix", camera.GetViewMatrix());
            shader.SetMatrix4("projection_matrix", camera.GetProjectionMatrix());

            testSprite.Draw(shader);
            testSprite2.Draw(shader);
        }

        public void Dispose()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.BindVertexArray(0);

            testSprite.Dispose();
            testSprite.Dispose();
            GL.DeleteProgram(shader.Handle);
        }
    }
}
