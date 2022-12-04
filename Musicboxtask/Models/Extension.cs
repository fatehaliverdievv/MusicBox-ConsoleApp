using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicboxtask.Models
{
     public static class Extension
    {
        public static string ToCapitalize(this string str)
        {
            str = str.Trim();
            string[] strarray = str.Split(' ');
            if (String.IsNullOrEmpty(str))
            {
                throw new Exception("Empty name or artist name");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < strarray.Length; i++)
                {
                    strarray[i] = strarray[i].Trim().ToLower();
                    sb.Append(char.ToUpper(strarray[i][0]) + strarray[i].Substring(1) + " ");
                }
                return sb.ToString();
            }
            throw new Exception("wrong name or wrong artist name");
        }
    }
}
