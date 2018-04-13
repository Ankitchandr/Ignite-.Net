using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgniteProjectNet
{
    public class Car 
    {
        /* public string Model { get; set; }
         public int Power { get; set; }
         public override string ToString() => $"Model: {Model}, Power: {Power} hp";

         public static void Show()
         {
           using (var ignite = Ignition.Start())
             {
                 ICache<int, Car> cache = ignite.GetOrCreateCache<int, Car>("cars");
                 cache[1] = new Car { Model = "Hero Hondha", Power = 560 };
                 cache[2] = new Car { Model = "ZMR", Power = 460 };
                 cache[3] = new Car { Model = "CBZ", Power = 230 };
                 cache[4] = new Car { Model = "HUNK", Power = 460 };
                 cache[5] = new Car { Model = "Apache", Power = 570 };
                 foreach (ICacheEntry<int, Car> entry in cache)
                     Console.WriteLine(entry);
             }

         }*/

        
        
            [QuerySqlField]
            public string Model { get; set; }
            [QuerySqlField]
            public int Power { get; set; }

        public static void Show()
        {
            using (var ignite = Ignition.Start())
            {
                var queryEntity = new QueryEntity(typeof(int), typeof(Car));
                var cacheConfig = new CacheConfiguration("cars", queryEntity);
                ICache<int, Car> cache = ignite.GetOrCreateCache<int, Car>(cacheConfig);

                // Вставка данных (_key - предопределённое поле):
                var insertQuery = new SqlFieldsQuery("INSERT INTO Car (_key, Model, Power) VALUES " +
                                                     "(1, 'Ariel Atom', 350), " +
                                                     "(2, 'Reliant Robin', 39)");
                cache.QueryFields(insertQuery).GetAll();

                // Запрос данных:
                var selQuery = new SqlQuery(typeof(Car), "SELECT * FROM Car ");
                foreach (ICacheEntry<int, Car> entry in cache.Query(selQuery))
                    // Console.WriteLine(entry.Key +":"+ entry.Value );
                    Console.WriteLine(entry); 

                


            }
        }


        static void Main(string[] args)
        {
            Show();
            Console.Read();
        }

    }
}