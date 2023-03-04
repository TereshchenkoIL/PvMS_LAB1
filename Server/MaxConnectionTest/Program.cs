using CoreLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MaxConnectionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpChannel ch = new HttpChannel();
            ChannelServices.RegisterChannel(ch, false);

            var remote = (TextSorter)Activator.GetObject(
                        typeof(TextSorter),
                        "http://localhost:5000/TextSorter.soap");

            EventWaitHandle signal = new EventWaitHandle(initialState: false, mode: EventResetMode.ManualReset);

            ThreadStart action = () => {
                signal.WaitOne();
                remote.SortWords("a1 b2 d3 c4");
                Console.WriteLine("iteration");
            };

            foreach (var i in Enumerable.Range(0, 500))
                new Thread(action) { IsBackground = true }.Start();

            Console.WriteLine("Press any key to bombard server...");
            Console.ReadKey(intercept: true);

            signal.Set();

            Console.ReadLine();
        }
    }
}
