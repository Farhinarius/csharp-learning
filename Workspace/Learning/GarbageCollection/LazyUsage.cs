using Workspace.Learning.Classes.Resources.Songs;

namespace Workspace.Learning.GarbageCollection;

public class LazyUsage
{
    public static void UseLazyCollections()
    {
        MediaPlayer md = new MediaPlayer();
        md.Play();

        // Размещение объекта AllTracks происходит
        // только в случае вызова метода GetAllTracks().
        MediaPlayer yourPlayer = new MediaPlayer();
        Song[] yourMusic = yourPlayer.AllSongs.Value;
    }
}