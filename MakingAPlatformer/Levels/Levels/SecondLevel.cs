using MakingAPlatformer.Levels;
using MakingAPlatformer.Management;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MakingAPlatformer.LevelManagement.Levels
{
    public class SecondLevel : Level
    {
        public override int LevelId { get; set; } = 1;
        public List<Transition> DeathZone { get; set; }
        
        public SecondLevel(Game1 game) : base(game) { }

        protected override void Initialize()
        {
            transitionZone = new Transition(1, 10, 1, 1, "Victory zone");

            DeathZone = new List<Transition>
            {
                //new DeathZone(new Vector2(1550 - (62 * 10), 930 - (62 * 1) - 10), "First zone 2 blocks", (62 * 2), (62 * 1) + 10), //screen width - (amount of blocks), screen height - (amount of blocks) - block height
                //new DeathZone(new Vector2(1550 - (62 * 7), 930 - (62 * 1) - 10), "Second zone 2 blocks", (62 * 2), (62 * 1) + 10),
                //new DeathZone(new Vector2(1550 - (62 * 3), 930 - (62 * 1) - 10), "Third zone 1 blocks", (62 * 1), (62 * 1) + 10),

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

        // DEBUG: remove method
        //public override void Draw(GameTime gameTime)
        //{
        //    spriteBatch.Begin();

        //    hero.Draw(spriteBatch);
        //    healthManager.Draw(spriteBatch);

        //    mapMaker.DrawLevel(spriteBatch);

        //    // DRAW COLLIDERS
        //    collisionManager.DrawAllColliders(spriteBatch, graphics, Color.Red, Color.Green);
        //    foreach (Transition zone in DeathZone) zone.Draw(spriteBatch, game.GraphicsDevice, Color.Fuchsia);
        //    transitionZone.Draw(spriteBatch, graphics, Color.Fuchsia);

        //    spriteBatch.End();
        //}
    }
}
