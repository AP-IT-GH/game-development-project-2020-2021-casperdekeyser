using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.Interfaces
{
    public interface ILevelCreator
    {
        public List<IMapObject> Blocks { get; set; }
        void CreateLevel(int[,] tileArray);
        void DrawLevel(SpriteBatch spriteBatch);
    }
}
