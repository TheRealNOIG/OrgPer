using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Mathematics;
using OpenToolkit.Windowing.Common;
using OrgPer.Entities;
using OrgPer.Sprites;
using OrgPer.Utils;
using System;
using System.Collections.Generic;
using TerrainInGL.Shaders;
using TerrainInGL.Shaders.VAO;

namespace TerrainInGL.World
{
    public class WorldRenderer : IDisposable
    {
        private Shader shader;
        private Sprite testSprite , testSprite2, testSprite3;
        private Dictionary<SpriteVAO, List<Sprite>> spriteDictionary = new Dictionary<SpriteVAO, List<Sprite>>();

        public WorldRenderer()
        {
            //Might want to give the VAO's a pointer to a list of shader they can use instead of creating it here
            shader = new Shader("OrgPer.Shaders.static.vert", "OrgPer.Shaders.static.frag");

            //For testing only
            testSprite = new Sprite(ResourceManager.getTexture("testAtlis.png", 4, 4));
            testSprite2 = new Sprite(ResourceManager.getTexture("testAtlis.png", 6, 4));
            testSprite3 = new Sprite(ResourceManager.getTexture("test.png"));
            testSprite.Location = new Vector3(-1f, 0, 0);
            testSprite3.Location = new Vector3(-2f, 0, 0);
            AddSprite(testSprite);
            AddSprite(testSprite2);
            AddSprite(testSprite3);
        }

        public void OnRenderFrame(Camera camera, FrameEventArgs args)
        {
            shader.Use();

            //Matrix
            shader.SetMatrix4("view_matrix", camera.GetViewMatrix());
            shader.SetMatrix4("projection_matrix", camera.GetProjectionMatrix());

            foreach (KeyValuePair<SpriteVAO, List<Sprite>> item in spriteDictionary)
            {
                SpriteVAO model = item.Key;
                model.BindVAO();
                foreach (Sprite sprite in item.Value)
                {
                    sprite.Draw(shader);
                }
                model.UnbindVAO();
            }
        }

        public void Dispose()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.BindVertexArray(0);

            testSprite.Dispose();
            testSprite2.Dispose();
            testSprite3.Dispose();
            GL.DeleteProgram(shader.Handle);
        }

        public void AddSprite(Sprite sprite)
        {
            SpriteVAO model = sprite.Model;

            if (spriteDictionary.ContainsKey(model))
            {
                List<Sprite> result;
                if (spriteDictionary.TryGetValue(model, out result))
                {
                    if (!result.Contains(sprite))
                    {
                        result.Add(sprite);
                    }
                }
            }
            else
            {
                List<Sprite> newList = new List<Sprite>();
                newList.Add(sprite);
                spriteDictionary.Add(model, newList);
            }
        }

        public void RemoveSprite(Sprite sprite)
        {
            if (spriteDictionary.ContainsKey(sprite.Model)) spriteDictionary[sprite.Model].RemoveAll(x => x == sprite);
        }
    }
}
