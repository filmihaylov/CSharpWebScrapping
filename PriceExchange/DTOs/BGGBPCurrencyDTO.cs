using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceExchange.DTOs
{
    public class BGGBPCurrencyDTO
    {
        public Rates Rates { get; set; }
    }

    public class Rates
    {
        public decimal BGN { get; set; }
        public decimal GBP { get; set; }
    }
}


