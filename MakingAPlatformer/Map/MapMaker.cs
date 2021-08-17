using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Map.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map
{
    public class MapMaker
    {
        public byte[,] Level1TileArray { get; set; }
        public byte[,] Level2TileArray { get; set; }
        public byte[,] VictoryTileArray { get; set; }
        public byte[,] DeathTileArray { get; set; }
        public IMapObject[,] Level1BlockArray { get; set; }
        public IMapObject[,] Level2BlockArray { get; set; }
        public IMapObject[,] VictoryBlockArray { get; set; }
        public IMapObject[,] DeathBlockArray { get; set; }
        public List<IMapObject> Blocks { get; set; }

        private int mapLength = 15;
        private int mapHeight = 25;
        private int blockSize = 62;


        public MapMaker()
        {
            Blocks = new List<IMapObject>();
            Level1BlockArray = new Block[mapLength, mapHeight];
            Level1TileArray = new byte[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
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
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };
            Level2BlockArray = new Block[mapLength, mapHeight];
            Level2TileArray = new byte[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1 },
                {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,1 },
                {0,0,0,0,1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0 },
                {1,1,1,1,1,1,0,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0 },
                {0,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0 },
                {1,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,1,0,0,0,0,0,0,0 },
                {1,0,0,0,1,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };
            VictoryBlockArray = new Block[mapLength, mapHeight];
            VictoryTileArray = new byte[,]
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
                
            };

        }

        public void CreateLevel(int level)
        {
            if (level == 1)
            {
                for (int x = 0; x < mapLength; x++)
                {
                    for (int y = 0; y < mapHeight; y++)
                    {
                        if (Level1TileArray[x, y] == 1)
                        {
                            if (x == 1 && y == 24) Level1BlockArray[x, y] = new StoneStairsBlock(new Vector2(y * blockSize, x * blockSize)); // stairs
                            else
                            {
                                if (x == 14) Level1BlockArray[x, y] = new GrassBlock(new Vector2(y * blockSize, x * blockSize)); // ground
                                else Level1BlockArray[x, y] = new StoneBlock(new Vector2(y * blockSize, x * blockSize)); // walls

                            }
                            Blocks.Add(Level1BlockArray[x, y]);
                        }
                    }
                }
            }
            if (level == 2)
            {
                for (int x = 0; x < mapLength; x++)
                {
                    for (int y = 0; y < mapHeight; y++)
                    {
                        if (Level2TileArray[x, y] == 1)
                        {
                            if (x == 1 && y == 24) Level2BlockArray[x, y] = new StoneStairsBlock(new Vector2(y * blockSize, x * blockSize)); // stairs
                            else
                            {
                                if (x == 14) Level2BlockArray[x, y] = new DirtBlock(new Vector2(y * blockSize, x * blockSize)); // ground
                                else Level2BlockArray[x, y] = new SandBlock(new Vector2(y * blockSize, x * blockSize)); // walls

                            }
                            Blocks.Add(Level2BlockArray[x, y]);
                        }
                    }
                }
            }
            if (level == 3)
            {
                {
                    for (int x = 0; x < mapLength; x++)
                    {
                        for (int y = 0; y < mapHeight; y++)
                        {
                            if (VictoryTileArray[x, y] == 1)
                            {
                                VictoryBlockArray[x, y] = new StoneBlock(new Vector2(y * blockSize, x * blockSize));
                                Blocks.Add(VictoryBlockArray[x, y]);
                            }
                        }
                    }
                }
            }
        }

        public void DrawLevel(int level, SpriteBatch spriteBatch)
        {
            IMapObject[,] mapObjects = Level1BlockArray;
            if (level == 2) mapObjects = Level2BlockArray;
            if (level == 3) mapObjects = VictoryBlockArray;

            for (int x = 0; x < mapLength; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (mapObjects[x, y] != null)
                    {
                        mapObjects[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
