using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Interfaces
{
    public interface IGameScreen
    {
        public Color BackgroundColor { get; set; }

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
