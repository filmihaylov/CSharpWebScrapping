using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonFunctions.DTOs
{
    public class AmazonWatchPriceDTO
    {
        public string WatchName { get; set; }
        public decimal AmazonPrice { get; set; }
        public decimal BGWatchPrice { get; set; }
    }
}
