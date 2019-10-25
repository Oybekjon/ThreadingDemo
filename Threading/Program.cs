using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Linq;

namespace Threading
{

    class Program
    {

        public static string Shit { get; set; }
        static void Main(string[] args)
        {
            var t = new Thread(Async);
            t.Start();

            Console.ReadLine();
            t.Abort();
            Console.WriteLine("Aborted");
            Console.ReadLine();
        }

        private static void Async()
        {
            try
            {
                var random = new Random();
                var total = 0L;
                var count = 0L;
                var max = 0;
                for (var i = 0L; i < 10000000; i++)
                {
                    total += random.Next(4) == 1 ? 1 : 0;
                    count++;
                    var avg = total / (double)count;
                    var avgText = avg.ToString();
                    max = Math.Max(avgText.Length, max);
                    avgText = avgText.PadRight(max + 1);
                    Console.Write($"\r{avgText} - {i}");
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Thread aborted");
            }
        }

        private static void Container()
        {
            var container = new ParallelContainer<string>();
            var result = container.RunParallely(new List<Func<string>> {
                DoFacebook,
                DoYoutube,
                DoSlutstagram,
                DoTwitter
            });

            Console.WriteLine($"List has {result.Count} elements");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void Threads()
        {
            var countdown = new CountdownEvent(4);

            var list = new List<string>();

            var twThread = new Thread(() =>
            {
                list.Add(DoTwitter());
                countdown.Signal();
            });

            var fbThread = new Thread(() =>
            {
                list.Add(DoFacebook());
                countdown.Signal();

            });


            var ytThread = new Thread(() =>
            {
                list.Add(DoYoutube());
                countdown.Signal();

            });

            var slThread = new Thread(() =>
            {
                list.Add(DoSlutstagram());
                countdown.Signal();
            });

            twThread.Start();
            fbThread.Start();
            ytThread.Start();
            slThread.Start();

            countdown.Wait();
            // Wait here

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }


        static string DoTwitter()
        {
            Thread.Sleep(new Random().Next(2000, 4000));
            Console.WriteLine("Twitter complete");
            return "Twitter post";
        }
        static string DoFacebook()
        {
            Thread.Sleep(new Random().Next(2000, 4000));
            Console.WriteLine("Fb complete");
            return "Facebook post";
        }

        static string DoYoutube()
        {
            Thread.Sleep(new Random().Next(2000, 4000));
            Console.WriteLine("YT complete");
            return "Youtube post";
        }

        static string DoSlutstagram()
        {
            Thread.Sleep(new Random().Next(2000, 4000));
            Console.WriteLine("SS complete");
            return "Slut post";
        }
    }
}
