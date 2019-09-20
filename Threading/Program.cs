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
            var list = new List<string>();
            new List<Func<string>> {
                DoFacebook,
                DoYoutube,
                DoSlutstagram,
                DoTwitter
            }.AsParallel().ForAll(x => list.Add(x()));

            Console.ReadLine();
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
