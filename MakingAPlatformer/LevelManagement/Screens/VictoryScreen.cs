using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.LevelManagement.Screens
{
    public class VictoryScreen : Screen
    {
        public override int ScreenId { get; set; } = 3;

        public VictoryScreen(Game1 game) : base(game) { }
    }
}
