using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public abstract class Animator
    {
        public List<Animation> Animations;
        protected float previousState;

        public Animator()
        {
            Animations = new List<Animation>();
        }

        public void InitializeAnimations()
        {
            foreach (Animation animation in Animations)
            {
                for (int i = 0; i <= animation.Width * (animation.FrameAmount - 1); i = i + animation.Width)
                {
                    animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, 150, 150)));
                }
            }
        }

        public abstract Animation Animate(float state);
        
        public void Update(GameTime gameTime)
        {
            foreach (Animation animation in Animations)
            {
                animation.Update(gameTime);
            }
        }
    }
}
