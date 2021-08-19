using MakingAPlatformer.LevelManagement;
using MakingAPlatformer.Map;
using MakingAPlatformer.UI;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Content
{
    public class ContentLoader
    {
        public void LoadContent(ContentManager content, MapMaker mapMaker, IGameObject hero = null, HealthManager healthManager = null)
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
