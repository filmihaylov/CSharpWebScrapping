using CasioShopBgScrapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceIntelligence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> links = CassioShopBgAllWatchLinks.AllWatchesPageLinks();
            foreach (var link in links)
            {
                Console.WriteLine(link);
            }

            Console.ReadKey();
        }
    }
}
