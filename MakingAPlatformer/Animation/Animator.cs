using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Animator
    {
        public List<HeroAnimation> Animations;

        public Animator()
        {
            Animations = new List<HeroAnimation>();
            Animations.Add(new HeroAnimation("Hero/Normal/Run"));
            Animations.Add(new HeroAnimation("Hero/Mirrored/Run-MIRRORED"));

            foreach (HeroAnimation animation in Animations)
            {
                for (int i = 0; i <= 1050; i = i + 150)
                {
                    animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, 150, 150)));
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (HeroAnimation animation in Animations)
            {
                animation.Update(gameTime);
            }
        }
    }
}
