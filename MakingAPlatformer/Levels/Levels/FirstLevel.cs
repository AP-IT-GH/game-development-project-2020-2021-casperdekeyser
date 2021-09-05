using MakingAPlatformer.Management;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.LevelManagement.Levels
{

    public class FirstLevel : Level
    {
        public override int ScreenId { get; set; } = 0;
        public override int[,] TileArray { get; set; } =
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,7,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,8 },
            { 0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,7,7,0,0,0,0,7,7,7 },
            { 0,0,0,0,7,0,0,0,0,0,0,7,7,0,0,0,0,7,7,0,0,0,0,0,7 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0 },
            { 7,7,7,7,7,7,0,0,7,0,0,0,0,7,7,7,7,0,0,0,0,0,0,0,0 },
            { 0,7,7,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,7,7,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,7,7,7,0,0,0,0,0,0,0 },
            { 0,0,0,0,7,7,0,0,0,0,0,0,0,0,7,7,0,7,0,0,0,0,0,0,0 },
            { 0,0,0,0,7,7,0,0,0,0,0,0,0,0,7,0,0,7,0,0,0,0,0,0,0 },
            { 3,3,3,3,3,3,3,3,3,3,3,3,4,3,3,3,3,3,3,3,4,3,4,3,3 },
        };
        public override Color BackgroundColor { get; set; } = Color.LightGray;


        public FirstLevel(Game1 game) : base(game) { }

        protected override void Initialize()
        {
            transitionZone = new Transition(1, 15, 1, 1, "Transition zone to level 2");
            base.Initialize();
        }
    }
}