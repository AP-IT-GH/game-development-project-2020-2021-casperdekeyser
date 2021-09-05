using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer.Map.Blocks
{
    public class SandStairsBlock : Block
    {
        public SandStairsBlock(Vector2 position, int variation = 0) : base(position) { }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(62 * 9, 62 * 4, size, size), Color.White);
        }
    }
}
