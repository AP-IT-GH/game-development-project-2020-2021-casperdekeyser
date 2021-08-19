using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map.Blocks
{
    class DirtTrap : Trap
    {
        public override int RowOnMasterTileset { get; set; } = 3;

        public DirtTrap(Vector2 position) : base(position) { }

    }
}
