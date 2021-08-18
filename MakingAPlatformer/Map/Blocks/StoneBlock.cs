using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map
{
    public class StoneBlock : Block
    {
        public override int RowOnMasterTileset { get; set; } = 0;

        public StoneBlock(Vector2 position, int variation = 0) : base(position, variation) { }
    }
}
