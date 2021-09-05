
namespace MakingAPlatformer.Interfaces
{
    public interface IBlockCreator
    {
        IMapObject GenerateBlock(int[,] tileArray, int x, int y, int blockSize);
    }
}
