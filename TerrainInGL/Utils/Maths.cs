using OpenTK.Mathematics;
using OrgPer.Entities;
using System;

namespace OrgPer.Utils
{
    public static class Maths
    {

        public static float ToRadians(float angle)
        {
            return ((float)Math.PI / 180) * angle;
        }

        public static Matrix4 CreateViewMatrix(Camera camera)
        {
            var rotationX = Matrix4.CreateRotationX(ToRadians(camera.pitch));
            var rotationY = Matrix4.CreateRotationY(ToRadians(camera.yaw));
            var rotationZ = Matrix4.CreateRotationZ(ToRadians(camera.roll));
            var translation = Matrix4.CreateTranslation(camera.position);
            return (translation * rotationX * rotationY * rotationZ);
        }

        public static Matrix4 CreateTransformationMatrix(Vector3 position)
        {
            var x = Matrix4.CreateRotationX(position.X);
            var y = Matrix4.CreateRotationY(position.Y);
            var z = Matrix4.CreateRotationZ(position.Z);
            var translation = Matrix4.CreateTranslation(position);
            return (x * y * z * translation);
        }

        //public static Matrix4 Transform(Vector3 position, float )
    }
}
