using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            MappingPathSection section = ConfigurationManager.GetSection("MappingPathSection") as MappingPathSection;
            foreach(BatchConfigElement batch in section.Batchs)
            {
                Console.WriteLine(batch.BatchId);
                foreach(MappingConfigElement mapping in batch.Mappings)
                {
                    Console.WriteLine("-" + mapping.Name);
                }
            }
            Console.ReadLine();
        }
    }
}
