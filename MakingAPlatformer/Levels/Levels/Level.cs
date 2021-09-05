using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Levels;
using MakingAPlatformer.UI;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.LevelManagement
{
    public abstract class Level : GameScreen
    {
        // Hero
        protected ICharacter hero;
        protected Vector2 heroStartPosition = new Vector2(50, 868 - 96);
        protected IAnimator heroAnimator;
        protected IInputReader inputReader;
        protected IAnimateCommand animateCommand;

        protected ITransition transitionZone;

        // UI
        protected IHealthManager healthManager;

        private int _amountOfLives = 3;


        public Level(Game1 game) : base(game) { }

        protected override void Initialize()
        {
            base.Initialize();
            // Hero
            heroAnimator = new HeroAnimator();
            inputReader = new KeyboardReader();
            animateCommand = new AnimateCommand();
            hero = new Hero(heroStartPosition, heroAnimator, inputReader, animateCommand);

            // UI
            healthManager = new HealthManager(_amountOfLives, hero, heroStartPosition, game.ScreenManager);

            // Collision
            collisionManager = new CollisionManager(mapMaker.Blocks, hero);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            game.ContentLoader.LoadContent(content, mapMaker, hero, healthManager);
        }

        public override void Update(GameTime gameTime)
        {
            if (transitionZone.CheckCollision(hero)) game.ScreenManager.ManageTransitions(ScreenId);
            collisionManager.CheckCollisions(healthManager);
            hero.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            hero.Draw(spriteBatch);
            healthManager.Draw(spriteBatch);
            mapMaker.DrawLevel(spriteBatch);

            // DRAW COLLIDERS
            //collisionManager.DrawAllColliders(spriteBatch, graphics, Color.Red, Color.Green);
            //transitionZone.Draw(spriteBatch, graphics, Color.Fuchsia);

            spriteBatch.End();
        }
    }
}
