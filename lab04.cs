using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace lab_04_my_
{
    class Program
    {
        static void Main(string[] args)
        {
            string MaxLength = "";

            Console.WriteLine("Введите любое предложение:");
            string text = Console.ReadLine();
            Console.WriteLine("                                     ");
            Console.WriteLine("Количество знаков препинания:"); kolvoznak(text);
            Console.WriteLine("                                     ");
            Console.WriteLine("Разделить на предложения:"); razdelenienapredlozheniya(text);
            Console.WriteLine("                                     ");
            Console.WriteLine("Самое длинное слово из текста:"); TheLongestWord(text, ref MaxLength);
            Console.WriteLine("                                     ");
            Console.WriteLine("Уникальные слова в тексте:"); UniqueWords(text);
            Console.WriteLine("                                     ");
            Console.WriteLine("Замена или представление второй части слова:"); Replacement(text, MaxLength);
        static void  kolvoznak(string text)
        {
            var counter = 0;
            char[] simw = new char[] { '.', ',', ':', ';', '"', ')', '(', '?', '!', '-' };
            foreach (char e in text)
            {
                if (simw.Contains(e))
                    counter++;
                
            }
            Console.WriteLine(counter);
        }
        static void razdelenienapredlozheniya(string text)
        {
            string[] predl = text.Split(new char[] { '.', '?', '!'});
            foreach(string e in predl)
            {
                Console.WriteLine(e.Trim());

            }
        }
        static void TheLongestWord(string text, ref string MaxLength)
        {
            
            string[] words = text.Split(' ', '.', ',', '?', '!', ':', ';', '-', '"', '(', ')');
            for(int i = 0; i < words.Length; i++)
            {
                if(words[i].Length > MaxLength.Length)
                {
                    MaxLength = words[i];
                }
                
            }
            Console.WriteLine(MaxLength);


        }
        static void UniqueWords(string text)
        {
            string[] words = text.Split(' ', '.', ',', '?', '!', ':', ';', '-', '"', '(', ')');
            List<string> uniqueWords = new List<string>();
            foreach (string unique in words)
            {
                if (!uniqueWords.Contains(unique))
                    uniqueWords.Add(unique);
                Console.Write($"{unique}, "+ unique);
                    
            }
                Console.WriteLine("");
        }
        static void Replacement(string text, string MaxLength)
            {

                if (MaxLength.Length % 2 == 0)
                {
                    for (int i = MaxLength.Length/2 - 1; i < MaxLength.Length; i++)
                        Console.Write(MaxLength[i]);
                    Console.WriteLine("");
                }
                else if (MaxLength.Length!=0)
                {
                    int centID = MaxLength.Length / 2;

                    for (int i = 0; i < MaxLength.Length; i++)
                    {
                        if (i == centID)
                            Console.Write("*");
                        else
                            Console.Write(MaxLength[i]);
                        
                    }
                    Console.WriteLine("");    
                }

            }
        }
    }
}
