using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MakingAPlatformer
{
    public class CollisionManager
    {
        public List<BoxCollider> Colliders;
        
        private GraphicsDevice graphicsDevice;
        private int amountOfCollisions;

        public CollisionManager(List<BoxCollider> collliders, GraphicsDevice graphicsDevice)
        {
            Colliders = collliders;
            this.graphicsDevice = graphicsDevice;
        }

        public void Execute()
        {
            for (int i = 1; i < Colliders.Count; i++)
            {
                if (CheckCollision(Colliders[0].Rectangle, Colliders[i].Rectangle))
                {
                    amountOfCollisions++;
                    Debug.WriteLine($"COLLISION {amountOfCollisions} with {Colliders[i].Name} on {DateTime.Now}");

                }
            }
        }

        private bool CheckCollision(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2))
                return true;
            return false;
        }

        public void DrawColliders(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            foreach (var collider in Colliders)
            {
                collider.Draw(spriteBatch, graphicsDevice);
            }
        }


        public static BoxCollider UpdateCollider(Vector2 Position, BoxCollider Collider)
        {
            Collider.Rectangle.X = (int)Position.X;
            Collider.Rectangle.Y = (int)Position.Y;
            return Collider;
        }

        public static BoxCollider UpdateCollider(Vector2 Position, BoxCollider Collider, int Xoffset, int Yoffset)
        {
            Collider.Rectangle.X = (int)Position.X + Xoffset;
            Collider.Rectangle.Y = (int)Position.Y + Yoffset;
            return Collider;
        }

        public static Vector2 OffsetCollider(Vector2 currentPos, int horizontalOffset, int verticalOffset)
        {
            return new Vector2(currentPos.X+horizontalOffset, currentPos.Y+verticalOffset);
        }

    }
}
