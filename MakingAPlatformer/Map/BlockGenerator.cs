using MakingAPlatformer.Map.Blocks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;


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

            // ATTEMPT 1: using if's
            //if (tileArrayList[level][x, y] == 1) return new StoneBlock(new Vector2(y * blockSize, x * blockSize), randomNumber);
            //if (tileArrayList[level][x, y] == 2) return new GrassBlock(new Vector2(y * blockSize, x * blockSize), randomNumber);
            //if (tileArrayList[level][x, y] == 3) return new SandBlock(new Vector2(y * blockSize, x * blockSize), randomNumber);
            //if (tileArrayList[level][x, y] == 4) return new DirtBlock(new Vector2(y * blockSize, x * blockSize), randomNumber);
            //if (tileArrayList[level][x, y] == 5) return new StoneStairsBlock(new Vector2(y * blockSize, x * blockSize));
            //if (tileArrayList[level][x, y] == 6) return new SandStairsBlock(new Vector2(y * blockSize, x * blockSize));
            //if (tileArrayList[level][x, y] == 7) return new GrassTrap(new Vector2(y * blockSize, x * blockSize));
            //if (tileArrayList[level][x, y] == 8) return new DirtTrap(new Vector2(y * blockSize, x * blockSize));
            //return null;


            // ATTEMPT 2: using translation between int and string, still manual adding
            string blockName = "";
            if (tileArrayList[level][x, y] == 1) blockName = "DirtBlock";
            if (tileArrayList[level][x, y] == 2) blockName = "DirtTrap";
            if (tileArrayList[level][x, y] == 3) blockName = "GrassBlock";
            if (tileArrayList[level][x, y] == 4) blockName = "GrassTrap";
            if (tileArrayList[level][x, y] == 5) blockName = "SandBlock";
            if (tileArrayList[level][x, y] == 6) blockName = "SandStairsBlock";
            if (tileArrayList[level][x, y] == 7) blockName = "StoneBlock";
            if (tileArrayList[level][x, y] == 8) blockName = "StoneStairsBlock";
            if (tileArrayList[level][x, y] == 9) blockName = "SandTrap";



            // ATTEMPT 3: using a list of types, still manual adding
            //List<Type> blockTypes = new List<Type>
            //{
            //    typeof(StoneBlock),
            //    typeof(GrassBlock),
            //    typeof(SandBlock),
            //    typeof(DirtBlock),
            //    typeof(StoneStairsBlock),
            //    typeof(SandStairsBlock),
            //    typeof(GrassTrap),
            //    typeof(DirtTrap),
            //};

            try
            {
                IMapObject block = (IMapObject)Activator.CreateInstance(Type.GetType($"MakingAPlatformer.Map.Blocks.{blockName}"), new object[] { new Vector2(y * blockSize, x * blockSize), randomNumber });
                
                //IMapObject block = (IMapObject)Activator.CreateInstance(blockTypes[tileArrayList[level][x, y] - 1], new object[] { new Vector2(y * blockSize, x * blockSize), randomNumber });

                // ATTEMPT 4: using static class, timing isn't correct so doesn't work

                // ATTEMPT 5: loading classes from folder, IT WORKS!!! but not perfect, because it works alphabetically...
                //IMapObject block = (IMapObject)Activator.CreateInstance(Type.GetType($"MakingAPlatformer.Map.Blocks.{BlockManager.BlockTypeNames[tileArrayList[level][x, y] - 1]}"), new object[] { new Vector2(y * blockSize, x * blockSize), randomNumber });

                return block;
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- EXCEPTION: " + e.Message);
                return null;
            }
        }
    }
}