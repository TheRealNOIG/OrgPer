using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using OpenToolkit;
using OpenToolkit.Graphics.OpenGL;
using OpenToolkit.Input;
using OpenToolkit.Windowing.Common;
using TerrainInGL;
using OrgPer.Entities;

namespace TerrainInGL.World
{
    public static class Settings
    {
        public static string FontBitmapFilename = "test.png";
        public static int GlyphsPerLine = 16;
        public static int GlyphLineCount = 16;
        public static int GlyphWidth = 11;
        public static int GlyphHeight = 22;

        public static int CharXSpacing = 11;

        public static string Text = "Mufukn MENU!!!!";

        // Used to offset rendering glyphs to bitmap
        public static int AtlasOffsetX = -3, AtlassOffsetY = -1;
        public static int FontSize = 14;
        public static bool BitmapFont = false;
        
        public static string FromFile = "joystix monospace.ttf";
        public static string FontName = "Consolas";

    }
    public class PauseMenuScreen : IScreen
    {
        public bool Active { get; set; }
        public WorldRenderer WorldRenderer { get; set; }
        public int FontTextureID;
        public int TextureWidth;
        public int TextureHeight;
        public void Load()
        {
            WorldRenderer = new WorldRenderer();
            //GenerateFontImage();
            FontTextureID = LoadTexture(Settings.FontBitmapFilename);
            GL.Enable(EnableCap.Texture2D);
            GL.ClearColor(Color.ForestGreen);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, 500, 50, 0, 0, 1);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }
        public void Update()
        {

        }
        public void Render(Camera camera, FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Disable(EnableCap.Blend);
            Blt(10, 40, TextureWidth, TextureHeight);
            GL.Enable(EnableCap.Blend);
            DrawText(10, 10, Settings.Text); 
        }
        int LoadTexture(string filename)
        {
            using (var bitmap = new Bitmap(filename))
            {
                var texId = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, FontTextureID);
                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenToolkit.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                bitmap.UnlockBits(data);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
                TextureWidth = bitmap.Width; TextureHeight = bitmap.Height;
                return texId;
            }
        }
        public void DrawText(int x, int y, string text)
        {
            GL.Begin(BeginMode.Quads);

            float u_step = (float)Settings.GlyphWidth / (float)TextureWidth;
            float v_step = (float)Settings.GlyphHeight / (float)TextureHeight;

            for (int n = 0; n < text.Length; n++)
            {
                char idx = text[n];
                float u = (float)(idx % Settings.GlyphsPerLine) * u_step;
                float v = (float)(idx / Settings.GlyphsPerLine) * v_step;

                GL.TexCoord2(u, v);
                GL.Vertex2(x, y);
                GL.TexCoord2(u + u_step, v);
                GL.Vertex2(x + Settings.GlyphWidth, y);
                GL.TexCoord2(u + u_step, v + v_step);
                GL.Vertex2(x + Settings.GlyphWidth, y + Settings.GlyphHeight);
                GL.TexCoord2(u, v + v_step);
                GL.Vertex2(x, y + Settings.GlyphHeight);

                x += Settings.CharXSpacing;
            }

            GL.End();
        }
        public void Blt(double x, double y, double width, double height)
        {
            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex2(x, y);
            GL.TexCoord2(1, 0);
            GL.Vertex2(x + width, y);
            GL.TexCoord2(1, 1);
            GL.Vertex2(x + width, y + height);
            GL.TexCoord2(0, 1);
            GL.Vertex2(x, y + height);
            GL.End();
        }
        /* static void GenerateFontImage()
        {
            int bitmapWidth = Settings.GlyphsPerLine * Settings.GlyphWidth;
            int bitmapHeight = Settings.GlyphLineCount * Settings.GlyphHeight;

            using (Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                Font font;
                if (!String.IsNullOrWhiteSpace(Settings.FromFile))
                {
                    var collection = new PrivateFontCollection();
                    Console.WriteLine("FontFile: " + Path.GetFileNameWithoutExtension(Settings.FromFile));
                    collection.AddFontFile(Settings.FromFile);
                    Console.WriteLine(collection);
                    var fontFamily = new FontFamily(Path.GetFileNameWithoutExtension(Settings.FromFile), collection);
                    font = new Font(fontFamily, Settings.FontSize);
                }
                else
                {
                    font = new Font(new FontFamily(Settings.FontName), Settings.FontSize);
                }

                using (var g = Graphics.FromImage(bitmap))
                {
                    if (Settings.BitmapFont)
                    {
                        g.SmoothingMode = SmoothingMode.None;
                        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                    }
                    else
                    {
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                        //g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    }

                    for (int p = 0; p < Settings.GlyphLineCount; p++)
                    {
                        for (int n = 0; n < Settings.GlyphsPerLine; n++)
                        {
                            char c = (char)(n + p * Settings.GlyphsPerLine);
                            g.DrawString(c.ToString(), font, Brushes.White,
                                n * Settings.GlyphWidth + Settings.AtlasOffsetX, p * Settings.GlyphHeight + Settings.AtlassOffsetY);
                        }
                    }
                }
                bitmap.Save(Settings.FontBitmapFilename);
            }
            Process.Start(Settings.FontBitmapFilename);
        } */
    }
    
}