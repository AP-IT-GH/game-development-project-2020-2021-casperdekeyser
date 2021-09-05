﻿using Microsoft.Xna.Framework.Media;

namespace MakingAPlatformer.Sound.Music
{
    public class VictoryTrack : MusicTrack
    {
        public override string FilePath { get; set; } = "Sound/victory-music";
        public override int[] LevelsToPlayTrack { get; set; } = { 2 };

        public VictoryTrack(Song song) : base(song) { }
    }
}
