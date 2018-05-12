using AmazonFunctions.DTOs;
using PriceExchange;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AmazonFunctions.AmazonSearch
{
    public static class ComparePriceAmazon
    {
        private static string AmazonSearchBaseUrl = "https://www.amazon.co.uk/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=";

        public static AmazonWatchPriceDTO ComparePrice(SimpleWatchForSearchQueryDTO watch)
        {
            AmazonWatchPriceDTO Populatedwatch = getFirstMatchPrice(watch);

            if (Populatedwatch == null)
            {
                Thread.Sleep(60000);
                Populatedwatch = getFirstMatchPrice(watch);
            }

            try
            {
                decimal bgPrice = Populatedwatch.BGWatchPrice;
                decimal GBPPRice = Populatedwatch.AmazonPrice;

                decimal GBPPriceToBGExchange = Exchange.convertFromPoundsToBGN(GBPPRice);
                if(GBPPriceToBGExchange > bgPrice)
                {
                    Populatedwatch.BeatsAmazonPrice = true;
                }
                else
                {
                    Populatedwatch.BeatsAmazonPrice = false;
                }
            }

            catch(Exception e)
            {
                return null;
            }

            return Populatedwatch;
        }


        // takes the amazon watch Price DTO and polulates the new fields for futher ussage from the amazon search
        private static AmazonWatchPriceDTO getFirstMatchPrice(SimpleWatchForSearchQueryDTO watch)
        {
            ScrapingBrowser Browser = new ScrapingBrowser
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true,
                Encoding = Encoding.UTF8
            };
            WebPage PageResultMen = Browser.NavigateToPage(new Uri(AmazonSearchBaseUrl+watch.WatchBgName));

            try
            {
                var resultWindow = PageResultMen.Html.CssSelect("ul#s-results-list-atf").First();
                var resultFirstElement = resultWindow.CssSelect("li#result_0").First();
                var priceElement = resultFirstElement.CssSelect("span.a-size-base.a-color-price.s-price.a-text-bold").First();
                var nameElement = resultFirstElement.CssSelect("h2.a-size-medium.s-inline.s-access-title.a-text-normal").First();

                string amazonNameSearchWatch = nameElement.InnerText;
                string priceString = priceElement.InnerText;
                string removeCharacters = Regex.Replace(priceString.Trim(), "[^.0-9]", "");
                decimal AmazonPriceGBR = Convert.ToDecimal(removeCharacters);

                AmazonWatchPriceDTO returnedPopulatedFieldsDTO = new AmazonWatchPriceDTO()
                {
                    AmazonPrice = AmazonPriceGBR,
                    AmazonWatchNameFound = amazonNameSearchWatch,
                    BGWatchPrice = watch.WatchBgPrice,
                    WatchName = watch.WatchBgName
                };

                return returnedPopulatedFieldsDTO;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
