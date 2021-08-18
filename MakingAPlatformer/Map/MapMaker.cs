﻿using MakingAPlatformer.Map.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.Map
{
    public class MapMaker
    {
        private int mapLength = 15;
        private int mapHeight = 25;
        private int blockSize = 62;

        private IMapObject[,] blockArray;
        private List<int[,]> tileArrayList = new List<int[,]>();

        public List<IMapObject> Blocks;

        public MapMaker()
        {
            Blocks = new List<IMapObject>();
            blockArray = new Block[mapLength, mapHeight];
            tileArrayList = new List<int[,]>
            {
                new int[,] // level 1
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,5 },
                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,1 },
                    {0,0,0,0,1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,1 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0 },
                    {1,1,1,1,1,1,0,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0 },
                    {0,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0 },
                    {0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,1,0,0,0,0,0,0,0 },
                    {0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0 },
                    {2,8,7,2,2,8,8,2,7,9,2,7,2,9,9,7,8,8,8,2,9,2,8,7,2 },
                },
                new int[,] // level 2
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,6 },
                    {0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,3,3,0,0,0,0,3,3,3 },
                    {0,0,0,0,3,0,0,0,0,0,0,3,3,0,0,0,0,3,3,0,0,0,0,0,3 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0 },
                    {3,3,3,3,3,3,0,0,3,0,0,0,0,3,3,3,3,0,0,0,0,0,0,0,0 },
                    {0,3,3,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {3,0,0,0,0,0,0,0,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {3,0,0,0,0,3,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0,0,0,0,0 },
                    {3,0,0,0,3,3,0,0,0,0,0,0,0,0,3,3,0,3,0,0,0,0,0,0,0 },
                    {3,0,0,0,3,3,0,0,0,0,0,0,0,0,3,0,0,3,0,0,0,0,0,0,0 },
                    {10,4,11,12,4,4,11,10,4,12,4,4,4,11,12,4,10,4,0,0,0,0,10,11,12 },
                },
                new int[,] // victory
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,1,0,0,0,1,0,1,1,1,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0 },
                    {0,1,1,0,1,1,0,1,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0 },
                    {0,0,1,1,1,0,0,1,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,1,0,0,0,1,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,1,0,0,0,1,1,1,1,0,1,1,1,1,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0 },
                    {0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,0,0,1,0,1,0,0 },
                    {0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,1,0,1,0,1,0,0 },
                    {0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,1,1,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,1,0,1,0,0,1,0,1,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                },
                new int[,] // death
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,1,1,1,1,0,0,1,1,1,1,0,1,1,0,1,1,0,1,1,1,1,0,0 },
                    {0,0,1,0,0,0,0,0,1,0,0,1,0,1,1,1,1,1,0,1,0,0,0,0,0 },
                    {0,0,1,0,0,0,0,0,1,0,0,1,0,1,0,1,0,1,0,1,1,1,0,0,0 },
                    {0,0,1,0,1,1,1,0,1,1,1,1,0,1,0,0,0,1,0,1,0,0,0,0,0 },
                    {0,0,1,0,0,1,0,0,1,0,0,1,0,1,0,0,0,1,0,1,0,0,0,0,0 },
                    {0,0,1,1,1,1,0,0,1,0,0,1,0,1,0,0,0,1,0,1,1,1,1,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {0,0,0,1,1,1,1,0,1,0,0,0,1,0,1,1,1,1,0,1,1,1,1,0,0 },
                    {0,0,0,1,0,0,1,0,1,0,0,0,1,0,1,0,0,0,0,1,0,0,1,0,0 },
                    {0,0,0,1,0,0,1,0,1,0,0,0,1,0,1,1,1,0,0,1,1,1,1,0,0 },
                    {0,0,0,1,0,0,1,0,1,1,0,1,1,0,1,0,0,0,0,1,0,1,0,0,0 },
                    {0,0,0,1,0,0,1,0,0,1,1,1,0,0,1,0,0,0,0,1,0,0,1,0,0 },
                    {0,0,0,1,1,1,1,0,0,0,1,0,0,0,1,1,1,1,0,1,0,0,1,0,0 },
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                },
            };
        }

        public void CreateLevel(int level)
        {
            /* TYPES OF BLOCKS
             * 0 -> empty
             * 1 -> stone
             * 2 -> grass
             * 3 -> sand
             * 4 -> dirt
             * 5 -> stone stairs
             * 6 -> sand stairs
             */

            /* LEVEL IDs
             * 0 -> level1
             * 1 -> level2
             * 2 -> victory
             * 3 -> death
             */

            for (int x = 0; x < mapLength; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (tileArrayList[level][x, y] != 0)
                    {
                        if (tileArrayList[level][x, y] == 1) blockArray[x, y] = new StoneBlock(new Vector2(y * blockSize, x * blockSize));
                        if (tileArrayList[level][x, y] == 2) blockArray[x, y] = new GrassBlock(new Vector2(y * blockSize, x * blockSize));
                        if (tileArrayList[level][x, y] == 3) blockArray[x, y] = new SandBlock(new Vector2(y * blockSize, x * blockSize));
                        if (tileArrayList[level][x, y] == 4) blockArray[x, y] = new DirtBlock(new Vector2(y * blockSize, x * blockSize));
                        if (tileArrayList[level][x, y] == 5) blockArray[x, y] = new StoneStairsBlock(new Vector2(y * blockSize, x * blockSize));
                        if (tileArrayList[level][x, y] == 6) blockArray[x, y] = new SandStairsBlock(new Vector2(y * blockSize, x * blockSize));
                        if (tileArrayList[level][x, y] == 7) blockArray[x, y] = new GrassBlock(new Vector2(y * blockSize, x * blockSize), 1);
                        if (tileArrayList[level][x, y] == 8) blockArray[x, y] = new GrassBlock(new Vector2(y * blockSize, x * blockSize), 2);
                        if (tileArrayList[level][x, y] == 9) blockArray[x, y] = new GrassBlock(new Vector2(y * blockSize, x * blockSize), 3);
                        if (tileArrayList[level][x, y] == 10) blockArray[x, y] = new DirtBlock(new Vector2(y * blockSize, x * blockSize), 1);
                        if (tileArrayList[level][x, y] == 11) blockArray[x, y] = new DirtBlock(new Vector2(y * blockSize, x * blockSize), 2);
                        if (tileArrayList[level][x, y] == 12) blockArray[x, y] = new DirtBlock(new Vector2(y * blockSize, x * blockSize), 3);

                        Blocks.Add(blockArray[x, y]);
                    }
                }
            }
        }

        public void DrawLevel(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < mapLength; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (blockArray[x, y] != null) blockArray[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}
