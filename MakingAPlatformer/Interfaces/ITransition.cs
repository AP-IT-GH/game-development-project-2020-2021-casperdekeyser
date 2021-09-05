using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer.Interfaces
{
    public interface ITransition
    {
        bool CheckCollision(IGameObject hero);
        void Draw(SpriteBatch spriteBatch, GraphicsDevice graphics, Color color);
    }
}
