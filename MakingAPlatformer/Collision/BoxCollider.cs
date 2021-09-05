using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer
{
    public class BoxCollider
    {
        public Rectangle Rectangle { get; set; }
        public Vector2 Position { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public BoxCollider(Vector2 position, string name, int width, int height)
        {
            Position = position;
            Name = name;
            Width = width;
            Height = height;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public BoxCollider(Vector2 position, string name, int width, int height, int Xoffset, int Yoffset)
        {
            Position = new Vector2(position.X + Xoffset, position.Y + Yoffset);
            Name = name;
            Width = width;
            Height = height;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Color color)
        {
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1, true, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            spriteBatch.Draw(pixel, Rectangle, color);
        }

        public void Update()
        {
            Position = new Vector2(Rectangle.X, Rectangle.Y);
        }
    }
}
