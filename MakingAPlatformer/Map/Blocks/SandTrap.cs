using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map.Blocks
{
    class SandTrap : Trap
    {
        public override int RowOnMasterTileset { get; set; } = 4;

        public SandTrap(Vector2 position, int variation = 0) : base(position) { }
    }
}
