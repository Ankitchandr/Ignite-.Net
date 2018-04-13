using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgniteProjectNet
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Person [Name={Name}, Age={Age}]";
        }
    }
    class EmployeeDetails
    {
        static void Main()
        {
            var cfg = new IgniteConfiguration
            {
                // Register custom class for Ignite serialization
                BinaryConfiguration = new BinaryConfiguration(typeof(Person))
            };
            IIgnite ignite = Ignition.Start(cfg);
            ICache<int, Person> cache = ignite.GetOrCreateCache<int, Person>("persons");
            cache[1] = new Person { Name = "Ankit Chandra", Age = 27 };
            cache[2] = new Person { Name = "kundan", Age = 22 };
            cache[3] = new Person { Name = "Sonali", Age = 23 };
            cache[4] = new Person { Name = "Pritam", Age = 21 };
            cache[5] = new Person { Name = "Kangna", Age = 24 };
            cache[6] = new Person { Name = "Ruhi", Age = 23 };
            foreach (ICacheEntry<int, Person> cacheEntry in cache)
                Console.WriteLine(cacheEntry);
            Console.ReadKey();
        }
       
    }
}
