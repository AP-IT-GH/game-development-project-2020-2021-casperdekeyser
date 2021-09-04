using MakingAPlatformer.Management;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Levels
{
    public class DeathZone : Transition
    {
        public DeathZone(int blocksFromRight, int blocksFromBottom, int widthBlocks, int heightBlocks, string name) : base(blocksFromRight, blocksFromBottom, widthBlocks, heightBlocks, name)
        {
            Position.X = 100;
        }
    }
}
