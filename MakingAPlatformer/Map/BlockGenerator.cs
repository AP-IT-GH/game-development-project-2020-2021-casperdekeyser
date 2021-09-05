using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;


namespace MakingAPlatformer.Map
{
    public class BlockGenerator : IBlockCreator
    {
        private string[] _blockNames = {
            "--- Testing Block ---",
            "DirtBlock",
            "DirtTrap",
            "GrassBlock",
            "GrassTrap",
            "SandBlock",
            "SandStairsBlock",
            "StoneBlock",
            "StoneStairsBlock",
            "SandTrap",
        };

        public IMapObject GenerateBlock(int[,] tileArray, int x, int y, int blockSize)
        {
            Random rng = new Random();
            int randomNumber = rng.Next(4);

            try
            {
                return (IMapObject)Activator.CreateInstance(Type.GetType($"MakingAPlatformer.Map.Blocks.{_blockNames[tileArray[x, y]]}"), new object[] { new Vector2(y * blockSize, x * blockSize), randomNumber });
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- EXCEPTION: " + e.Message);
                throw;
            }
        }
    }
}