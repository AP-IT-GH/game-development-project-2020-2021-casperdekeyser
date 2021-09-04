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
            /* LEVEL IDs
             * 0 -> level1
             * 1 -> level2
             * 2 -> victory
             * 3 -> death
             * 4 -> start
             */

            if (levelId == 0) ChangeScreen(new SecondLevel(_game)); // from level1 to level2
            if (levelId == 1) ChangeScreen(new VictoryScreen(_game)); // from level2 to victory
            if (levelId == 2) ChangeScreen(new DeathScreen(_game)); // from level2 to death
            if (levelId == 4) ChangeScreen(new FirstLevel(_game)); // from start to level1
        }
    }
}
