using System;
using System.Collections;

class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }

    public Song(string title, string artist)
    {
        Title = title;
        Artist = artist;
    }

    public override string ToString()
    {
        return $"{Title} by {Artist}";
    }
}

class MusicDisc
{
    public string Name { get; set; }
    public ArrayList Songs { get; private set; }

    public MusicDisc(string name)
    {
        Name = name;
        Songs = new ArrayList();
    }

    public void AddSong(Song song)
    {
        Songs.Add(song);
    }

    public void RemoveSong(string title)
    {
        foreach (Song s in Songs)
        {
            if (s.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                Songs.Remove(s);
                Console.WriteLine($"Song '{title}' removed.");
                return;
            }
        }
        Console.WriteLine($"Song '{title}' not found.");
    }

    public void DisplaySongs()
    {
        Console.WriteLine($"Disc: {Name}");
        foreach (Song song in Songs)
        {
            Console.WriteLine($" - {song}");
        }
    }
}

class MusicCatalog
{
    private Hashtable catalog = new Hashtable();

    public void AddDisc(string discName)
    {
        if (!catalog.ContainsKey(discName))
        {
            catalog[discName] = new MusicDisc(discName);
            Console.WriteLine($"Disc '{discName}' added.");
        }
        else
        {
            Console.WriteLine("Disc already exists.");
        }
    }

    public void RemoveDisc(string discName)
    {
        if (catalog.ContainsKey(discName))
        {
            catalog.Remove(discName);
            Console.WriteLine($"Disc '{discName}' removed.");
        }
        else
        {
            Console.WriteLine("Disc not found.");
        }
    }

    public void AddSongToDisc(string discName, Song song)
    {
        if (catalog.ContainsKey(discName))
        {
            ((MusicDisc)catalog[discName]).AddSong(song);
            Console.WriteLine($"Song '{song.Title}' added to disc '{discName}'.");
        }
        else
        {
            Console.WriteLine("Disc not found.");
        }
    }

    public void RemoveSongFromDisc(string discName, string songTitle)
    {
        if (catalog.ContainsKey(discName))
        {
            ((MusicDisc)catalog[discName]).RemoveSong(songTitle);
        }
        else
        {
            Console.WriteLine("Disc not found.");
        }
    }

    public void DisplayCatalog()
    {
        foreach (DictionaryEntry entry in catalog)
        {
            ((MusicDisc)entry.Value).DisplaySongs();
        }
    }

    public void DisplayDisc(string discName)
    {
        if (catalog.ContainsKey(discName))
        {
            ((MusicDisc)catalog[discName]).DisplaySongs();
        }
        else
        {
            Console.WriteLine("Disc not found.");
        }
    }

    public void SearchByArtist(string artist)
    {
        Console.WriteLine($"Searching for songs by '{artist}':");
        foreach (DictionaryEntry entry in catalog)
        {
            MusicDisc disc = (MusicDisc)entry.Value;
            foreach (Song song in disc.Songs)
            {
                if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($" - {song} (Disc: {disc.Name})");
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        MusicCatalog catalog = new MusicCatalog();

        while (true)
        {
            Console.WriteLine("\n--- Music Catalog Menu ---");
            Console.WriteLine("1. Add Disc");
            Console.WriteLine("2. Remove Disc");
            Console.WriteLine("3. Add Song");
            Console.WriteLine("4. Remove Song");
            Console.WriteLine("5. Show All Discs");
            Console.WriteLine("6. Show One Disc");
            Console.WriteLine("7. Search by Artist");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter disc name: ");
                    string addDiscName = Console.ReadLine();
                    catalog.AddDisc(addDiscName);
                    break;

                case "2":
                    Console.Write("Enter disc name: ");
                    string removeDiscName = Console.ReadLine();
                    catalog.RemoveDisc(removeDiscName);
                    break;

                case "3":
                    Console.Write("Enter disc name: ");
                    string discNameForSong = Console.ReadLine();
                    Console.Write("Enter song title: ");
                    string songTitle = Console.ReadLine();
                    Console.Write("Enter artist name: ");
                    string artist = Console.ReadLine();
                    catalog.AddSongToDisc(discNameForSong, new Song(songTitle, artist));
                    break;

                case "4":
                    Console.Write("Enter disc name: ");
                    string discNameRemove = Console.ReadLine();
                    Console.Write("Enter song title to remove: ");
                    string songToRemove = Console.ReadLine();
                    catalog.RemoveSongFromDisc(discNameRemove, songToRemove);
                    break;

                case "5":
                    catalog.DisplayCatalog();
                    break;

                case "6":
                    Console.Write("Enter disc name: ");
                    string oneDisc = Console.ReadLine();
                    catalog.DisplayDisc(oneDisc);
                    break;

                case "7":
                    Console.Write("Enter artist name to search: ");
                    string searchArtist = Console.ReadLine();
                    catalog.SearchByArtist(searchArtist);
                    break;

                case "0":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
