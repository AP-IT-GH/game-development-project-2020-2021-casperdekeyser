using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Map.Blocks;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.Map
{
    public class MapMaker : ILevelCreator
    {
        public List<IMapObject> Blocks { get; set; }

        private int _mapLength = 15;
        private int _mapHeight = 25;
        private int _blockSize = 62;

        private IBlockCreator _blockGenerator;
        private IMapObject[,] _blockArray;

        public MapMaker(IBlockCreator blockCreator)
        {
            Blocks = new List<IMapObject>();

            _blockGenerator = blockCreator;
            _blockArray = new Block[_mapLength, _mapHeight];
        }

        public void CreateLevel(int[,] tileArray)
        {
            for (int x = 0; x < _mapLength; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (tileArray[x, y] != 0)
                    {
                        _blockArray[x, y] = _blockGenerator.GenerateBlock(tileArray, x, y, _blockSize);
                        Blocks.Add(_blockArray[x, y]);
                    }
                }
            }
        }

        public void DrawLevel(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < _mapLength; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (_blockArray[x, y] != null) _blockArray[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}
