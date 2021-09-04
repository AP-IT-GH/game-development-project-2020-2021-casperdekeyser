﻿using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Map.Blocks
{
    public class DirtBlock : Block
    {
        public override int RowOnMasterTileset { get; set; } = 3;

        public DirtBlock(Vector2 position, int variation = 0) : base(position, variation) { }
    }
}
