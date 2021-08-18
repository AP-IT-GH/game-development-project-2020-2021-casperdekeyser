using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map.Blocks
{
    public class GrassBlock2 : Block
    {
        public GrassBlock2(Vector2 position) : base(position) { }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(62 * 2, 62 * 2, Size, Size), Color.White);
        }
    }
}
