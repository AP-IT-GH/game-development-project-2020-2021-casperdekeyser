using MakingAPlatformer.Management;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            transitionZone = new Transition(new Vector2(1500, 0), "Victory zone", 62, 62);

            DeathZone = new List<Transition>
            {
                new Transition(new Vector2(1550 - (62 * 7), 930 - (62 * 1) - 10), "Lower right death zone", (62 * 4), (62 * 1) + 10), //screen width - (amount of blocks), screen height - (amount of blocks) - block height
                new Transition(new Vector2(1550 - (62 * 1), 930 - (62 * 5) - 10), "Right wall death zone", (62 * 1), (62 * 5) + 10),
            };

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Transition zone in DeathZone)
            {
                if (zone.CheckCollision(hero)) _healthManager.TakeDamage();
            }
            base.Update(gameTime);
        }

        // DEBUG: remove method
        //public override void Draw(GameTime gameTime)
        //{
        //    _spriteBatch.Begin();

        //    hero.Draw(_spriteBatch);

        //    mapMaker.DrawLevel(_spriteBatch);

        //    // DRAW COLLIDERS
        //    //collisionManager.DrawAllColliders(_spriteBatch, _game.GraphicsDevice, Color.Red, Color.Green);
        //    foreach (Transition zone in DeathZone) zone.Draw(_spriteBatch, _graphics, Color.Fuchsia);
        //    transitionZone.Draw(_spriteBatch, _graphics, Color.Fuchsia);

        //    _spriteBatch.End();

        //}
    }
}
