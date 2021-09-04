
namespace MakingAPlatformer
{
    public interface IAnimateable
    {
        PossibleAnimations AnimToPlay { get; set; }
        Animator Animator { get; set; }
    }
}
