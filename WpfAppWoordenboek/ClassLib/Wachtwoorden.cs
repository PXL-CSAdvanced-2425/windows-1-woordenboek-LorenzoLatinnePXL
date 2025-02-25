using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public static class Wachtwoorden
    {
        private static Dictionary<string, string> _dictionary = new Dictionary<string, string>();


        public static Dictionary<string, string> Dictionary { get
            {
                return _dictionary;
            }
        }


        public static void AddWord(string englishWord, string dutchWord)
        {
            Dictionary.Add(englishWord, dutchWord);
        }

        public static void DeleteWord(string key)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary.Remove(key);
            }
        }
    }
}
