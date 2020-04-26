using System;
using System.Collections.Generic;
using System.Text;

namespace TerrainInGL.Shaders.VAO
{
    class SpriteVAO : VAO
    {

        private readonly float[] testVertex =
        {
            0.5f, 0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            -0.5f, -0.5f, 0.0f,
            -0.5f, 0.5f, 0.0f
        };

        public readonly uint[] indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        public SpriteVAO()
        {
            CreateVAO();
            StoreElement(indices);
            StoreArrayInAttributeList(0, 3, testVertex);
            UnbindVAO();
        }
    }
}
