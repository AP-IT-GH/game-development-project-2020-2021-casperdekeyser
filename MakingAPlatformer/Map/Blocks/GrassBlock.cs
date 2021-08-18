using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map
{
    public class GrassBlock : Block
    {
        public override int RowOnMasterTileset { get; set; } = 2;

        public GrassBlock(Vector2 position, int variation = 0) : base(position, variation) { }
    }
}
