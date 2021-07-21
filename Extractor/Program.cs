using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Extractor
{
    class Program
    {
        //private static Regex _namesRegex = new Regex(@"[А-Я](\s)*[.,](\s)*[А-Я](\s)*[.,](\s)*[А-Я][а-я]+");
        private static Regex _namesRegex = new Regex(@"([А-ЯA-Z][а-яёa-z]?(\s)*[.,](\s)*)?(([А-ЯA-Z][а-яёa-z]?(\s)*[.,])|фон)(\s)*[А-ЯA-Z][а-яёА-Яa-zA-Z]+");
        private static string sourcesDir = "sources";
        static void Main(string[] args)
        {
            Console.WriteLine("Started names extracting");

            var sources = GetFilesNames(sourcesDir);
            var namesData = new List<NamesData>();
            foreach(var s in sources)
            {
                var text = ReadFile(s);
                var names = ExtractNames(text);
                var nd = new NamesData
                {
                    FileName = s.Split(Path.DirectorySeparatorChar).Last(),
                    Names = names.Distinct()
                };

                namesData.Add(nd);
            }

            WriteNamesToFile("result.txt", namesData);

            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        static IEnumerable<string> ExtractNames(string text)
        {
            return _namesRegex.Matches(text).Select(x => x.ToString());
        }

        static IEnumerable<string> GetFilesNames(string folderName)
        {
            return Directory.GetFiles(folderName);
        }

        static void WriteNamesToFile(string fileName, IEnumerable<NamesData> data)
        {
            var sb = new StringBuilder();
            foreach(var d in data)
            {
                sb.AppendLine("Файл: " + d.FileName);
                sb.AppendLine();
                foreach(var name in d.Names)
                {
                    sb.AppendLine(name);
                }
                sb.AppendLine();
            }

            File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
        }
    }

    public class NamesData
    {
        public string FileName { get; set; }   
        public IEnumerable<string> Names { get; set; }
    }
}
