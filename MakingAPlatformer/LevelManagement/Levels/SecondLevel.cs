using MakingAPlatformer.Management;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.LevelManagement.Levels
{
    public class SecondLevel : Level
    {
        public override int LevelId { get; set; } = 2;
        public Transition deathZone { get; set; }
        public SecondLevel(Game1 game) : base(game) { }

        protected override void Initialize()
        {
            transitionZone = new Transition(new Vector2(1500, 0), "Victory zone", 62, 62);
            deathZone = new Transition(new Vector2(1116, 847), "Victory zone", 62*4, 62+20);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (deathZone.CheckCollision(hero)) _game.ScreenManager.ManageTransitions(3); // deathscreen
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            mapMaker.DrawLevel(LevelId, _spriteBatch);

            // DRAW COLLIDERS
            //collisionManager.DrawAllColliders(_spriteBatch, _game.GraphicsDevice, Color.Red, Color.Green);
            deathZone.Draw(_spriteBatch, _graphics, Color.Fuchsia);

            _spriteBatch.End();

        }
    }
}
