using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Models
{
    public class CasioWatch
    {
        public int CasioWatchId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string WatchUrl { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public bool AmazonPosted { get; set; }
        public bool BetterPriceThanAmazon { get; set; }
        public decimal AmazonPricePost { get; set; }
        public decimal AmazonPriceSearchLowest { get; set; }
    }
}
