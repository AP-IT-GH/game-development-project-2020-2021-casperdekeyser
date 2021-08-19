using MakingAPlatformer.Map.Blocks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map
{
    public class BlockGenerator
    {
        private Random rng = new Random();

        public IMapObject GenerateBlock(List<int[,]> tileArrayList, int level, int x, int y, int blockSize)
        {
            if (tileArrayList[level][x, y] == 1) return new StoneBlock(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 2) return new GrassBlock(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 3) return new SandBlock(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 4) return new DirtBlock(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 5) return new StoneStairsBlock(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 6) return new SandStairsBlock(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 7) return new GrassBlock(new Vector2(y * blockSize, x * blockSize), 1);
            if (tileArrayList[level][x, y] == 8) return new GrassBlock(new Vector2(y * blockSize, x * blockSize), 2);
            if (tileArrayList[level][x, y] == 9) return new GrassBlock(new Vector2(y * blockSize, x * blockSize), 3);
            if (tileArrayList[level][x, y] == 10) return new DirtBlock(new Vector2(y * blockSize, x * blockSize), 1);
            if (tileArrayList[level][x, y] == 11) return new DirtBlock(new Vector2(y * blockSize, x * blockSize), 2);
            if (tileArrayList[level][x, y] == 12) return new DirtBlock(new Vector2(y * blockSize, x * blockSize), 3);
            return null;
        }

        public IMapObject GenerateBlockVariation(List<int[,]> tileArrayList, int level, int x, int y, int blockSize)
        {
            int randomNumber = rng.Next(4);
            if (tileArrayList[level][x, y] == 1) return new StoneBlock(new Vector2(y * blockSize, x * blockSize), randomNumber);
            if (tileArrayList[level][x, y] == 2) return new GrassBlock(new Vector2(y * blockSize, x * blockSize), randomNumber);
            if (tileArrayList[level][x, y] == 3) return new SandBlock(new Vector2(y * blockSize, x * blockSize), randomNumber);
            if (tileArrayList[level][x, y] == 4) return new DirtBlock(new Vector2(y * blockSize, x * blockSize), randomNumber);
            if (tileArrayList[level][x, y] == 5) return new StoneStairsBlock(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 6) return new SandStairsBlock(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 7) return new GrassTrap(new Vector2(y * blockSize, x * blockSize));
            if (tileArrayList[level][x, y] == 8) return new DirtTrap(new Vector2(y * blockSize, x * blockSize));
            return null;
        }
    }
}
