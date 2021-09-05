using Microsoft.Xna.Framework.Media;

namespace MakingAPlatformer.Interfaces
{
    public interface IMusicTrack
    {
        abstract string FilePath { get; set; }

        abstract int[] LevelsToPlayTrack { get; set; }
        Song Song { get; set; }
    }
}
