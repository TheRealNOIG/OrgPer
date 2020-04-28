using OpenToolkit.Mathematics;
using OpenToolkit.Windowing.GraphicsLibraryFramework;
using OrgPer.Utils;
using System;
using TerrainInGL.Utils;

namespace OrgPer.Entities
{
    public class Camera
    {
        public Vector3 position = Vector3.Zero;
        public float pitch, yaw, roll, scale;
        readonly float speed = 0.05f;

        private Matrix4 projection;

        public Camera()
        {
            //TODO ask for starting position and width and height
            position = new Vector3(2, 2, -10);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), 1024 / (float)720, 0.1f, 100.0f);
            //projection = Matrix4.CreateOrthographic(1024, 720, 0.1f, 100f);
        }

        public void Update(float delta)
        {
            float deltaSpeed = speed;
            var dx = (float)(deltaSpeed * Math.Cos(Maths.toRadinas(yaw)));
            var dz = (float)(deltaSpeed * Math.Sin(Maths.toRadinas(yaw)));
            var rdx = (float)(deltaSpeed * Math.Cos(Maths.toRadinas(yaw + 90)));
            var rdz = (float)(deltaSpeed * Math.Sin(Maths.toRadinas(yaw + 90)));


            //FOR TESTING ONLY
            if (KeyboardManager.IsKeyDown(Keys.W))
            {
                IncreasePosition(rdx, rdz);
            }
            if (KeyboardManager.IsKeyDown(Keys.S))
                IncreasePosition(-rdx, -rdz); ;
            if (KeyboardManager.IsKeyDown(Keys.A))
                IncreasePosition(dx, dz);
            if (KeyboardManager.IsKeyDown(Keys.D))
                IncreasePosition(-dx, -dz); ;
            if (KeyboardManager.IsKeyDown(Keys.Space))
                position.Y -= deltaSpeed;
            if (KeyboardManager.IsKeyDown(Keys.LeftShift))
                position.Y += deltaSpeed;

            if (KeyboardManager.IsKeyDown(Keys.Q))
                yaw -= deltaSpeed * 5;
            if (KeyboardManager.IsKeyDown(Keys.E))
                yaw += deltaSpeed * 5;
        }

        public void IncreasePosition(float x, float z, float y)
        {
            this.position.X += x;
            this.position.Y += y;
            this.position.Z += z;
        }

        public void IncreasePosition(float x, float z)
        {
            this.position.X += x;
            this.position.Z += z;
        }

        public Matrix4 GetViewMatrix()
        {
            return Maths.CreateViewMatrix(this);
        }

        public Matrix4 GetProjectionMatrix()
        {
            return projection;
        }
    }
}
