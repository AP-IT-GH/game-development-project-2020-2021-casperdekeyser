using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer.Management
{
    public class Transition
    {
        public Rectangle Rectangle;
        public Vector2 Position;
        public string Name;
        public int Width;
        public int Height;

        public Transition(int blocksFromRight, int blocksFromBottom, int widthBlocks, int heightBlocks, string name)
        {
            Position = new Vector2(1550 - (62 * blocksFromRight), 930 - (62 * blocksFromBottom) - 10);
            Width = widthBlocks * 62;
            Height = (heightBlocks * 62) + 10;

            Name = name;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        }

        public bool CheckCollision(IGameObject hero)
        {
            if (Rectangle.Intersects(hero.Collider.Rectangle)) 
                return true;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Color color)
        {
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1, true, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            spriteBatch.Draw(pixel, Rectangle, color);
        }
    }

}
