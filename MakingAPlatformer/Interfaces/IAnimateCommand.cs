
namespace MakingAPlatformer.Interfaces
{
    public interface IAnimateCommand
    {
        void Execute(IAnimateable transform, Movement moveDirection);
    }
}
