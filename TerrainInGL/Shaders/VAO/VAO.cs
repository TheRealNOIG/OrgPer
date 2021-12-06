using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerrainInGL.Shaders.VAO
{
    public class VAO : IDisposable
    {
        public int ID { get; private set; }
        private List<int> vbos = new List<int>();
        private int element;

        public void CreateVAO()
        {
            ID = GL.GenVertexArray();
            GL.BindVertexArray(ID);
        }

        public virtual void BindVAO()
        {
            GL.BindVertexArray(ID);
        }

        public virtual void UnbindVAO()
        {
            GL.BindVertexArray(0);
        }

        public void StoreArrayInAttributeList(int attributeNumber, int attributeSize, float[] buffer)
        {
            int vboID = GL.GenBuffer();
            vbos.Add(vboID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, buffer.Length * sizeof(float), buffer, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(attributeNumber, attributeSize, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(attributeNumber);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void StoreElement(uint[] buffer)
        {
            element = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, element);
            GL.BufferData(BufferTarget.ElementArrayBuffer, buffer.Length * sizeof(uint), buffer, BufferUsageHint.StaticDraw);
        }

        public virtual void Dispose()
        {
            vbos.ForEach(vbo => GL.DeleteBuffer(vbo));
            vbos.Clear();
            GL.DeleteBuffer(element);
            GL.DeleteVertexArray(ID);
        }
    }
}
