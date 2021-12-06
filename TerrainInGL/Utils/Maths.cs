using OpenTK.Mathematics;
using OrgPer.Entities;
using OrgPer.Sprites;
using System;

namespace OrgPer.Utils
{
    public static class Maths
    {

        public static float toRadinas(float angle)
        {
            return ((float)Math.PI / 180) * angle;
        }

        public static Matrix4 CreateViewMatrix(Camera camera)
        {
            var rotationX = Matrix4.CreateRotationX(toRadinas(camera.pitch));
            var rotationY = Matrix4.CreateRotationY(toRadinas(camera.yaw));
            var rotationZ = Matrix4.CreateRotationZ(toRadinas(camera.roll));
            Matrix4 translation = Matrix4.CreateTranslation(camera.position);
            return (translation * rotationX * rotationY * rotationZ);
        }

        public static Matrix4 CreateTransformationMatrix(Sprite sprite)
        {
            Matrix4 x = Matrix4.CreateRotationX(sprite.Rotation.X);
            Matrix4 y = Matrix4.CreateRotationY(sprite.Rotation.Y);
            Matrix4 z = Matrix4.CreateRotationZ(sprite.Rotation.Z);
            Matrix4 translation = Matrix4.CreateTranslation(sprite.Location);
            return (x * y * z * translation);
        }

        //public static Matrix4 Transform(Vector3 position, float )
    }
}
