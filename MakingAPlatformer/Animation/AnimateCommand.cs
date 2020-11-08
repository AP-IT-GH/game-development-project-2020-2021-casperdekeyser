using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class AnimateCommand
    {
        public void Execute(IAnimateable transform, Vector2 direction)
        {
            if (direction.X > 0)
                transform.AnimToPlay = PossibleAnimations.RunLeft;
            if (direction.X < 0)
                transform.AnimToPlay = PossibleAnimations.RunRight;
            if (direction.X == 0)
            {
                if (transform.Animator.previousAnimation == PossibleAnimations.RunLeft)
                    transform.AnimToPlay = PossibleAnimations.IdleLeft;
                if (transform.Animator.previousAnimation == PossibleAnimations.RunRight)
                    transform.AnimToPlay = PossibleAnimations.IdleRight;
            }
        }
    }
}
