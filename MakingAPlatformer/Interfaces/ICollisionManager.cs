using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.Interfaces
{
    public interface ICollisionManager
    {
        public List<BoxCollider> Colliders { get; set; }
        public List<IMapObject> Blocks { get; set; }
        public IGameObject Hero { get; set; }

        void CheckCollisions(IHealthManager healthManager);
        void DrawBlockColliders(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Color blockColor);
        void DrawAllColliders(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Color heroColor, Color blockColor);
    }
}
