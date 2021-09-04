using MakingAPlatformer.LevelManagement.Screens;
using MakingAPlatformer.Timing;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Levels.Screens
{
    class StartScreen : Screen
    {
        public override int ScreenId { get; set; } = 4;
        public override Color DrawingColor { get; set; } = Color.CornflowerBlue;
        public override int Duration { get; set; } = 3;

        public StartScreen(Game1 game) : base(game) { }

        public override void Update(GameTime gameTime)
        {
            if (timer.SecondsElapsed(Duration, gameTime)) game.ScreenManager.ManageTransitions(4);
        }
    }
}
