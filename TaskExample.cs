namespace IgniteProjectNet
{
    using Apache.Ignite.Core;
    using Apache.Ignite.Core.Client;
    using Apache.Ignite.Core.Client.Cache;
    using Apache.Ignite.Core.Communication.Tcp;
    using System;

    public class TaskExample
    {
        public static void Main()
        {

            Ignition.Start();

            var cfg = new IgniteClientConfiguration
            {
                Host = "192.168.1.35"
            };

            using (IIgniteClient client = Ignition.StartClient(cfg))
            {
                ICacheClient<int, string> cache = client.GetCache<int, string>("cache");
                cache.Put(1, "Hello, World!");
            }
            Console.ReadKey();
        }
    }
}
