using System;
using System.IO;
using System.Threading;

namespace ClassEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassRobot robot = new ClassRobot();
            ClassRecord record_ = new ClassRecord();
            Thread myThread = new Thread(new ThreadStart(robot.route));
            myThread.Start();
            robot.onRoute += record_.record;
        }
    }

    class ClassRobot
    {
        public delegate void MethodContainer();

        public event MethodContainer onRoute;
        public void route()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int value = rnd.Next(1, 5);
                switch (value)
                {
                    case 1:
                        {
                            Console.WriteLine("влево");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("вправо");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("вперед");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("назад");
                            onRoute();
                            break;
                        }
                }
                Thread.Sleep(150);
            }
        }
    }
    class ClassRecord
    {
        int i = 0;
        public void record()
        {
            i++;
            if (i > 1)
            {
                using (StreamWriter sw = new StreamWriter(@"D:\C#\ClassEvent\test.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("робот направился назад " + DateTime.Now);
                }
            }
            else 
            {
                using (StreamWriter sw = new StreamWriter(@"D:\C#\ClassEvent\test.txt", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("робот направился назад " + DateTime.Now);
                }
            }
        }
    }
}