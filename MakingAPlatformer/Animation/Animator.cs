using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class Animator
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

        public Animation Animate(float state)
        {
            if (state > 0)
            {
                previousState = state;
                return Animations[2];
            }
            if (state < 0)
            {
                previousState = state;
                return Animations[3];

            }
            if (state == 0)
            {
                if (previousState > 0)
                    return Animations[0];
                if (previousState < 0)
                    return Animations[1];
            }
            // default;
            return Animations[0];
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
