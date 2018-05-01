using CasioScrapping.DTOs;
using CasioShopBgScrapping;
using PriceIntelligence.Mappers;
using Storage;
using Storage.Models;
using Storage.StorageAbstraction;
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
            //List<string> links = CassioShopBgAllWatchLinks.AllWatchesPageLinks();
            //foreach (var link in links)
            //{
            //    Console.WriteLine(link);
            //}

            //WatchCasioBgScrappeDTO testWatch = new CasioShopBgScrapper(links).ScrapeAWatch(links[1]);
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine(testWatch.ImageLink);
            //Console.WriteLine(testWatch.Name);
            //Console.WriteLine(testWatch.Price);
            //Console.WriteLine(testWatch.WatchDescription);
            //Console.WriteLine(testWatch.WatchUrl);

            List <WatchCasioBgScrappeDTO> scrapedWatches = new CasioShopBgScrapper().ScrapeAllWatches();

            foreach(var scrWatch in scrapedWatches)
            {
                try
                {
                    CasioWatchStorage.StoreWatche(CasioWatchModellMapper.ConvertToDBModelInitial(scrWatch));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        
        }
    }
}
