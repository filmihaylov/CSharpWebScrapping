using CasioScrapping.DTOs;
using CasioScrapping.Exceptions;
using ScrapySharp.Extensions;
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
        private string BaseUrl = CasioShopEndpoints.BaseUrl;
        private string ManUrl = CasioShopEndpoints.MenWathces;
        private string WomenUrl = CasioShopEndpoints.WomenWatches;

        public WatchPageScrapper(string Watchurl)
        {
            this.url = Watchurl;
            this.Browser = new ScrapingBrowser
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true,
                Encoding = Encoding.UTF8
            };

            try
            {
                this.PageWatchResult = this.Browser.NavigateToPage(new Uri(this.url));
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
            try
            {
                List<string> listDescription = new List<string>();
                var rightSideNodes = pageWatchResult.Html.CssSelect("div#rightside").First();
                var innerDiv = rightSideNodes.CssSelect("div.inner_wrap").First();
                var orderedList = innerDiv.CssSelect("ul");
                var descriptionListElements = orderedList.CssSelect("li");
                foreach (var desc in descriptionListElements)
                {
                    listDescription.Add(desc.InnerText.Trim());
                }

                string descriptionJoined = string.Join(":", listDescription);

                return descriptionJoined;
            }
            catch(Exception e)
            {
                throw new WatchDescriptionScrappingException(e.Message);
            }
        }

        private string ExtractWatchPrice(WebPage pageWatchResult)
        {
            try
            {
                var priceNode = pageWatchResult.Html.CssSelect("span#pprice").First();
                var priceElement = priceNode.CssSelect("strong").First();
                string price = priceElement.InnerText.Trim();

                // format it here as else
                return price;
            }
            catch(Exception e)
            {
                throw new WatchDescriptionScrappingException(e.Message);
            }
        }

        private string ExtractWatchName(WebPage pageWatchResult)
        {
            try
            {
                var nameNode = pageWatchResult.Html.CssSelect("div#rightside").First();
                var heading = nameNode.CssSelect("h1").First();
                string name = heading.InnerText.Trim();
                return name;
            }
            catch(Exception e)
            {
                throw new WatchDescriptionScrappingException(e.Message);
            }
        }

        private string ExtractWatchImageLink(WebPage pageWatchResult)
        {
            try
            {

                var nodesLink = pageWatchResult.Html.CssSelect("a#product");
                var linkTag = nodesLink.CssSelect("img").First();
                var linkImage = linkTag.GetAttributeValue("src");
                string imageFullLink = this.BaseUrl + linkImage.ToString().Trim();
                return imageFullLink;
            }
            catch(Exception e)
            {
                throw new WatchDescriptionScrappingException(e.Message);
            }
        }
    }
}
