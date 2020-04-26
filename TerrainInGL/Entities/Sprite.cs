﻿using OpenToolkit.Mathematics;
using OrgPer.Utils;
using System;
using TerrainInGL.Shaders.VAO;

namespace OrgPer.Sprites
{
    public class Sprite : IDisposable
    {
        public Vector3 Rotation;
        public Vector3 Location;
        public SpriteVAO Model;

        public Sprite()
        {
            Model = new SpriteVAO();
        }

        public Matrix4 GetTransformationMatrix()
        {
            return Maths.CreateTransformationMatrix(this);
        }

        public void Dispose()
        {
            Model.Dispose();
        }
    }
}