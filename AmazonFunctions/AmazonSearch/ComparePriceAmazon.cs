using AmazonFunctions.DTOs;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmazonFunctions.AmazonSearch
{
    public static class ComparePriceAmazon
    {
        private static string AmazonSearchBaseUrl = "https://www.amazon.co.uk/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=";

        public static AmazonWatchPriceDTO ComparePrice(AmazonWatchPriceDTO watch)
        {
            // compare logic return new price of we beet amazon one  need to finish currency converter class
            return null;
        }


        private static decimal getFirstMatchPrice(AmazonWatchPriceDTO watch)
        {
            ScrapingBrowser Browser = new ScrapingBrowser
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true,
                Encoding = Encoding.UTF8
            };
            WebPage PageResultMen = Browser.NavigateToPage(new Uri(AmazonSearchBaseUrl+watch.WatchName));

            try
            {
                var resultWindow = PageResultMen.Html.CssSelect("ul#s-results-list-atf").First();
                var resultFirstElement = resultWindow.CssSelect("li#result_0").First();
                var priceElement = resultFirstElement.CssSelect("span.a-size-base a-color-price s-price a-text-bold").First();
                string priceString = priceElement.InnerText;
                string removeCharacters = Regex.Replace(priceString.Trim(), "[^.0-9]", "");
                decimal AmazonPriceGBR = Convert.ToDecimal(removeCharacters);
                return AmazonPriceGBR;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}
