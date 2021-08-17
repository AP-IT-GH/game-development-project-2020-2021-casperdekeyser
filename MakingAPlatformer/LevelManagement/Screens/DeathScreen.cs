using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.LevelManagement.Screens
{
    public class DeathScreen : Screen
    {
        public override int ScreenId { get; set; } = 4;

        public DeathScreen(Game1 game) : base(game) { }

    }
}
