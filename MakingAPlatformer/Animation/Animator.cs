using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Animator
    {
        public List<Animation> Animations;

        public Animator()
        {
            Animations = new List<Animation>();
            Animations.Add(new NormalAnimation("HeroRunRight", "Hero/Normal/Run", 8));
            Animations.Add(new MirroredAnimation("HeroRunLeft", "Hero/Mirrored/Run-MIRRORED", 8));

            foreach (Animation animation in Animations)
            {
                for (int i = 0; i <= 1050; i = i + 150)
                {
                    animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, 150, 150)));
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Animation animation in Animations)
            {
                animation.Update(gameTime);
            }
        }
    }
}
