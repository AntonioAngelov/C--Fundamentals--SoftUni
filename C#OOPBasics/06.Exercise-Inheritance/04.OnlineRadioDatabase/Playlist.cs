using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Playlist
{
    private List<Song> songs;

    public Playlist()
    {
        this.songs = new List<Song>();
    }

    public IReadOnlyCollection<Song> Songs
    {
        get
        {
            return this.songs.AsReadOnly(); 
            
        }
    }

    public void AddSong(Song song)
    {
        this.songs.Add(song);
        Console.WriteLine("Song added.");
    }

    public override string ToString()
    {
        long secs = songs.Sum(s => s.Seconds);
        long mins = songs.Sum(s => s.Minutes);

        mins += secs / 60;
        secs = secs % 60;

        long hours = mins / 60;
        mins = mins % 60;

        StringBuilder result = new StringBuilder();
        result.Append($"Songs added: {this.Songs.Count}\n")
            .Append($"Playlist length: {hours}h {mins}m {secs}s");

        return result.ToString();
    }
}
