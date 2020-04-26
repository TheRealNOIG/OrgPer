using OpenToolkit.Graphics.OpenGL4;

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
            0, 0,
            0, 1,
            1, 1,
            1, 0
        };

        public readonly uint[] indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        //TODO create texture class and load in from png
        private  byte[] texture = new byte[64 * 32 * 4];
        private int textureHandle;

        public SpriteVAO()
        {
            CreateVAO();
            StoreElement(indices);
            StoreArrayInAttributeList(0, 3, vertices);
            StoreArrayInAttributeList(1, 2, textureCoords);
            UnbindVAO();



            //Create test texture

            textureHandle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureHandle);

            for (int i = 0; i < 64 * 32; i++)
            {
                int _i = i * 4;

                texture[_i + 0] = 255; // R
                texture[_i + 1] = 255; // G
                texture[_i + 2] = 255; // B
                texture[_i + 3] = 255; // A
            }
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 64, 32, 0, PixelFormat.Rgba, PixelType.UnsignedByte, texture);

        }
    }
}
