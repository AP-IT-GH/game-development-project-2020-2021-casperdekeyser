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

        public CollisionManager(List<BoxCollider> collliders, GraphicsDevice graphicsDevice)
        {
            Colliders = collliders;
            this.graphicsDevice = graphicsDevice;
        }

        public void Execute(BoxCollider coll1, BoxCollider coll2)
        {
            if (CheckCollision(coll1.Rectangle, coll2.Rectangle))
                Debug.WriteLine("COLLISION at " + DateTime.Now);
        }

        private bool CheckCollision(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2))
                return true;
            return false;
        }


        public static Rectangle GenerateCollider(Vector2 Position, int Height, int Width)
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public static BoxCollider UpdateCollider(Vector2 Position, BoxCollider Collider)
        {
            Collider.Rectangle.X = (int)Position.X;
            return Collider;
        }

        public static Vector2 OffsetCollider(Vector2 currentPos, int horizontalOffset, int verticalOffset)
        {
            return new Vector2(currentPos.X+horizontalOffset, currentPos.Y+verticalOffset);
        }

        public void DrawColliders(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            foreach (var collider in Colliders)
            {
                collider.Draw(spriteBatch, graphicsDevice);
            }
        }
    }
}
