using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Levels;
using MakingAPlatformer.Timing;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.LevelManagement.Screens
{
    public abstract class Screen : GameScreen
    {
        public abstract Color DrawingColor { get; set; }
        public virtual int Duration { get; set; } = 5;

        // Timing
        protected ITimeManager timer;

        public Screen(Game1 game) : base(game)
        {
            timer = new Timer();
        }

        protected override void Initialize()
        {
            base.Initialize();
            collisionManager = new CollisionManager(mapMaker.Blocks);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            game.ContentLoader.LoadContent(content, mapMaker);
        }

        public override void Update(GameTime gameTime)
        {
            if (timer.SecondsElapsed(Duration, gameTime)) game.Exit();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            mapMaker.DrawLevel(spriteBatch);
            collisionManager.DrawBlockColliders(spriteBatch, game.GraphicsDevice, DrawingColor); // fill out blocks

            spriteBatch.End();
        }
    }
}
