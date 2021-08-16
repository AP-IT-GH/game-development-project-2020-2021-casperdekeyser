using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Map
{
    public class MapMaker : ILevelCreator
    {
        public byte[,] TileArray { get; set; }
        public IMapObject[,] BlockArray { get; set; }
        public List<IMapObject> Blocks { get; set; }

        private int mapLength = 15;
        private int mapHeight = 25;
        private int blockSize = 62;


        public MapMaker()
        {
            Blocks = new List<IMapObject>();
            BlockArray = new Block[mapLength, mapHeight];
            TileArray = new byte[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,1 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            };
        }

        public void CreateWorld()
        {
            for (int x = 0; x < mapLength; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (TileArray[x, y] == 1)
                    {
                        if (x == 14) BlockArray[x, y] = new GrassBlock(new Vector2(y * blockSize, x * blockSize)); // ground
                        else BlockArray[x, y] = new StoneBlock(new Vector2(y * blockSize, x * blockSize)); // walls
                        Blocks.Add(BlockArray[x, y]);
                    }
                }
            }
        }

        public void DrawWorld(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < mapLength; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (BlockArray[x, y] != null)
                    {
                        BlockArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
