using MakingAPlatformer.Content;
using MakingAPlatformer.Interfaces;
using MakingAPlatformer.LevelManagement.Levels;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MakingAPlatformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        public ScreenManager ScreenManager;
        public ContentLoader ContentLoader;

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
            _graphics.PreferredBackBufferWidth = 1550;
            _graphics.PreferredBackBufferHeight = 930;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //BlockManager.LoadBlocks();
            CurrentLevel = new FirstLevel(this);
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
