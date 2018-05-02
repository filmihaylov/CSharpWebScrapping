using CasioScrapping.DTOs;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PriceIntelligence.Mappers
{
    public static class CasioWatchModellMapper
    {
        public static CasioWatch ConvertToDBModel(WatchCasioBgScrappeDTO scrapedWatchModel)
        {
            CasioWatch watch = new CasioWatch();
            decimal scrapedWatchModelPrice = 0;
            try
            {
                scrapedWatchModelPrice = Convert.ToDecimal(scrapedWatchModel.Price.Trim());
            }
            catch(Exception e)
            {
                string removeCharacters = Regex.Replace(scrapedWatchModel.Price.Trim(), "[^.0-9]", "");
                scrapedWatchModelPrice = Convert.ToDecimal(removeCharacters);
            }

            watch.Price = scrapedWatchModelPrice;

            watch.Name = scrapedWatchModel.Name.Trim();

            watch.ImageUrl = scrapedWatchModel.ImageLink.Trim();

            watch.Description = scrapedWatchModel.WatchDescription;

            watch.WatchUrl = scrapedWatchModel.WatchUrl.Trim();

            WebClient client = null;
            try
            {
                client = new WebClient();
                watch.Image = client.DownloadData(watch.WatchUrl);

            }
            catch (Exception e)
            {
                watch.Image = null;
            }
            finally
            {
                client.Dispose();
            }

            return watch;

        }


        public static CasioWatch ConvertToDBModelInitial(WatchCasioBgScrappeDTO scrapedWatchModel)
        {
            CasioWatch watch = new CasioWatch();
            decimal scrapedWatchModelPrice = 0;
            try
            {
                scrapedWatchModelPrice = Convert.ToDecimal(scrapedWatchModel.Price.Trim());
            }
            catch (Exception e)
            {
                string removeCharacters = Regex.Replace(scrapedWatchModel.Price.Trim(), "[^.0-9]", "");
                scrapedWatchModelPrice = Convert.ToDecimal(removeCharacters);
            }

            watch.Price = scrapedWatchModelPrice;

            watch.Name = scrapedWatchModel.Name.Trim();

            watch.ImageUrl = scrapedWatchModel.ImageLink.Trim();

            watch.Description = scrapedWatchModel.WatchDescription;

            watch.WatchUrl = scrapedWatchModel.WatchUrl.Trim();

            watch.AmazonPosted = false;

            watch.AmazonPricePost = 0;

            watch.AmazonPriceSearchLowest = 0;

            watch.BetterPriceThanAmazon = false;

            WebClient client = null;
            try
            {
                client = new WebClient();
                watch.Image = client.DownloadData(watch.WatchUrl);

            }
            catch (Exception e)
            {
                watch.Image = null;
            }
            finally
            {
                client.Dispose();
            }

            return watch;

        }
    }
}
