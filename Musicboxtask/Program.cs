using Musicboxtask.Exceptions;
using Musicboxtask.Models;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Musicboxtask
{
    public class Program
    {
        static void Main(string[] args)
        {
            Playlist playList = new Playlist();
            bool end = true;
            bool onmusic = false;
            int startmusictime=0;
            int endmusictime=0;
            while (end)
            {
                Console.WriteLine("1.Mahni yarat \n2.Playlistdeki mahnilara bax \n3.Playliste mahni elave et \n4.Mahni qosh \n5.Menyudan cix ");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("Mahninin adini , ifacinin adini ve nece saniye oldugunu daxil edin :");
                            Music music = new Music(Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                            AllMusic.Add(music);
                            Console.WriteLine("Mahni elave etmeye davam etmek isteyirsiniz ? (He ve ya Yox)");
                        Wrongaddcommand:
                            string result = Console.ReadLine();
                            result = result.ToLower().Trim();
                            if (result == "he")
                            {
                                goto case 1;
                            }
                            else if (result == "yox")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Duzgun command daxil edin!!");
                                goto Wrongaddcommand;
                            }
                        }
                        break;
                    case 2:
                        playList.ShowPlaylist();
                        if (playList.playlist.Count == 0)
                        {
                        PlaylistAdd:
                            Console.WriteLine("Playlistinize mahni elave etmek isteyirsiniz?(He va ya yox)");
                            string addingplaylistmusic = Console.ReadLine();
                            addingplaylistmusic = addingplaylistmusic.ToLower().Trim();
                            if (addingplaylistmusic == "he")
                            {
                                goto case 3;
                            }
                            else if (addingplaylistmusic == "yox")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Yanlis command daxil etdiniz !!");
                                goto PlaylistAdd;
                            }
                        }
                        break;
                    case 3:
                        if (AllMusic.Count == 0)
                        {
                            Console.WriteLine("Playlistinize mahni elave etmek ucun ilk once mahni yaratmalisiniz. Mahni yaratmaq isteyirsiniz?(He ya da yox)");
                            string NewMusicCreate = Console.ReadLine();
                            NewMusicCreate = NewMusicCreate.ToLower().Trim();
                            if (NewMusicCreate == "he")
                            {
                                goto case 1;
                            }
                            else if (NewMusicCreate == "yox")
                            {
                                Console.WriteLine("Hec bir musiqi elave edilmedi");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Duzgun command daxil edin !!");
                                goto case 3;
                            }
                        }
                        Console.WriteLine("Butun mahnilariniz : ");
                        for (int i = 0; i < AllMusic.Count; i++)
                        {
                            Console.WriteLine(AllMusic[i].Id + ". " + AllMusic[i].Name + "- " + AllMusic[i].ArtistName);
                        }
                    AddMusicId:
                        Console.WriteLine("Hansi mahnini playlistinize elave etmek isteyirsinizse sirasini daxil edin :");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < AllMusic.Count; i++)
                        {
                            if (answer < 0 && answer > AllMusic.Count)
                            {
                                Console.WriteLine("Yanlis sira daxil elediniz  tekrar cehd edin");
                                goto AddMusicId;
                            }
                            else if (answer == AllMusic[i].Id)
                            {
                                playList.AddMusic(AllMusic[i]);
                            AddingMusicCommand:
                                Console.WriteLine("Bashqa mahni elave etmek isteyirsiniz? (He ve ya Yox)");
                                string AddingMusic = Console.ReadLine();
                                AddingMusic = AddingMusic.ToLower().Trim();
                                if (AddingMusic == "he")
                                {
                                    goto AddMusicId;
                                }
                                else if (AddingMusic == "yox")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Duzgun command daxil edin !!");
                                    goto AddingMusicCommand;
                                }
                            }
                        }
                        break;
                    case 4:
                        if (playList.playlist.Count == 0)
                        {
                            Console.WriteLine("Mahni qoshulmadi");
                            goto case 2;
                        }
                        playList.ShowPlaylist();
                    SelectIdForPlay:
                        Console.WriteLine("Hansi musiqini dinlemek isteyirsinizse sirasini secin!");
                        int SelectedMusicId = Convert.ToInt32(Console.ReadLine());

                        if (SelectedMusicId <= 0 && playList.playlist.Count < SelectedMusicId)
                        {
                            Console.WriteLine("Yanlis sira sayi daxil etdiniz . Yeniden cehd edin");
                            goto SelectIdForPlay;
                        }
                        else
                        {
                            if (onmusic==true && DateTime.Now.Second<endmusictime)
                            {
                                Console.WriteLine("Mahnini deyishmek isteyirsiniz?(He ve ya Yox)");
                                string str = Console.ReadLine();
                                str = str.ToLower().Trim();
                                if (str == "he")
                                {
                                    for (int i = 0; i < playList.playlist.Count; i++)
                                    {
                                        if (playList.playlist[i].Id == SelectedMusicId)
                                        {
                                            playList.Play(playList.playlist[i]);
                                            onmusic = true;
                                            startmusictime = DateTime.Now.Second;
                                            endmusictime = startmusictime + playList.playlist[i].Time;
                                        }
                                    }
                                }
                                else if (str == "yox")
                                {
                                    Console.WriteLine("Mahni deyishmedi");
                                }
                                else
                                {
                                    throw new WrongCommandException("Yanlis command daxil etdiniz!!");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < playList.playlist.Count; i++)
                                {
                                    if (playList.playlist[i].Id == SelectedMusicId)
                                    {
                                        playList.Play(playList.playlist[i]);
                                        onmusic = true;
                                        startmusictime = DateTime.Now.Second;
                                        endmusictime = startmusictime + playList.playlist[i].Time;
                                    }
                                }
                            }
                        }
                        break;
                    case 5:
                        end = false;
                        break;
                    default:
                        Console.WriteLine("Duzgun command daxil ele !!");
                        break;
                }
            }
        }
        public static List<Music> AllMusic { get; set; } = new List<Music>();
    }
}