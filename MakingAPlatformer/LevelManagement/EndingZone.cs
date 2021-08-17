﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer.Management
{
    public class EndingZone
    {
        public Rectangle Rectangle;
        public Vector2 Position;
        public string Name;
        public int Width;
        public int Height;

        public EndingZone(Vector2 position, string name, int width, int height)
        {
            Position = position;
            Name = name;
            Width = width;
            Height = height;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public bool CheckEnding(IGameObject hero)
        {
            if (Rectangle.Intersects(hero.Collider.Rectangle)) return true;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1, true, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            spriteBatch.Draw(pixel, Rectangle, Color.Green);
        }
    }

}
