using MakingAPlatformer.Management;

namespace MakingAPlatformer.Levels
{
    public class DeathZone : Transition
    {
        public DeathZone(int blocksFromRight, int blocksFromBottom, int widthBlocks, int heightBlocks, string name) : base(blocksFromRight, blocksFromBottom, widthBlocks, heightBlocks, name) { }
    }
}
