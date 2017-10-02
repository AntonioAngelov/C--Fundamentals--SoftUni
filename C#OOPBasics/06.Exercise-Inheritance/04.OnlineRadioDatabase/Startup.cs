using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var playlist = new Playlist();

        for (int i = 0; i < n; i++)
        {
            try
            {
                var input = Console.ReadLine()
                .Split(';')
                .ToArray();

                if (input.Length < 3)
                {
                    Console.WriteLine("Invalid song.");
                    continue;
                }

                var length = new List<long>();

                try
                {
                    length = input[2].Split(':').Select(long.Parse).ToList();
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Invalid song length.");
                }

                var song = new Song(input[1], input[0], length[0], length[1]);
                playlist.AddSong(song);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine(playlist);
    }
}

