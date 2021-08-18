using MakingAPlatformer.Management;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.LevelManagement.Levels
{

    public class FirstLevel : Level
    {
        public override int LevelId { get; set; } = 0;

        public FirstLevel(Game1 game) : base(game) { }

        protected override void Initialize()
        {
            transitionZone = new Transition(new Vector2(1500, 0), "Transition zone to level 2", 62, 62);
            base.Initialize();
        }
    }
}
