using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Map.Blocks
{
    public class SandBlock : Block
    {
        public override int RowOnMasterTileset { get; set; } = 4;

        public SandBlock(Vector2 position, int variation = 0) : base(position, variation) { }
    }
}
