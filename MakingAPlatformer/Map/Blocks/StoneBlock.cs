using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Map.Blocks
{
    public class StoneBlock : Block
    {
        public override int RowOnMasterTileset { get; set; } = 0;

        public StoneBlock(Vector2 position, int variation = 0) : base(position, variation) { }
    }
}
