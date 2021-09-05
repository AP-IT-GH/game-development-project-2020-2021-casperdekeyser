using Microsoft.Xna.Framework.Content;

namespace MakingAPlatformer.Interfaces
{
    public interface IContentLoader
    {
        void LoadContent(ContentManager content, ILevelCreator mapMaker, IAnimateable hero = null, IHealthManager healthManager = null);
    }
}
