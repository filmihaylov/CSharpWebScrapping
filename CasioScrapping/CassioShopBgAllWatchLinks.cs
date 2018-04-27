using CasioScrapping.Exceptions;
using CasioShopBgScrapping.Exceptions;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasioShopBgScrapping
{
    public static class CassioShopBgAllWatchLinks
    {

        private static List<string> WatchesLinks = new List<string>();
        private static string BaseUrl = CasioShopEndpoints.BaseUrl;
        private static string ManUrl = CasioShopEndpoints.MenWathces;
        private static string WomenUrl = CasioShopEndpoints.WomenWatches;

        // the method that returns all watches links in an List
        public static List<string> AllWatchesPageLinks()
        {
            ScrapingBrowser Browser = new ScrapingBrowser
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true,
                Encoding = Encoding.UTF8
            };

            populateInternalWathcesLinks(Browser);
            int watchLinksCountVerifyer = WatchLinksCountChecker(Browser);

            if (WatchesLinks.Count != watchLinksCountVerifyer)
            {
                throw new WatchesLinksNotCorrectNumberException(WatchesLinks.Count.ToString());
            }
            List<string> WatchesLinksTrimmed = new List<string>();
            foreach (var wathcLink in WatchesLinks)
            {
                WatchesLinksTrimmed.Add(BaseUrl + wathcLink.Trim());
            }

            return WatchesLinksTrimmed;
        }

        //this method starts the population of the watches link list
        private static void populateInternalWathcesLinks(ScrapingBrowser Browser)
        {
            int pageIndex = 1;
            while (true)
            {
                var result = CheckIfThereAreResults(Browser, BaseUrl + ManUrl + "/page/" + pageIndex);
                if (result == null)
                {
                    break;
                }

                AppendLinksToList(result);

                pageIndex = pageIndex + 1;
            }

            pageIndex = 1;

            while (true)
            {
                var result = CheckIfThereAreResults(Browser, BaseUrl + WomenUrl + "/page/" + pageIndex);
                if (result == null)
                {
                    break;
                }

                AppendLinksToList(result);
                pageIndex = pageIndex + 1;
            }

        }

        //this method checks if there are found results on this incremmented page 
        private static WebPage CheckIfThereAreResults(ScrapingBrowser Browser, string url)
        {
            WebPage PageResult = null;
            try
                {
                 PageResult = Browser.NavigateToPage(new Uri(url));
                }
            catch(Exception e)
            {
                return null;
            }

            if (PageResult != null)
            {
                HtmlNode pageContent = null;
                try
                {
                    pageContent = PageResult.Html.CssSelect("div#results").First();
                }
                catch(Exception e)
                {
                    return null;
                }
                if(pageContent == null || pageContent.InnerText.Contains("Няма резултати"))
                {
                    return null;
                }
                else
                {
                    return PageResult;
                }
            }
            else
            {
                return null;
            }
        }

        // this method appends links to the static private list watch links
        private static void AppendLinksToList(WebPage PageResult)
        {
            try
            {
                var watchDivs = PageResult.Html.CssSelect("div.product_box");
                foreach (var watchdiv in watchDivs)
                {
                    var links = watchdiv.CssSelect("a");
                    foreach (var href in links)
                    {
                        if (href.InnerText.Contains("Casio") || href.InnerText.Contains("CASIO"))
                        {
                            WatchesLinks.Add(href.GetAttributeValue("href"));
                        }
                    }
                }
            }
            catch(Exception e)
            {
                throw new CouldNotScrapWathcesLinksFromBasePageException(e.Message);
            }
        }


        // This method gets the result count from the page for letter comparison with the whole links count
        private static int WatchLinksCountChecker(ScrapingBrowser Browser)
        {

            WebPage PageResultMen = Browser.NavigateToPage(new Uri(BaseUrl+CasioShopEndpoints.MenWathces + "/page/1"));

            var menWatchesLinks = PageResultMen.Html.CssSelect("b#rescount").First();
            int menWatchesLinksInt = Int32.Parse(menWatchesLinks.InnerText);

            WebPage PageResultWoment = Browser.NavigateToPage(new Uri(BaseUrl + CasioShopEndpoints.WomenWatches + "/page/1"));

            var womenWatchesLinks = PageResultWoment.Html.CssSelect("b#rescount").First();
            int womenWatchesLinksInt = Int32.Parse(womenWatchesLinks.InnerText);

            return menWatchesLinksInt + womenWatchesLinksInt;
        }

    }
}
