using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mail
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 51; i++)
            //{
            //string path = $@"D:\ДЗ\mailsender\Новая папка\name + {i}";
            //string text = $"blabla + {i}";
            //using (FileStream fs = File.Create(path))
            //{
            //using (StreamWriter writer = new StreamWriter(fs))
            //{

            //writer.Write(text);
            //Thread.Sleep(6000);
            //Console.WriteLine(i + "   finished");
            //}
            //}

            //}
            // first - 1.52; last 1.59 (7 min)

            //for (int i = 0; i < 51; i++)
            //{
            //string path = $@"D:\ДЗ\mailsender\Новая папка2\ name + {i}";
            //string text = $"blabla + {i}";

            //ThreadPool.QueueUserWorkItem((object state) =>
            //{
            //using (FileStream fs = File.Create(path))
            //{
            //using (StreamWriter writer = new StreamWriter(fs))
            //{

            //writer.Write(text);
            //Thread.Sleep(6000);
            //Console.WriteLine(i + "   finished");
            //}
            //}
            //});

            //}
            // 2.09 ---- 2.13 (4 min)
            object obj = new object();
            for (int i = 0; i < 51; i++)
            {
                string path = $@"D:\ДЗ\mailsender\Новая папка3\ name";
                string text = $"   blabla + {i}\n";

                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    lock (obj)
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(fs))
                            {
                                writer.Write(text);
                                Console.WriteLine(i + "   finished");
                            }
                        }
                    }
                });

            }





            Console.WriteLine("END");
            Console.ReadLine();
        } 
    }
}
