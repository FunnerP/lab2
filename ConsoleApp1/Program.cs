using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            Task[] tasks = new Task[26];
            for (int i = 0; i < 26; i++)
            {
                char letter = (char)('a' + i);
                tasks[i] = Task.Run(() =>
                {
                    lock (result)
                    {
                        result.Append(letter);
                    }
                });
            }

            Task.WaitAll(tasks);

            Console.WriteLine(result.ToString());
        }
    }
