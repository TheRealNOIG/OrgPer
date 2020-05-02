using OpenToolkit.Graphics.OpenGL4;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using PixelFormat = OpenToolkit.Graphics.OpenGL4.PixelFormat;

namespace OrgPer.Utils
{
    public class Texture : IDisposable
    {
        public int Handle { get; private set; }

        public int Index = 0;
        public int NumberOfRows = 1;

        public Texture(string path)
        {
            SetupTexture(path);
        }
        public Texture(int handle)
        {
            Handle = handle;
        }

        public Texture(int index, int numberOfRows)
        {
            this.Index = index;
            this.NumberOfRows = numberOfRows;
        }

        public Texture(string path, int index, int numberOfRows)
        {
            Index = index;
            NumberOfRows = numberOfRows;
            SetupTexture(path);
        }
        public Texture(int handle, int index, int numberOfRows)
        {
            Index = index;
            NumberOfRows = numberOfRows;
            this.Handle = handle;
        }

        private void SetupTexture(string path)
        {
            //Creates the texture on the GPU
            Handle = GL.GenTexture();
            Use();

            //Load Embeded texture
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(path);
            Bitmap bmp = new Bitmap(myStream);

            //Create image data to pass to the GPU
            /*using MemoryStream ms = new MemoryStream();
            bmp.Save(ms, bmpt.RawFormat);
            var data = ms.ToArray();*/
            var data = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //Send texture data to the space allocated on the GPU
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            //Tell OpenGL how to render the texture
            //TODO allow this to be an input while creating the texture
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);

            //Generates mipmap for this texture
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public void Use(TextureUnit unit = TextureUnit.Texture0)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, Handle);
        }

        public float GetXOffset()
        {
            int col = Index % NumberOfRows;
            return (float)col / (float)NumberOfRows;
        }
        public float GetYOffset()
        {
            int row = Index / NumberOfRows;
            return (float)row / (float)NumberOfRows;
        }

        public float GetXOffset(int index)
        {
            int col = index % NumberOfRows;
            return (float)col / (float)NumberOfRows;
        }
        public float GetYOffset(int index)
        {
            int row = index / NumberOfRows;
            return (float)row / (float)NumberOfRows;
        }

        public void Dispose()
        {
            GL.DeleteTexture(Handle);
        }
    }
}
