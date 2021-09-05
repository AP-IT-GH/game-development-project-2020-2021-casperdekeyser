using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Map.Blocks
{
    class DirtTrap : Trap
    {
        public override int RowOnMasterTileset { get; set; } = 3;

        public DirtTrap(Vector2 position, int variation = 0) : base(position) { }

    }
}
