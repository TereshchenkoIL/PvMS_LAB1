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
            // Створюю Http, що буде використовувати порт 5000
            HttpChannel ch = new HttpChannel(5000);
            // Створюю Http канал в сервісі каналів для використання
            ChannelServices.RegisterChannel(ch, false);

            // Реєструю віддалений сервіс, для того, щоб його могли використовувати клієнти
            RemotingConfiguration.RegisterWellKnownServiceType(
             typeof(CoreLib.TextSorter),
             "TextSorter.soap",
             WellKnownObjectMode.Singleton);

            Console.WriteLine("TextSorter service is ready...");

            Console.ReadLine();
        }
    }
}
