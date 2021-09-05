using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Interfaces
{
    public interface ITimeManager
    {
        bool SecondsElapsed(int seconds, GameTime gameTime);
    }
}
