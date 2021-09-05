using System.Collections.Generic;

namespace MakingAPlatformer.Interfaces
{
    public interface IBlockCreator
    {
        IMapObject GenerateBlock(List<int[,]> tileArrayList, int level, int x, int y, int blockSize);
    }
}
