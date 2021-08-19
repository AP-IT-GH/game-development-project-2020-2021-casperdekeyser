using MakingAPlatformer.Map.Blocks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MakingAPlatformer.Map
{
    public class BlockGenerator
    {

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
            Random rng = new Random();
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

            /*
             * Block factory with reflection
             * Manier nodig om nummers te vertalen naar klasses zonder if te gebruiken
             */

            //string blockName = "StoneBlock";
            //try
            //{
            //    Debug.WriteLine("--- TEST: " + typeof(GrassTrap));

            //    IMapObject block = (IMapObject)Activator.CreateInstance(Type.GetType($"MakingAPlatformer.Map.Blocks.{blockName}"), new object[] { new Vector2(y * blockSize, x * blockSize), randomNumber });

            //    return block;
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine("--- EXCEPTION: " + e.Message);
            //    return null;
            //}
        }
    }
}
