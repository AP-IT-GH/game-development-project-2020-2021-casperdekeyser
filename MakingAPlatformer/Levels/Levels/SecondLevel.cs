using MakingAPlatformer.Levels;
using MakingAPlatformer.Management;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MakingAPlatformer.LevelManagement.Levels
{
    public class SecondLevel : Level
    {
        public override int ScreenId { get; set; } = 1;
        public override int[,] TileArray { get; set; } =
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,5,9,5,0,0,5,5 },
            { 5,5,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0 },
            { 5,5,0,0,0,0,0,0,0,5,5,0,0,0,5,0,0,0,0,0,0,0,0,0,0 },
            { 0,5,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,5,9,5,0,0,0,5,5,0,0,0,0,5,5,5,0,0,0,5,5,6 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5 },
            { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,5 },
            { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,5,9,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,5,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,5,9,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,5,5,0,0,0,0,5,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,0,1,1 },
        };
        public override Color BackgroundColor { get; set; } = Color.Ivory;
        public List<Transition> DeathZone { get; set; }
    
        public SecondLevel(Game1 game) : base(game) { }

        protected override void Initialize()
        {
            transitionZone = new Transition(1, 10, 1, 1, "Victory zone");

            DeathZone = new List<Transition>
            {
                new DeathZone(10, 1, 2, 1, "First zone 2 blocks"),
                new DeathZone(7, 1, 2, 1, "Second zone 2 blocks"),
                new DeathZone(3, 1, 1, 1, "Third zone 1 block"),
            };

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Transition zone in DeathZone)
            {
                if (zone.CheckCollision(hero)) game.ScreenManager.ManageTransitions(2); // game over
            }
            base.Update(gameTime);
        }
    }
}
