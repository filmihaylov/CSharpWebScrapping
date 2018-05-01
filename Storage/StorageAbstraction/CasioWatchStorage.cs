using CasioScrapping.DTOs;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.StorageAbstraction
{
    public static class CasioWatchStorage
    {
        public static void StoreWatches(List<CasioWatch> watches)
        {
            using (var db = new WebScrappingContext())
            {
                if(watches != null)
                {
                    db.CasioWatch.AddRange(watches);
                    db.SaveChanges();
                }
            }
        }

        public static void StoreWatche(CasioWatch watch)
        {
            using (var db = new WebScrappingContext())
            {
                if (watch != null)
                {
                    db.CasioWatch.Add(watch);
                    db.SaveChanges();
                }
            }
        }

        public static List<CasioWatch> GetWatchesFromDB()
        {
            using (var db = new WebScrappingContext())
            {
                var query = from watch in db.CasioWatch
                                           orderby watch.CasioWatchId
                                           select watch;

                List<CasioWatch> watches = query.ToList<CasioWatch>();
                return watches;
            }
        }

        public static CasioWatch GetSingleWatchFromDB(string watchName)
        {
            using (var db = new WebScrappingContext())
            {
                var query = from watchdb in db.CasioWatch
                            where watchdb.Name == watchName
                            select watchdb;

                CasioWatch watch = query.SingleOrDefault<CasioWatch>();
                return watch;
            }
        }

        public static void UpdateWatch(CasioWatch watch)
        {
            // add logic to update only properties that are not null
            using (var db = new WebScrappingContext())
            {
                if (watch != null)
                {
                    var query = from watchdb in db.CasioWatch
                                where watchdb.Name == watch.Name
                                select watchdb;
                    CasioWatch updateWatch = query.SingleOrDefault<CasioWatch>();
                    updateWatch.AmazonPosted = watch.AmazonPosted;
                    updateWatch.AmazonPricePost = watch.AmazonPricePost;
                    updateWatch.BetterPriceThanAmazon = watch.BetterPriceThanAmazon;
                    updateWatch.Description = watch.Description;
                    updateWatch.Image = watch.Image;
                    updateWatch.ImageUrl = watch.ImageUrl;
                    updateWatch.Name = watch.Name;
                    updateWatch.Price = watch.Price;
                    updateWatch.WatchUrl = watch.WatchUrl;
                    db.SaveChanges();
                }
            }
        }

    }
}
