using CasioScrapping.DTOs;
using CasioScrapping.Exceptions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasioShopBgScrapping
{
    public class WatchPageScrapper
    {
        private string url;
        private ScrapingBrowser Browser;
        private WebPage PageWatchResult;
        private static string BaseUrl = CasioShopEndpoints.BaseUrl;
        private static string ManUrl = CasioShopEndpoints.MenWathces;
        private static string WomenUrl = CasioShopEndpoints.WomenWatches;

        public WatchPageScrapper(string url)
        {
            this.url = url;
            this.Browser = new ScrapingBrowser
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true,
                Encoding = Encoding.UTF8
            };

            try
            {
                this.PageWatchResult = this.Browser.NavigateToPage(new Uri(BaseUrl + this.url));
            }
            catch(Exception e)
            {
                throw new InvalidWatchPageUrlException(e.Message);
            }
        }

        public WatchCasioBgScrappeDTO GetWatchScrapped()
        {
            WatchCasioBgScrappeDTO watchDTOPopulated = new WatchCasioBgScrappeDTO()
            {
                ImageLink = ExtractWatchImageLink(this.PageWatchResult),
                Name = ExtractWatchName(this.PageWatchResult),
                Price = ExtractWatchPrice(this.PageWatchResult),
                WatchDescription = ExtractWatchDescription(this.PageWatchResult),
                WatchUrl = this.url
            };

            return watchDTOPopulated;
        }

        private string ExtractWatchDescription(WebPage pageWatchResult)
        {
            throw new NotImplementedException();
        }

        private string ExtractWatchPrice(WebPage pageWatchResult)
        {
            throw new NotImplementedException();
        }

        private string ExtractWatchName(WebPage pageWatchResult)
        {
            throw new NotImplementedException();
        }

        private string ExtractWatchImageLink(WebPage pageWatchResult)
        {
            throw new NotImplementedException();
        }
    }
}
