﻿using MakingAPlatformer.LevelManagement.Screens;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Levels.Screens
{
    class StartScreen : Screen
    {
        public override int ScreenId { get; set; } = 4;
        public override int[,] TileArray { get; set; } =
        {
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
            { 1,0,0,1,0,0,0,1,0,1,1,1,1,0,1,0,0,0,1,0,0,0,0,0,1 },
            { 1,0,0,1,0,0,0,1,0,1,0,0,1,0,1,0,0,0,1,0,0,0,0,0,1 },
            { 1,0,0,1,0,0,0,1,0,1,1,1,1,0,1,0,0,0,1,0,0,0,0,0,1 },
            { 1,0,0,1,0,1,0,1,0,1,0,0,1,0,1,0,0,0,1,0,0,0,0,0,1 },
            { 1,0,0,1,1,1,1,1,0,1,0,0,1,0,1,1,1,0,1,1,1,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,0,1,0,0,1 },
            { 1,0,0,0,0,0,0,0,1,0,0,1,0,1,0,0,1,0,1,1,0,1,0,0,1 },
            { 1,0,0,0,0,0,0,0,1,1,1,1,0,1,0,0,1,0,1,0,1,1,0,0,1 },
            { 1,0,0,0,0,0,0,0,1,0,1,0,0,1,0,0,1,0,1,0,0,1,0,0,1 },
            { 1,0,0,0,0,0,0,0,1,0,0,1,0,1,1,1,1,0,1,0,0,1,0,0,1 },
            { 1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        };
        public override Color DrawingColor { get; set; } = Color.CornflowerBlue; // Cornflower blue
        public override Color BackgroundColor { get; set; } = Color.Beige; // beige
        public override int Duration { get; set; } = 3;

        public StartScreen(Game1 game) : base(game) { }

        public override void Update(GameTime gameTime)
        {
            if (timer.SecondsElapsed(Duration, gameTime)) game.ScreenManager.ManageTransitions(4);
        }
    }
}
