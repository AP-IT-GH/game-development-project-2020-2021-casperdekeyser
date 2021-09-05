using Microsoft.Xna.Framework.Content;

namespace MakingAPlatformer.Interfaces
{
    public interface ISoundManager
    {
        void LoadSound(ContentManager content);
        void PlaySound(int songNumber);
    }
}
