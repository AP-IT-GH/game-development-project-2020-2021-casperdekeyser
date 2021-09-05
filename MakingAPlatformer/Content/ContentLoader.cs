using MakingAPlatformer.Interfaces;
using MakingAPlatformer.UI;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer.Content
{
    public class ContentLoader : IContentLoader
    {
        public void LoadContent(ContentManager content, ILevelCreator mapMaker, IAnimateable hero = null, IHealthManager healthManager = null)
        {
            foreach (IMapObject block in mapMaker.Blocks)
            {
                block.Spritesheet = content.Load<Texture2D>(block.SpritesheetPath);
            }

            if (hero != null)
            {
                foreach (Animation animation in hero.Animator.Animations)
                {
                    animation.SpriteSheet = content.Load<Texture2D>(animation.SpriteSheetPath);
                }
            }

            if (healthManager != null)
            {
                foreach (Heart heart in healthManager.HealthBar)
                {
                    heart.Spritesheet = content.Load<Texture2D>(heart.SpritesheetPath);
                }
            }
        }
    }
}
