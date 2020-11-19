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
        IGameObject hero;
        IMapObject block;
        GraphicsDevice graphicsDevice;

        Texture2D pixel;

        public CollisionManager(IGameObject hero, IMapObject block, GraphicsDevice graphicsDevice)
        {
            this.hero = hero;
            this.block = block;
            this.graphicsDevice = graphicsDevice;
            pixel = new Texture2D(graphicsDevice, 1, 1, true, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
        }

        public void Execute()
        {
            if (CheckCollision(hero.CollisionRectangle, block.CollisionRectangle))
                Debug.WriteLine("COLLISION at " + DateTime.Now);
            
        }

        private bool CheckCollision(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2))
                return true;
            return false;
        }

        public void DrawColliders(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pixel, new Rectangle(hero.CollisionRectangle.X, hero.CollisionRectangle.Y, 150, 5), Color.DarkGreen);
        }

        public static Rectangle GenerateCollider(Vector2 Position, int Height, int Width)
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public static Rectangle UpdateCollider(Vector2 Position, Rectangle CollisionRect)
        {
            CollisionRect.X = (int)Position.X;
            return CollisionRect;
        }
    }
}
