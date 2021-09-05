using Microsoft.Xna.Framework.Content;

namespace MakingAPlatformer.Interfaces
{
    public interface IContentLoader
    {
        void LoadContent(ContentManager content, ILevelCreator mapMaker, ISoundManager soundManager, IAnimateable hero = null, IHealthManager healthManager = null);
    }
}
