using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace MakingAPlatformer.Sound
{
    public class SoundManager : ISoundManager
    {
        private List<Song> _songList;
        public void LoadSound(ContentManager content)
        {
            _songList = new List<Song>
            {
                content.Load<Song>("Sound/background-music"),
                content.Load<Song>("Sound/victory-music"),
                content.Load<Song>("Sound/death-music"),
            };
        }

        public void PlaySound(int songNumber)
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.01f;
            if (songNumber == 0 || songNumber == 1 || songNumber == 4) MediaPlayer.Play(_songList[0]);
            if (songNumber == 2) MediaPlayer.Play(_songList[1]);
            if (songNumber == 3) MediaPlayer.Play(_songList[2]);
        }
    }
}
