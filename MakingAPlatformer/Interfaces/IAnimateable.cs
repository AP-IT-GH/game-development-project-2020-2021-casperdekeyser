using MakingAPlatformer.Interfaces;

namespace MakingAPlatformer
{
    public interface IAnimateable
    {
        PossibleAnimations AnimToPlay { get; set; }
        IAnimator Animator { get; set; }
    }
}
