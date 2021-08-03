using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextsProc.LIba.Parsing.DumbStaff;

namespace Extractor
{
    class Program
    {
        private static string sourcesDir = "sources";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var sources = GetFilesNames(sourcesDir);
            var namesData = new List<NamesData>();

            Console.WriteLine("Выбрать тип парсинга: 1. ФИО 2. Контекст целевой лексемы");
            var key = Console.ReadLine();
            switch ((ExtractionOperations)int.Parse(key.ToString()))
            {
                case ExtractionOperations.FullNames:
                    foreach (var s in sources)
                    {
                        var text = ReadFile(s);
                        var names = ExtractNames(text);
                        var nd = new NamesData
                        {
                            FileName = s.Split(Path.DirectorySeparatorChar).Last(),
                            Words = names.Distinct()
                        };

                        namesData.Add(nd);
                        WriteDataToFile("fio_result.txt", namesData);
                    }

                    break;
                case ExtractionOperations.ContextWords:
                    var naiveWordsContextGetter = new NaiveWordsContextGetter();
                    Console.WriteLine("Введите целевую лексему");
                    var mainWord = Console.ReadLine();
                    Console.WriteLine("Введите длину контекста (n слов вправо и влево)");
                    var n = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите минимальную длину искомых лексем контекста");
                    var wordMinLength = int.Parse(Console.ReadLine());

                    foreach (var s in sources)
                    {
                        var text = ReadFile(s);
                        var words = naiveWordsContextGetter.GetWords(text, mainWord, n, 
                            w => w.Length >= wordMinLength);
                        var nd = new NamesData
                        {
                            FileName = s.Split(Path.DirectorySeparatorChar).Last(),
                            Words = words.Distinct()
                        };

                        namesData.Add(nd);
                        WriteDataToFile("words_context_result.txt", namesData);
                    }
                    break;
                default:
                    Console.WriteLine("Операция не поддерживается");
                    throw new InvalidOperationException();
            }

            Console.WriteLine("Готово...");
            Console.ReadKey();
        }

        static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        static IEnumerable<string> ExtractNames(string text)
        {
            return new NaiveNamesExtractor().GetNames(text);
        }

        static IEnumerable<string> GetFilesNames(string folderName)
        {
            return Directory.GetFiles(folderName);
        }

        static void WriteDataToFile(string fileName, IEnumerable<NamesData> data)
        {
            var sb = new StringBuilder();
            foreach(var d in data)
            {
                sb.AppendLine("Файл: " + d.FileName);
                sb.AppendLine();
                foreach(var name in d.Words)
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
        public IEnumerable<string> Words { get; set; }
    }

    enum ExtractionOperations
    {
        FullNames = 1,
        ContextWords = 2
    }

}
