using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.Interfaces
{
    public interface IScreenManager
    {
        void CheckForNextLevel();
        void ManageTransitions(int levelId);
    }
}
