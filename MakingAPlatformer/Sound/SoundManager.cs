using MakingAPlatformer.Interfaces;
using MakingAPlatformer.Sound.Music;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace MakingAPlatformer.Sound
{
    public class SoundManager : ISoundManager
    {
        private List<IMusicTrack> _trackList = new List<IMusicTrack>
            {
                new BackGroundTrack(),
                new VictoryTrack(),
                new DeathTrack(),
                new StartTrack(),
            };

        public void LoadSound(ContentManager content)
        {
            foreach (IMusicTrack track in _trackList)
            {
                track.LoadSong(content);
            }
        }

        public void PlaySound(int songNumber)
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.1f;

            foreach (IMusicTrack track in _trackList)
            {
                for (int i = 0; i < track.LevelsToPlayTrack.Length; i++)
                {
                    if (track.LevelsToPlayTrack[i] == songNumber) MediaPlayer.Play(track.Song);
                }
            }
        }
    }
}
