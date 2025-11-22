using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Artist}";
        }
    }

    public class Playlist
    {
        private List<Song> songs = new List<Song>();
        public void AddSong(Song song)
        {
            songs.Add(song);
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= songs.Count)
            {
                Console.WriteLine("Invalid index.");
                return;
            }
            songs.RemoveAt(index);
        }
        public void MoveUp(int index)
        {
            if (index <= 0 || index >= songs.Count)
            {
                Console.WriteLine("Cannot move up (already at top or invalid index).");
                return;
            }
            var temp = songs[index - 1];
            songs[index - 1] = songs[index];
            songs[index] = temp;
        }
        public void MoveDown(int index)
        {
            if (index < 0 || index >= songs.Count - 1)
            {
                Console.WriteLine("Cannot move down (already at bottom or invalid index).");
                return;
            }
            var temp = songs[index + 1];
            songs[index + 1] = songs[index];
            songs[index] = temp;
        }
        public int FindIndexByTitle(string title)
        {
            return songs.FindIndex(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
        public void MoveUp(string title)
        {
            int index = FindIndexByTitle(title);
            if (index == -1)
            {
                Console.WriteLine("Song not found.");
                return;
            }
            MoveUp(index);
        }
        public void MoveDown(string title)
        {
            int index = FindIndexByTitle(title);
            if (index == -1)
            {
                Console.WriteLine("Song not found.");
                return;
            }
            MoveDown(index);
        }

        public void PrintPlaylist()
        {
            Console.WriteLine("\n=== PLAYLIST ===");
            if (songs.Count == 0)
            {
                Console.WriteLine("No songs in playlist.");
            }
            else
            {
                for (int i = 0; i < songs.Count; i++)
                {
                    Console.WriteLine($"{i}. {songs[i]}");
                }
            }
            Console.WriteLine("================\n");
        }
    }
    internal class Playlists
    {
        static void Main()
        {
            Playlist playlist = new Playlist();
            playlist.AddSong(new Song { Id = 1, Title = "Song A", Artist = "Artist 1" });
            playlist.AddSong(new Song { Id = 2, Title = "Song B", Artist = "Artist 2" });
            playlist.AddSong(new Song { Id = 3, Title = "Song C", Artist = "Artist 3" });
            playlist.AddSong(new Song { Id = 4, Title = "Song D", Artist = "Artist 4" });

            playlist.PrintPlaylist();

            Console.WriteLine("Move 'Song C' up:");
            playlist.MoveUp("Song C");
            playlist.PrintPlaylist();

            Console.WriteLine("Move index 0 down:");
            playlist.MoveDown(0);
            playlist.PrintPlaylist();

            Console.WriteLine("Move 'Song D' down (should fail if at bottom):");
            playlist.MoveDown("Song D");
            playlist.PrintPlaylist();

            Console.WriteLine("Done.");
        }
    }
}
