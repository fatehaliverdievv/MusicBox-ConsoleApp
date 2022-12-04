using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Musicboxtask.Models
{
    public class Playlist
    {
        public List<Music> playlist;
        public Playlist()
        {
            playlist = new List<Music>();
        }
        public void AddMusic(Music music)
        {
            if(playlist.Count == 0)
            {
                playlist.Add(music);
            }
            else
            {
                if (playlist.Contains(music))
                {
                    Console.WriteLine(music.Name + " elave olunmadi. Sizin artiq playlistinizde var");
                }
                else
                {
                    playlist.Add(music);
                }
            }
        }
        public void ShowPlaylist()
        {
            if (playlist.Count == 0)
            {
                Console.WriteLine("Playlistiniz boshdur. \n");
            }
            for (int i = 0; i < playlist.Count; i++)
            {
                Console.WriteLine(playlist[i].Id +"."+ playlist[i].ArtistName + " - " + playlist[i].Name);
            }
        }
        public void Play(Music music)
        {
            if(playlist.Contains(music))
            {
                Console.WriteLine(music.Name + "-" + music.ArtistName + " ifa edilir"); 
            }
            else
            {
                Console.WriteLine("Playlistde bele bir mahni yoxdu");
            }
        }
    }
}
