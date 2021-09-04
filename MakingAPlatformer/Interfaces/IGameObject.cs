using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer
{
    public interface IGameObject
    {
        Animator Animator { get; set; }
        public BoxCollider Collider { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
