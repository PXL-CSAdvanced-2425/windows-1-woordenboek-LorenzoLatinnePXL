using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLib
{
    public static class WoordenboekData
    {
        private static Dictionary<string, string> _dictionary = new Dictionary<string, string>();


        public static Dictionary<string, string> Dictionary { get
            {
                return _dictionary;
            }
        }

        static WoordenboekData()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = "ICTWoordenboek.txt";
            string path = System.IO.Path.Combine(basePath, relativePath);

            string[] content = File.ReadAllLines(path);

            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Contains("|"))
                {
                    content[i] = content[i].Replace("|", " - ");
                    string englishWord = content[i].Substring(0, content[i].IndexOf(" -"));
                    string dutchWord = content[i].Substring(content[i].LastIndexOf("- ") + 2);
                    WoordenboekData.AddWord(englishWord, dutchWord);
                }
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
