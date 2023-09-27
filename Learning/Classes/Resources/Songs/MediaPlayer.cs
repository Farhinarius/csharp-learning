using System;

namespace Learning.Classes.Resources.Songs;

public class MediaPlayer
{
    public void Play() { /* play composition */ }
    public void Pause() { /* pause playing */ }
    public void Stop() { /* stop playing */ }

    public Lazy<Song[]> AllSongs { get; } = new(() => new Song[10_000]);

}