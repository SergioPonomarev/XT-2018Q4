using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Task4.WordFrequency
{
    internal class Program
    {
        private const char SepCharOne = ' ';
        private const char SepCharTwo = '.';
        private const char CharToSkip = '\'';
        private static readonly string DefaultText = @"'You've got to find what you love,' Jobs says 
                    This is the text of the Commencement address by Steve Jobs, CEO of Apple Computer and of Pixar Animation Studios, delivered on June 12, 2005.

                    Thank you!
                    I am honored to be with you today at your commencement from one of the finest universities in the world. I never graduated from college.Truth be told, this is the closest I've ever gotten to a college graduation. Today I want to tell you three stories from my life. That's it. No big deal.Just three stories.

                    The first story is about connecting the dots. 

                    I dropped out of Reed College after the first 6 months, but then stayed around as a drop -in for another 18 months or so before I really quit.So why did I drop out? 

                    It started before I was born.My biological mother was a young, unwed college graduate student, and she decided to put me up for adoption.She felt very strongly that I should be adopted by college graduates, so everything was all set for me to be adopted at birth by a lawyer and his wife.Except that when I popped out they decided at the last minute that they really wanted a girl.So my parents, who were on a waiting list, got a call in the middle of the night asking: 'We have an unexpected baby boy; do you want him?' They said: 'Of course.' My biological mother later found out that my mother had never graduated from college and that my father had never graduated from high school.She refused to sign the final adoption papers.She only relented a few months later when my parents promised that I would someday go to college.

                    And 17 years later I did go to college. But I naively chose a college that was almost as expensive as Stanford, and all of my working-class parents' savings were being spent on my college tuition. After six months, I couldn't see the value in it. I had no idea what I wanted to do with my life and no idea how college was going to help me figure it out. And here I was spending all of the money my parents had saved their entire life. So I decided to drop out and trust that it would all work out OK. It was pretty scary at the time, but looking back it was one of the best decisions I ever made. The minute I dropped out I could stop taking the required classes that didn't interest me, and begin dropping in on the ones that looked interesting. 

                    It wasn't all romantic. I didn't have a dorm room, so I slept on the floor in friends' rooms, I returned coke bottles for the 5¢ deposits to buy food with, and I would walk the 7 miles across town every Sunday night to get one good meal a week at the Hare Krishna temple. I loved it. And much of what I stumbled into by following my curiosity and intuition turned out to be priceless later on. Let me give you one example: 

                    Reed College at that time offered perhaps the best calligraphy instruction in the country. Throughout the campus every poster, every label on every drawer, was beautifully hand calligraphed. Because I had dropped out and didn't have to take the normal classes, I decided to take a calligraphy class to learn how to do this. I learned about serif and san serif typefaces, about varying the amount of space between different letter combinations, about what makes great typography great. It was beautiful, historical, artistically subtle in a way that science can't capture, and I found it fascinating. 

                    None of this had even a hope of any practical application in my life. But ten years later, when we were designing the first Macintosh computer, it all came back to me. And we designed it all into the Mac.";

        private static void Main()
        {
            Console.WriteLine("Greetings! You are using The Word Frequency Program.");
            Console.WriteLine();

            bool check = false;
            string text = null;

            while (!check)
            {
                Console.Write("Please, type some text to count word frequency or click Enter to use default text: ");

                text = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrEmpty(text))
                {
                    text = DefaultText;
                    check = true;
                }
                else if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Text mustn't contain only white spaces.");
                    Console.WriteLine();
                }
                else
                {
                    check = true;
                }
            }

            Dictionary<string, int> resultCollection = WordsCounter(text);

            Console.WriteLine("Words have been counted:");
            Console.WriteLine();

            ConsolePrintResult(resultCollection);
        }

        private static Dictionary<string, int> WordsCounter(string text)
        {
            string textToProcess = RemovingTrashProcessor(text);

            string[] words = textToProcess.Split(new char[] { SepCharOne, SepCharTwo }, StringSplitOptions.RemoveEmptyEntries);
            
            Array.Sort(words);

            SortedSet<string> hs = new SortedSet<string>(words);

            string[] uniqueWords = new string[hs.Count];

            hs.CopyTo(uniqueWords);

            Dictionary<string, int> resultCollection = new Dictionary<string, int>(uniqueWords.Length);

            int count;
            int i = 0;
            int j = 0;

            while (i < uniqueWords.Length)
            {
                count = 0;

                if (uniqueWords[i] == words[j])
                {
                    while (j < words.Length && uniqueWords[i] == words[j])
                    {
                        count++;
                        j++;
                    }
                }

                resultCollection.Add(uniqueWords[i], count);

                i++;
            }

            return resultCollection;
        }

        private static void ConsolePrintResult<T1, T2>(IDictionary<T1, T2> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"Word '{item.Key.ToString()}' is found {item.Value.ToString()} in the text.");
            }
        }

        private static string RemovingTrashProcessor(string text)
        {
            StringBuilder sb = new StringBuilder(text);

            for (int i = 0; i < sb.Length; i++)
            {
                if (i != 0)
                {
                    if (sb[i] == CharToSkip &&
                        char.IsLetter(sb[i - 1]) &&
                        char.IsLetter(sb[i + 1]))
                    {
                        continue;
                    }
                }

                if (char.IsControl(sb[i]))
                {
                    sb.Replace(sb[i], SepCharOne, i, 1);
                }

                if (!char.IsLetter(sb[i]) && !char.IsWhiteSpace(sb[i]))
                {
                    sb.Replace(sb[i], SepCharOne, i, 1);
                }
            }

            return sb.ToString().ToLower();
        }
    }
}
