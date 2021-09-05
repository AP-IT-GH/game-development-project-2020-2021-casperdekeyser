using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework.Media;

namespace MakingAPlatformer.Sound.Music
{
    public abstract class MusicTrack : IMusicTrack
    {
        public abstract string FilePath { get; set; }
        public abstract int[] LevelsToPlayTrack { get; set; }
        public Song Song { get; set; }

        public MusicTrack(Song song)
        {
            Song = song;
        }
    }
}
