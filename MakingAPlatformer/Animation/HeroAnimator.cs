using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class HeroAnimator : Animator
    {

        public override Animation Animate(float state)
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
    }
}
