using CasioScrapping.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasioShopBgScrapping
{
    public class CasioShopBgScrapper
    {
        private List<string> allWatchLinks = new List<string>();

        public CasioShopBgScrapper()
        {
            this.allWatchLinks = CassioShopBgAllWatchLinks.AllWatchesPageLinks();
        }


        public CasioShopBgScrapper(List<string> WatchLinks)
        {
            this.allWatchLinks = WatchLinks;
        }

        public WatchCasioBgScrappeDTO ScrapeAWatch(string WatchUrl)
        {
            WatchPageScrapper watchScrap = new WatchPageScrapper(WatchUrl);
            WatchCasioBgScrappeDTO scrapedWatch = watchScrap.GetWatchScrapped();
            return scrapedWatch;
        }

        public List<WatchCasioBgScrappeDTO> ScrapeAllWatches()
        {
            List<WatchCasioBgScrappeDTO> scrapedWatchesList = new List<WatchCasioBgScrappeDTO>();
            foreach (var watchUrl in allWatchLinks)
            {
                // take into account a little waiting later refactor
                System.Threading.Thread.Sleep(1000);
                WatchPageScrapper watchScrap = new WatchPageScrapper(watchUrl);
                WatchCasioBgScrappeDTO scrapedWatch = watchScrap.GetWatchScrapped();
                scrapedWatchesList.Add(scrapedWatch);
            }
            return scrapedWatchesList;
        }

        public List<string> GetAllWatchesLinks()
        {
            return this.allWatchLinks;
        }

    }
}
