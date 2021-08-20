using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer.UI
{
    public class Heart
    {
        public Vector2 Position { get; set; }
        public Texture2D Spritesheet { get; set; }
        public string SpritesheetPath { get; set; }

        private int _size = 32;


        public Heart(Vector2 position, int size = 48)
        {
            Position = position;
            _size = size;
            SpritesheetPath = $"UI/heart-pixel-art-{size}x{size}";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(0, 0, _size, _size), Color.White);
        }

    }
}
