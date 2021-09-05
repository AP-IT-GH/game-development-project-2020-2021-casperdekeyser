using MakingAPlatformer.Content;
using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Levels.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MakingAPlatformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        public IScreenManager ScreenManager;
        public IContentLoader ContentLoader;

        public IGameScreen CurrentLevel;
        public IGameScreen NextLevel;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            ScreenManager = new ScreenManager(this);
            ContentLoader = new ContentLoader();
        }

        protected override void Initialize()
        {
            IsMouseVisible = false;
            _graphics.PreferredBackBufferWidth = 1550;
            _graphics.PreferredBackBufferHeight = 930;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            CurrentLevel = new StartScreen(this);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            ScreenManager.CheckForNextLevel();
            CurrentLevel.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(CurrentLevel.BackgroundColor);
            CurrentLevel.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
