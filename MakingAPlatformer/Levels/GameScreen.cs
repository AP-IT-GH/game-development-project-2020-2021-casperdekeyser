using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer.Levels
{
    public abstract class GameScreen : IGameScreen
    {
        public abstract int ScreenId { get; set; }
        public abstract int[,] TileArray { get; set; }
        public virtual Color BackgroundColor { get; set; } = Color.Beige;

        // Game
        protected ContentManager content;
        protected GraphicsDevice graphics;
        protected SpriteBatch spriteBatch;
        protected Game1 game;

        // Map
        protected IBlockCreator blockGenerator;
        protected ILevelCreator mapMaker;

        // Collision
        protected ICollisionManager collisionManager;


        public GameScreen(Game1 game)
        {
            this.game = game;
            content = game.Content;
            graphics = game.GraphicsDevice;

            Initialize();
            LoadContent();
        }

        protected virtual void Initialize()
        {
            // Map
            blockGenerator = new BlockGenerator();
            mapMaker = new MapMaker(blockGenerator);
            mapMaker.CreateLevel(TileArray);
        }

        protected virtual void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics);
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
