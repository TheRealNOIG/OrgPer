using OpenToolkit.Graphics.OpenGL;
using OpenToolkit.Windowing.Common;
using OrgPer.Entities;
using TerrainInGL.Shaders;
using OrgPer.Sprites;

namespace TerrainInGL.World 
{
    public class GameScreen : IScreen
    {
        private Shader shader;
        private Sprite testSprite;
        public bool Active {get; set;}
        public void Load() {
        }
        public void Update() {
            
        }
        public void Render(Camera camera, FrameEventArgs args) {
            shader.Use();

            //Matrix
            shader.SetMatrix4("view_matrix", camera.GetViewMatrix());
            shader.SetMatrix4("projection_matrix", camera.GetProjectionMatrix());
            shader.SetMatrix4("transformation_matrix", testSprite.GetTransformationMatrix());

            //TODO move this all into the VAO class
            testSprite.Model.BindVAO();
            GL.DrawElements(PrimitiveType.Triangles, testSprite.Model.indices.Length, DrawElementsType.UnsignedInt, 0);
            testSprite.Model.UnbindVAO();
        }
        public void Dispose() {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.BindVertexArray(0);

            testSprite.Dispose();
            GL.DeleteProgram(shader.Handle);
        }
        public GameScreen()
        {
            //Might want to give the VAO's a pointer to a list of shader they can use instead of creating it here
            shader = new Shader("OrgPer.Shaders.static.vert", "OrgPer.Shaders.static.frag");

            //For testing only
            testSprite = new Sprite();
        }


    }
}