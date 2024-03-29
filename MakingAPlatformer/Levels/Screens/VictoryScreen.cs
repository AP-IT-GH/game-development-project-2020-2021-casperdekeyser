﻿using Microsoft.Xna.Framework;

namespace MakingAPlatformer.LevelManagement.Screens
{
    public class VictoryScreen : Screen
    {
        public override int ScreenId { get; set; } = 2;
        public override int[,] TileArray { get; set; } =
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,1,0,0,0,1,0,1,1,1,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0 },
            { 0,1,1,0,1,1,0,1,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0 },
            { 0,0,1,1,1,0,0,1,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,1,0,0,0,1,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,1,0,0,0,1,1,1,1,0,1,1,1,1,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0 },
            { 0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,0,0,1,0,1,0,0 },
            { 0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,1,0,1,0,1,0,0 },
            { 0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,0,1,1,0,1,0,0 },
            { 0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,0,1,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,1,0,1,0,0,1,0,1,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        };

        public override Color DrawingColor { get; set; } = Color.Green;

        public VictoryScreen(Game1 game) : base(game) { }
    }
}
