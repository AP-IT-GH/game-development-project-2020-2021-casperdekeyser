using MakingAPlatformer.Management;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.LevelManagement.Levels
{

    public class FirstLevel : Level
    {
        public override int LevelId { get; set; } = 0;
        public override Color BackgroundColor { get; set; } = Color.LightGray;

        public FirstLevel(Game1 game) : base(game) { }

        protected override void Initialize()
        {
            transitionZone = new Transition(1, 15, 1, 1, "Transition zone to level 2");
            base.Initialize();
        }
    }
}