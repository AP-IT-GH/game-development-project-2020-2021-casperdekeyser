using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map
{
    public class DirtBlock : Block
    {
        public DirtBlock(Vector2 position) : base(position) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(0, 186, Size, Size), Color.White);
        }
    }
}
