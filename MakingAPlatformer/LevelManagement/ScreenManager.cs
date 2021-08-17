using MakingAPlatformer.Interfaces;
using MakingAPlatformer.LevelManagement.Levels;
using MakingAPlatformer.LevelManagement.Screens;

namespace MakingAPlatformer
{
    public class ScreenManager
    {
        private Game1 _game;

        public ScreenManager(Game1 game)
        {
            _game = game;
        }
        public void ChangeScreen(IGameScreen nextScreen)
        {
            _game.NextLevel = nextScreen;
        }

        public void CheckForNextLevel()
        {
            if (_game.NextLevel != null)
            {
                _game.CurrentLevel = _game.NextLevel;
                _game.NextLevel = null;
            }
        }

        public void ManageTransitions(int levelId)
        {
            if (levelId == 1) ChangeScreen(new SecondLevel(_game));
            if (levelId == 2) ChangeScreen(new VictoryScreen(_game));
            if (levelId == 3) ChangeScreen(new DeathScreen(_game));
        }

    }
}
