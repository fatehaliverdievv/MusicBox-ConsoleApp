using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicboxtask.Models
{
    public  class Music
    {
        static int Count;
        int _id;
        string _name;
        string _artistName;
        int _time;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value > 0)
                {
                    _id = Count;
                    Count++;
                }
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                    _name = value;
            }
        }
        public string ArtistName
        {
            get
            {
                return _artistName;
            }
            set
            {
                _artistName = value;
            }
        }
        public int Time
        {
            get { return _time; }
            set
            {
                if (value > 0) { _time = value; }
                else { throw new Exception("Mahninin saniyesi menfi ve ya 0 ola bilmez"); }
            }
        }
        static Music()
        {
            Count++;
        }
        public Music(string name, string artistname, int time)
        {
            Id++;
            Name = name.ToCapitalize() ;
            ArtistName = artistname.ToCapitalize();
            Time= time;
        }
    }
}
