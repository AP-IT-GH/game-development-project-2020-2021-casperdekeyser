using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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

        public void CheckEnding(IGameObject hero)
        {
            if (Rectangle.Intersects(hero.Collider.Rectangle))
            {
                Debug.WriteLine($"COLLISION with {this.Name} on {DateTime.Now}");
            }
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1, true, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            spriteBatch.Draw(pixel, Rectangle, Color.Green);
        }
    }

}
