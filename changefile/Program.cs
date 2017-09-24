using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace changefile
{
    class Program
    {
        static string[] lines;
        static void Main(string[] args)
        {
            int a3 = 0;
            int th1start = 0;
            int th1stop = 0;
            int th2start = 0;
            int th2stop = 0;
            int th3start = 0;
            int th3stop = 0;
            string actiontype;
            int actiontypeint = 0;
            int fileisopen = 0;


            Console.WriteLine("ChangeTextFormate");
            Console.WriteLine(" To open file, press 1");
            Console.WriteLine(" To make text processing, press 2");
            Console.WriteLine(" To save file, press 3");
            Console.WriteLine(" To exit, press 4");
            
            var sw = new Stopwatch();
            long elapsedMilliseconds = 0;



            for (;;)
            {
                Console.WriteLine("put your number");
                actiontype = Console.ReadLine();
                actiontypeint = Convert.ToInt32(actiontype);
                switch (actiontypeint)
                {
                    case 1:
                        if (fileisopen == 0)
                        {
                            lines = File.ReadAllLines(@"E:\igor_work\C_sharp_advanced\Lesson1\changefile\doc.txt", Encoding.UTF8);
                            fileisopen = 1;    // file is open now
                            int length = (int)lines.Length;
                            a3 = length / 3;   // divide array to 3
                            th1stop = a3;
                            th2start = th1stop + 1;
                            th2stop = th2start + a3;
                            th3start = th2stop + 1;
                            th3stop = length - 1;
                            Console.WriteLine("File is open");
                        }
                        else { Console.WriteLine("File is ALREADY open"); break; }
                       
                        break;

                    case 2:
                        if (elapsedMilliseconds == 0)
                        {
                            //*******************************************************************
                            sw.Start();
                            RangeLimit rangefirsttreade = new RangeLimit();
                            rangefirsttreade.Start = th1start;
                            rangefirsttreade.Stop = th1stop;

                            RangeLimit rangesecondtreade = new RangeLimit();
                            rangesecondtreade.Start = th2start;
                            rangesecondtreade.Stop = th2stop;

                            RangeLimit rangthirdtreade = new RangeLimit();
                            rangthirdtreade.Start = th3start;
                            rangthirdtreade.Stop = th3stop;

                            //*********************************************************************

                            Thread myThread1 = new Thread(TextHandling);
                            myThread1.Name = "myThread1";
                            Thread myThread2 = new Thread(TextHandling);
                            myThread2.Name = "myThread2";
                            Thread myThread3 = new Thread(TextHandling);
                            myThread3.Name = "myThread3";

                            myThread1.Start(rangefirsttreade);
                            myThread2.Start(rangesecondtreade);
                            myThread3.Start(rangthirdtreade);



                            myThread1.Join();
                            myThread2.Join();
                            myThread3.Join();
                            Console.WriteLine("Text processing has been finished");
                            elapsedMilliseconds = sw.ElapsedMilliseconds;
                            sw.Stop();
                            Console.WriteLine("Time execution" + elapsedMilliseconds);
                        }
                        else
                        {
                            Console.WriteLine("File is already EXECUTED"); break;
                        }
                        break;

                    case 3:
                        File.WriteAllLines(@"E:\igor_work\C_sharp_advanced\Lesson1\changefile\doc1changed.txt", lines);
                        Console.WriteLine("File saved");
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                }
            }         
        }

        static void TextHandling(object obj)
        {
            var param = (RangeLimit)obj;

            WorkWithText.DoJob(ref lines, param.Start, param.Stop);
        }

        public class RangeLimit
        {
            //private int _start;

            //public int Start { get { return _start == 0 ? -1 : _start; } set { _start = value; } }
            public int Start { get; set; }
            public int Stop { get; set; }

            //public int GetStart()
            //{
            //    return _start;
            //}

            //public void SetStart(int val)
            //{
            //    _start = val;
            //}
        }



    }
}
