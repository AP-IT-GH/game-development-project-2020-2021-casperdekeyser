using MakingAPlatformer.Interfaces;

namespace MakingAPlatformer
{
    public class AnimateCommand : IAnimateCommand
    {
        public void Execute(IAnimateable transform, Movement moveDirection)
        {
            if (Hero.State == States.Jumping)
            {
                if (transform.Animator.PreviousAnimation == PossibleAnimations.RunLeft || transform.Animator.PreviousAnimation == PossibleAnimations.IdleLeft)
                    transform.AnimToPlay = PossibleAnimations.JumpLeft;
                if (transform.Animator.PreviousAnimation == PossibleAnimations.RunRight || transform.Animator.PreviousAnimation == PossibleAnimations.IdleRight)
                    transform.AnimToPlay = PossibleAnimations.JumpRight;
            }
            else
            {
                if (moveDirection == Movement.MoveRight)
                    transform.AnimToPlay = PossibleAnimations.RunLeft;
                if (moveDirection == Movement.MoveLeft)
                    transform.AnimToPlay = PossibleAnimations.RunRight;
                if (moveDirection == Movement.Idle)
                {
                    if (transform.Animator.PreviousAnimation == PossibleAnimations.RunLeft || transform.Animator.PreviousAnimation == PossibleAnimations.JumpLeft)
                        transform.AnimToPlay = PossibleAnimations.IdleLeft;
                    if (transform.Animator.PreviousAnimation == PossibleAnimations.RunRight || transform.Animator.PreviousAnimation == PossibleAnimations.JumpRight)
                        transform.AnimToPlay = PossibleAnimations.IdleRight;
                }
            }
        }
    }
}
