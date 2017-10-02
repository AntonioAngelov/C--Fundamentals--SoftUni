using System;

public class Song
{
    private string songName;
    public string artistName { get; set; }
    private long seconds;
    private long minutes;

    public Song(string songName, string artistName, long mins, long secs)
    {
        this.SongName = songName;
        this.ArtistName = artistName;
        this.Minutes = mins;
        this.Seconds = secs;
    }

    public long Minutes
    {
        get { return minutes; }
        private set
        {
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            this.minutes = value;
        }
    }


    public long Seconds
    {
        get { return this.seconds; }
        private set
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            this.seconds = value;
        }
    }


    public string SongName
    {
        get { return this.songName; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            this.songName = value;
        }
    }

    public string ArtistName
    {
        get { return this.artistName; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }

            this.artistName = value;
        }
    }

}

