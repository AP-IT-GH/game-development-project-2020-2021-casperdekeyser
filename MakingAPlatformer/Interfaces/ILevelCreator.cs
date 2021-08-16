using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Interfaces
{
    public interface ILevelCreator
    {
        public byte[,] TileArray { get; set; }
        public IMapObject[,] BlockArray { get; set; }
        public List<IMapObject> Blocks { get; set; }
        void CreateWorld();
        void DrawWorld(SpriteBatch spriteBatch);
    }
}
