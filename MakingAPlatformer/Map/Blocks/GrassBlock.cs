﻿using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Map.Blocks
{
    public class GrassBlock : Block
    {
        public override int RowOnMasterTileset { get; set; } = 2;

        public GrassBlock(Vector2 position, int variation = 0) : base(position, variation) { }
    }
}
