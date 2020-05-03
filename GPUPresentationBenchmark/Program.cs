using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Diagnostics;

namespace GPUPresentationBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> timer = new List<int>();
            string inputname = "starter.png";
            string outputname = "output_cpu_0.png";
            string device = "cpu";
            string argumentString = " -i " + inputname + " -o " + outputname + " -p " + device + " -t 0 -s 2 -n 1 -m noise_scale";
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("CPU vs GPU Machine Learning Benchmark");
            Console.WriteLine("Prepared by Rashik Chauhan");
            Console.WriteLine("Press any key to start");
            Console.WriteLine("-------------------------------------------");
            Console.ReadLine();
            Console.WriteLine("Starting 5 iteration CPU test.");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Pass #" + (i + 1).ToString() + " Starting...");
                if (i==0)
                {
                    inputname = "starter.png";
                }
                else
                {
                    inputname = outputname;
                }
                Image img = Image.FromFile(inputname);
                Console.WriteLine("Pass #" + (i + 1).ToString() + " Loaded image named: " + inputname+ ". Dimensions: " + img.Width + "x" + img.Height);
                outputname = "output_" + device + "_" + i.ToString() + ".png";
                argumentString = " -i " + inputname + " -o " + outputname + " -p " + device + " -t 0 -s 2 -n 1 -m noise_scale";
                ProcessStartInfo waifu2x = new ProcessStartInfo("C:\\waifu2x\\waifu2x-converterv2\\waifu2x.exe", @argumentString);
                waifu2x.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                int start = Environment.TickCount;
                Process waifu2x2 = Process.Start(waifu2x);
                waifu2x2.WaitForExit();
                int stop = Environment.TickCount;
                timer.Add(stop - start);
                Console.WriteLine("Pass #" + (i + 1).ToString() + " Finished in " + (stop - start).ToString() + " ticks.");
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("CPU Benchmark Done, Average Time: " + timer.Average().ToString());
            Console.WriteLine("Starting GPU Benchmark");
            Console.WriteLine("-------------------------------------------");
            device = "gpu";
            timer = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Pass #" + (i + 1).ToString() + " Starting...");
                if (i == 0)
                {
                    inputname = "starter.png";
                }
                else
                {
                    inputname = outputname;
                }
                Image img = Image.FromFile(inputname);
                Console.WriteLine("Pass #" + (i + 1).ToString() + " Loaded image named: " + inputname + ". Dimensions: " + img.Width + "x" + img.Height);
                outputname = "output_" + device + "_" + i.ToString() + ".png";
                argumentString = " -i " + inputname + " -o " + outputname + " -p " + device + " -t 0 -s 2 -n 1 -m noise_scale";
                ProcessStartInfo waifu2x = new ProcessStartInfo("C:\\waifu2x\\waifu2x-converterv2\\waifu2x.exe", @argumentString);
                waifu2x.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                int start = Environment.TickCount;
                Process waifu2x2 = Process.Start(waifu2x);
                waifu2x2.WaitForExit();
                int stop = Environment.TickCount;
                timer.Add(stop - start);
                Console.WriteLine("Pass #" + (i + 1).ToString() + " Finished in " + (stop - start).ToString() + " ticks.");
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("GPU Benchmark Done, Average Time: " + timer.Average().ToString());
            Console.WriteLine("Press Enter to Exit");
            Console.WriteLine("-------------------------------------------");
            Console.ReadLine();
        }
    }
}
