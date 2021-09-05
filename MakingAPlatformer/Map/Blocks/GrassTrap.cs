using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Map.Blocks
{
    public class GrassTrap : Trap
    {
        public override int RowOnMasterTileset { get; set; } = 2;

        public GrassTrap(Vector2 position, int variation = 0) : base(position) { }

    }
}
