using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Interfaces
{
    public interface IRespawnable
    {
        Vector2 Position { get; set; }
        JumpCommand JumpCommand { get; set; }
    }
}
