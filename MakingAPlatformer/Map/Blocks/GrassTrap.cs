using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map.Blocks
{
    public class GrassTrap : Trap
    {
        public override int RowOnMasterTileset { get; set; } = 2;

        public GrassTrap(Vector2 position) : base(position) { }

    }
}
