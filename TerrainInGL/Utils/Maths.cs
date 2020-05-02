using OpenToolkit.Mathematics;
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
            return CreateTransformationMatrix(sprite.Rotation, sprite.Location);
        }
        public static Matrix4 CreateTransformationMatrix(Vector3 rotation, Vector3 location)
        {
            Matrix4 x = Matrix4.CreateRotationX(toRadinas(rotation.X));
            Matrix4 y = Matrix4.CreateRotationY(toRadinas(rotation.Y));
            Matrix4 z = Matrix4.CreateRotationZ(toRadinas(rotation.Z));
            Matrix4 translation = Matrix4.CreateTranslation(location);
            return (x * y * z * translation);
        }

        //public static Matrix4 Transform(Vector3 position, float )
    }
}
