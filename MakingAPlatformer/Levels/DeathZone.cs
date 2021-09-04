using MakingAPlatformer.Management;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Levels
{
    public class DeathZone : Transition
    {
        public DeathZone(Vector2 position, string name, int width, int height) : base(new Vector2(position.X + 20, position.Y), name, width - 40, height) { }
    }
}
