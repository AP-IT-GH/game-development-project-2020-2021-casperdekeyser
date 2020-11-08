using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class HeroAnimator : Animator
    {

        public override Animation Animate(PossibleAnimations animToPlay)
        {
            if (animToPlay == PossibleAnimations.RunLeft)
            {
                previousAnimation = animToPlay;
                return Animations[2];
            }
            if (animToPlay == PossibleAnimations.RunRight)
            {
                previousAnimation = animToPlay;
                return Animations[3];
            }
            if (animToPlay == PossibleAnimations.IdleLeft)
            {
                 return Animations[0];
            }
            if (animToPlay == PossibleAnimations.IdleRight)
            {
                return Animations[1];
            }
            // default;
            return Animations[0];
        }
    }
}
