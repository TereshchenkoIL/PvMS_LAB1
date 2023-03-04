using System;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpChannel ch = new HttpChannel(5000);

            ChannelServices.RegisterChannel(ch, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
             typeof(CoreLib.TextSorter),
             "TextSorter.soap",
             WellKnownObjectMode.Singleton);

            Console.WriteLine("TextSorter service is ready...");

            Console.ReadLine();
        }
    }
}
